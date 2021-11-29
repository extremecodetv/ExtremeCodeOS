#pragma once

#define ERROR 0
#define SUCESSFULL 1

#include <string>
#include <iostream>
#include <fstream>

using namespace std;

ofstream LogFile("CompilerLog.log");

void Log(int LogType, string FullLog, string ShortLog) {
	string LogTypeString;

	switch (LogType)
	{
	case 0:
		LogTypeString = "[Ошибка!] ";
		break;
	case 1:
		LogTypeString = "[Удачно!] ";
		break;
	}

	LogFile << LogTypeString << FullLog << endl;

	cout << LogTypeString << ShortLog << "\n";
}

void Close() {
	LogFile.close();
}