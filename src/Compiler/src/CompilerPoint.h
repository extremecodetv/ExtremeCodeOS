#pragma once

#include <string>
#include <map>

using namespace std;

struct CompilerPoint
{
	string ProgramName;
	string CompilerType;
	map<string, string> CompilerData;
};