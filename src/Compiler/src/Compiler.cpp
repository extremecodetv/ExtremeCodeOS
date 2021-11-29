#include <iostream>
#include "Log.h"
#include "Load.h"
#include "CompilerPoint.h"
#include "CompilerType.h"
#include <string>

vector<string> Split(string String, char Space) {
    vector<string> Result;
    int i = 0;

    Result = vector<string>(1);

    for (int i2 = 0; i2 < static_cast<int>(String.size()); i2++) {
        if (String[i2] == Space) {
            Result.resize(Result.size() + 1);
            i++;
        }
        else {
            Result[i].resize(Result[i].size() + 1);
            Result[i][Result[i].size() - 1] = String[i2];
        }
    }

    return Result;
}

int RunCommands(CompilerPoint Point, CompilerType CorrectType) {
    vector<string> CommandPart;
    vector<string> Temp;
    string ResultCommand;

    for (int i = 0; i < static_cast<int>(CorrectType.CompilCommands.size()); i++) {

        CommandPart = Split(CorrectType.CompilCommands[i], '{');
        ResultCommand = string();
        ResultCommand.append(CommandPart[0]);
        for (int i2 = 1; i2 < static_cast<int>(CommandPart.size()); i2++) {
            Temp = Split(CommandPart[i2], '}');
            ResultCommand.append(Point.CompilerData[Temp[0]]);
            ResultCommand.append(Temp[1]);
        }

        ResultCommand.append(" > nul");
        ResultCommand.append(" 2> Error");
        ResultCommand.append(Point.ProgramName);
        ResultCommand.append(".log");

        if (system(ResultCommand.c_str()) != 0) {
            Log(ERROR, "Не удалось скомпилировать " + Point.ProgramName + ". Для полной информации посмотрите в фаил" + Point.ProgramName + ".log", "Не удалось скомпилировать " + Point.ProgramName);
            return 0;
        }

    }

    Log(SUCESSFULL, "Скомпилировано: " + Point.ProgramName, "Скомпилировано: " + Point.ProgramName);

    return 1;
}

int Compil(vector<CompilerType> CompilerTypes, CompilerPoint Point) {
    CompilerType CorrectType;
    string ResultCommand;
    vector<string> CommandPart;
    vector<string> Temp;
    string CompilCommand;
    bool FoundCorrectType = false;
    bool InName = false;
    string Name;

    for (int i = 0; i < static_cast<int>(CompilerTypes.size()); i++) {
        if (CompilerTypes[i].Name == Point.CompilerType) {
            CorrectType = CompilerTypes[i];
            FoundCorrectType = true;
        }
    }

    if (!FoundCorrectType) {
        Log(ERROR, "В программе " + Point.ProgramName + " указан некорректный тип компиляции!", "Не удалось скомпилировать: " + Point.ProgramName);
        return 0;
    }

    for (int i = 0; i < static_cast<int>(CorrectType.Args.size()); i++) {
        if (Point.CompilerData.find(CorrectType.Args[i]) == Point.CompilerData.end()) {
            Log(ERROR, "В программе " + Point.ProgramName + " отсутствуют требуемые аргументы для компиляции!", "Не удалось скомпилировать " + Point.ProgramName);
            return 0;
        }
    }

    return RunCommands(Point, CorrectType);
}

int main()
{
    system("@chcp 65001");
    setlocale(LC_CTYPE, "rus");

    int CompiledPrograms = 0;

    vector<CompilerType> CompilerTypes;
    vector<CompilerPoint> CompilerPoints;
    CompilerTypes = GetCompilerTypes();
    CompilerPoints = GetCompilerPoints();
    
    for (int i = 0; i < static_cast<int>(CompilerPoints.size()); i++) {
        CompiledPrograms += Compil(CompilerTypes, CompilerPoints[i]);
    }

    cout << endl << string(10, '-') << endl << "Удачно: " << CompiledPrograms << endl << "Не удалось: " << static_cast<int>(CompilerPoints.size()) - CompiledPrograms << endl << string(10, '-') << endl;
    
    Close();
    getchar();
    return 0;
}