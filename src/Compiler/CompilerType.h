#pragma once

#include <string>
#include <vector>

using namespace std;

struct CompilerType
{
	string Name;
	vector<string> CompilCommands;
	vector<string> Args;
};