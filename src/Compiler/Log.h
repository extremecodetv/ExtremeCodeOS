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
	case ERROR:
		LogTypeString = "[Ошибка!] ";
		break;
	case SUCESSFULL:
		LogTypeString = "[Удачно!] ";
		break;
	}

	LogFile << LogTypeString << FullLog << endl;

	cout << LogTypeString << ShortLog << endl;
}

void Close() {
	LogFile.close();
}