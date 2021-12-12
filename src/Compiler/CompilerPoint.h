#pragma once

#include <string>
#include <vector>
#include <map>

using namespace std;

struct CompilerPoint
{
	string CompilerType;
	map<string, string> CompilerData;
	vector<string> IfSuccessful;
	vector<string> IfFailed;
};