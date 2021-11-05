//Писалось в ArduinoIDE под AVR Atmega328
#include <Servo.h>  //Для моторов 
#include <Wire.h>   //Не помню для чего, сами разберетесь
#include <ITG3200.h>  //Какой-то датчик
#include <math.h>     //Матеша
#include <ADXL345.h>  //Акселерометр и гироскоп
#include <NewPing.h>  //Можно прикрутить УЗ сонар

#define TRIG 6    //Выходы для работы с сонаром
#define ECHO 7
#define MAXIMUM_ALTITUDE 100  //Максимальная разрешенная высота полета по сонару в метрах
#define RAD 0.0174532    //Константы для перевода углов
#define DEG 57.2957795

Servo frontLeft;  //Объявление моторов квадрокоптера
Servo backLeft;
Servo backRight;
Servo frontRight;

ITG3200 Gyro = ITG3200();   //Объявление гироскопа и акселерометра
ADXL345 Accelerometer;
NewPing altitudeSonar(TRIG, ECHO, MAXIMUM_ALTITUDE);

//переменные для хранения сырых входных данных для регуляторов оборотов
int frontLeftValueRaw = 0;
int backLeftValueRaw = 0;
int backRightValueRaw = 0;
int frontRightValueRaw = 0;

//переменные для хранения готовых к использованию входных данных для регуляторов оборотов
int frontLeftValue = 0;
int backLeftValue = 0;
int backRightValue = 0;
int frontRightValue = 0;

float GyroX, GyroY, GyroZ;      //Переменные для хранения данных об ориентации в пространстве
float GyroAngleX, GyroAngleY;
float GyroErrorX, GyroErrorY, GyroErrorZ;
float AccAngleX, AccAngleY, TotalVector;
float pitch, roll, yaw;
float altitude;  //Хранение высоты
float elapsedTime, currentTime, previousTime;  //Хранение времени
Vector Acc;    //Сырые данные с акселерометра хранятся в векторе (определен в ADXL345.h)

int kx = 0.0004;      //Коэффициент комплементарного фильтра
int ky = 0.0004;

// переменные для фильтра Калмана
float varVoltY = 0.0762453;  // среднее отклонение 
float varVoltX = 0.2856267;
float varProcess = 0.05; // скорость реакции на изменение (подбирается вручную)
float Pc = 0.0;
float G = 0.0;
float P = 1.0;
float Xp = 0.0;
float Zp = 0.0;
float Xe = 0.0;

int throttle = 0;   //Уровень тяги. 0-1023, ограничевается

void yawStabilize(int y);    //Объявления функций стабилизации
void rollStabilize(int r);
void pitchStabilize(int p);
void ZeroStabilize();
void yawSet(int deg);   //Объявление функций удержания значений
void rollSet(int deg);
void pitchSet(int deg);
void altHold(int alt);
bool goLeft(int meters);
bool goRight(int meters);
bool goBack(int meters);
bool goForward(int meters);

const int maxIncline = 20;    //Безопасность 
const float maxAcc = 0.2;   
void checkFailure();          //Если крен превысит допустимые значения       
bool safetyKey = true;        //произойдет отключение двигателей

float filter(float val, float varVolt);

void setup()
{
  Serial.begin(19200);

  frontLeft.attach(2);  //Подключение моторов
  backLeft.attach(3);   //ОПАСНОСТЬ
  backRight.attach(4);  //Эти методы заставляют моторы работать на некоторой тяге все время
  frontRight.attach(5); //выполнения setup(), проверьте установки тяги в ноль после их вызова
  //НИЧЕГО СЮДА НЕ ВСТАВЛЯТЬ, НАРУШЕНИЕ АЛГОРИТМА ПРИВЕДЕТ К КАТАСТРОФЕ 
  frontLeft.writeMicroseconds(800);   //Минимальная тяга
  backLeft.writeMicroseconds(800);
  backRight.writeMicroseconds(800);
  frontRight.writeMicroseconds(800);
  //ТЕПЕРЬ МОЖНО ВСТАВЛЯТЬ
  Wire.begin();  //Начало работы I2C
  delay(500);    //Ожидание
  Gyro.init();   //Инициализация гироскопа
  Accelerometer.begin();              //Инициализация акселерометра
  Accelerometer.setRange(ADXL345_RANGE_16G);    //Установка разрешения акселерометра
  delay(500);
  calculate_gyro_error();      //Расчет ошибок измерительных приборов 
}

void loop()
{
  while(safetyKey)
  {
    if (Serial.available() > 0)  //последовательный порт для отладки
    {
      throttle = Serial.parseInt();    //Управление двигателями через COM. 0 - стоп, 1023 - максимум тяги
      Serial.print("I received: ");
      Serial.println(throttle, DEC);
      frontLeftValueRaw = throttle;
      backLeftValueRaw = throttle;
      backRightValueRaw = throttle;
      frontRightValueRaw = throttle;
    }

    //Получение сырых данных с акселерометра и расчет углов на из основе
    Acc = Accelerometer.readNormalize();

    TotalVector = sqrt(Acc.XAxis*Acc.XAxis + Acc.YAxis*Acc.YAxis + Acc.ZAxis*Acc.ZAxis);  //Абсолютный вектор силы тяжести
    AccAngleX = asin(Acc.XAxis / TotalVector) * -DEG;  //Углы расчитываются из синуса угла между абс.вектором и его проекцией на ось X или Y
    AccAngleY = asin(Acc.YAxis / TotalVector) * DEG;

    //Чтение данных с гироскопа
    previousTime = currentTime;       //Считает время между запросами данных
    currentTime = millis();           //Используется для получения угла из угловой скорости
    elapsedTime = (currentTime - previousTime) / 1000;  //Время в секундах
    Gyro.getAngularVelocity(&GyroX, &GyroY, &GyroZ);

    GyroX = GyroX - GyroErrorX;       //Исправление ошибок гироскопа
    GyroY = GyroY - GyroErrorY; 
    GyroZ = GyroZ - GyroErrorZ;

    GyroAngleX = GyroAngleX + GyroX * elapsedTime;    //Расчет углов крена, тангажа и рысканья
    GyroAngleY = GyroAngleY + GyroY * elapsedTime;    //на основе угловых скоростей гироскопа
    yaw = yaw + GyroZ * elapsedTime;                  //и времени (a = a + vt)
 
    //Комплементарный фильтр
    pitch = GyroAngleX * (1 - kx) + AccAngleX * kx;     //c = a(1-k) + bk
    roll = GyroAngleY * (1 - ky) + AccAngleY * ky;
    //Фильтр Калмана
    filter(roll, varVoltY);
    filter(pitch, varVoltX);

    checkFailure();
    altitude = altitudeSonar.ping_cm();

    frontLeftValueRaw = constrain(frontLeftValueRaw, 0, 1023);     //Ограничение значений тяги до рабочего диапазона
    backLeftValueRaw = constrain(backLeftValueRaw, 0, 1023);
    backRightValueRaw = constrain(backRightValueRaw, 0, 1023);
    frontRightValueRaw = constrain(frontRightValueRaw, 0, 1023);

    //приведение диапазона входных данных к диапазону работы регулятора оборотов бесколлекторного двигателя
    frontLeftValue = map(frontLeftValueRaw, 0, 1023, 800, 2300);    
    backLeftValue = map(backLeftValueRaw, 0, 1023, 800, 2300);
    backRightValue = map(backRightValueRaw, 0, 1023, 800, 2300);
    frontRightValue = map(frontRightValueRaw, 0, 1023, 800, 2300);

    //Вывод в СОМ для отладки
    Serial.print(roll);
    Serial.print("/");
    Serial.print(pitch);
    Serial.print("/");
    Serial.print(yaw);
    Serial.print("\n");
    Serial.print("/");/*
    Serial.print(frontLeftValue);
    Serial.print("/");
    Serial.print(backLeftValue);
    Serial.print("/");
    Serial.print(backRightValue);
    Serial.print("/");
    Serial.print(frontRightValue);
    Serial.print("\n");*/
    Serial.print(altitude);
    Serial.print("\n");

    //отправка сигнала на бесколекторный двигатель 
    frontLeft.writeMicroseconds(frontLeftValue);
    backLeft.writeMicroseconds(backLeftValue);
    backRight.writeMicroseconds(backRightValue);
    frontRight.writeMicroseconds(frontRightValue);
  }

  frontLeft.writeMicroseconds(800);
  backLeft.writeMicroseconds(800);
  backRight.writeMicroseconds(800);
  frontRight.writeMicroseconds(800);

Serial.write("Stopped\n");
}

void calculate_gyro_error()    //Функция расчета ошибок измерительных приборов 
{
int c = 0;
int a = 1000;
c = 0;
//Прочитать показания гироскопа а раз
while (c < a) {
Gyro.getAngularVelocity(&GyroX, &GyroY, &GyroZ);
GyroErrorX = GyroErrorX + GyroX;
GyroErrorY = GyroErrorY + GyroY;
GyroErrorZ = GyroErrorZ + GyroZ;
c++;
}
//Разделить сумму значений на а для получения ошибки
GyroErrorX = GyroErrorX / a;
GyroErrorY = GyroErrorY / a;
GyroErrorZ = GyroErrorZ / a;
}

//функция стабилизации рысканья
void yawStabilize(int y)
{
  int _yaw = static_cast<int>(yaw);
  int getYaw = y;
  int perror; 
  int error; 
  int spin = static_cast<int>(GyroZ);
  int sumError;
  float time, pTime, cTime;
  float P = 0.020;
  float I = 0.002;
  float D = 0.000;
  float yawForce;
  
  pTime = cTime;
  cTime = millis();
  time = (cTime - pTime);
  perror = error;
  error = getYaw - _yaw;
  spin = (error - perror) / time;
  sumError += error;
  
  yawForce = P * error + I * time  * sumError + D * spin;

  frontLeftValueRaw  = throttle + yawForce; 
  backRightValueRaw  = throttle + yawForce; 
  backLeftValueRaw   = throttle - yawForce;
  frontRightValueRaw = throttle - yawForce;
}

//следующие три функции используют ПИД регуляторы
//подстройте их или напишите автоматическую подгонку
//функция стабилизации крена
void rollStabilize(int r)
{
  int _roll = static_cast<int>(roll);
  int getRoll = r;
  int perror; 
  int error; 
  int spin = static_cast<int>(GyroY);
  int sumError;
  float time, pTime, cTime;
  float P = 0.100;
  float I = 0.100;
  float D = 0.004;
  float rollForce;
  
  pTime = cTime;
  cTime = millis();
  time = (cTime - pTime);
  perror = error;
  error = getRoll - _roll;
  spin = (error - perror) / time;
  sumError += error;
  
  rollForce = P * error + I * time  * sumError + D * spin;

  frontLeftValueRaw  = throttle + rollForce; 
  backRightValueRaw  = throttle - rollForce; 
  backLeftValueRaw   = throttle + rollForce;
  frontRightValueRaw = throttle - rollForce;
}

//функция стабилизации тангажа
void pitchStabilize(int p)
{
  int _pitch = static_cast<int>(pitch);
  int getPitch = p;
  int perror; 
  int error; 
  int spin = static_cast<int>(GyroX);
  int sumError;
  float time, pTime, cTime;
  float P = 0.100;
  float I = 0.100;
  float D = 0.004;
  float pitchForce;
  
  pTime = cTime;
  cTime = millis();
  time = (cTime - pTime);
  perror = error;
  error = getPitch - _pitch;
  spin = (error - perror) / time;
  sumError += error;
  
  pitchForce = P * error + I * time  * sumError + D * spin;

  frontLeftValueRaw  = throttle + pitchForce; 
  backRightValueRaw  = throttle - pitchForce; 
  backLeftValueRaw   = throttle - pitchForce;
  frontRightValueRaw = throttle + pitchForce;
}

//удержание высоты
void altHold(int alt)
{
  int error, perror;
  int vario;
  int sumError;
  float time, pTime, cTime;
  float P = 0.010;
  float I = 0.000;
  float D = 0.001;
  float throttleForce;

  pTime = cTime;
  cTime = millis();
  time = cTime - pTime;
  perror = error;
  error = alt - altitude;
  vario = (error - perror) / time;
  sumError += error;
  
  throttleForce = P * error + I * time * sumError + D * vario;

  throttle += throttleForce; 
  throttle += throttleForce; 
  throttle += throttleForce;
  throttle += throttleForce;

  ZeroStabilize();
}

//следующие функции нужны для маневрирования в пространстве
//написал их будучи сильно пьяным
//оставлю этот артефакт
//но вообще оно не работает, перепишите
bool goLeft(int meters)
{
  float pTime, cTime, time;
  if(Acc.YAxis > -maxAcc)
  {
    rollStabilize(-3);
    pitchStabilize(0);
    yawStabilize(0);
  }
  else
  {
    ZeroStabilize();
  }
  pTime = cTime;
  cTime = millis();
  time = cTime - pTime;
  S = S + ((Acc.YAxis * time * time) / 2);
  if(S >= static_cast<float>(meters))
  {
    ZeroStabilize();
    S = 0;
    return true;
  }
  else
  {
    return false;
  }
}

bool goRight(int meters)
{
  float pTime, cTime, time;
  if(Acc.YAxis < maxAcc)
  {
    rollStabilize(3);
    pitchStabilize(0);
    yawStabilize(0);
  }
  else
  {
    ZeroStabilize();
  }
  pTime = cTime;
  cTime = millis();
  time = cTime - pTime;
  S = S + ((Acc.YAxis * time * time) / 2);
  if(S >= static_cast<float>(meters))
  {
    ZeroStabilize();
    S = 0;
    return true;
  }
  else
  {
    return false;
  }
}

bool goBack(int meters)
{
  float pTime, cTime, time;
  if(Acc.XAxis < maxAcc)
  {
    pitchStabilize(3);
    rollStabilize(0);
    yawStabilize(0);
  }
  else
  {
    ZeroStabilize();
  }
  pTime = cTime;
  cTime = millis();
  time = cTime - pTime;
  S = S + ((Acc.XAxis * time * time) / 2);
  if(S >= static_cast<float>(meters))
  {
    ZeroStabilize();
    S = 0;
    return true;
  }
  else
  {
    return false;
  }
}

bool goForward(int meters)
{
  float pTime, cTime, time;
  if(Acc.XAxis > -maxAcc)
  {
    pitchStabilize(-3);
    rollStabilize(0);
    yawStabilize(0);
  }
  else
  {
    ZeroStabilize();
  }
  pTime = cTime;
  cTime = millis();
  time = cTime - pTime;
  S = S + ((Acc.XAxis * time * time) / 2);
  if(S >= static_cast<float>(meters))
  {
    ZeroStabilize();
    S = 0;
    return true;
  }
  else
  {
    return false;
  }
}

//удержание нуля (неподвижное положение крена, тангажа, рысканья)
void ZeroStabilize()
{
  pitchStabilize(0);
  rollStabilize(0);
  yawStabilize(0);
}

//функция проверки полета на безопасность
void checkFailure()
{
  if((((pitch > maxIncline) || (roll > maxIncline)) ||
     ((pitch < -maxIncline) || (roll < -maxIncline))) ||
     ((frontLeftValue > 2000) || (backLeftValue > 2000)))
  {
   frontLeft.writeMicroseconds(800);
   backLeft.writeMicroseconds(800);
   backRight.writeMicroseconds(800);
   frontRight.writeMicroseconds(800);
   frontLeftValueRaw = 0;
   backLeftValueRaw = 0;
   backRightValueRaw = 0;
   frontRightValueRaw = 0;
   safetyKey = false;
  }
  else
  {
   safetyKey = true;
  }
}

//функция фильтрации
//ворованная, меня про ее работу не спрашивать
float filter(float val, float varVolt) 
{  
  Pc = P + varProcess;
  G = Pc/(Pc + varVolt);
  P = (1-G)*Pc;
  Xp = Xe;
  Zp = Xp;
  Xe = G*(val-Zp)+Xp; // "фильтрованное" значение
  return(Xe);
}
