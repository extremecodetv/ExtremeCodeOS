#pragma once

#include "CompilerPoint.h"
#include "CompilerType.h"
#include "json.hpp"
#include <vector>
#include <string>
#include <fstream>

using namespace nlohmann;

vector<CompilerType> GetCompilerTypes() {

	ifstream File("CompilerTypes.json");
	vector<CompilerType> Result;
	json JsonArray;

	File >> JsonArray;
	for (int i = 0;  i < static_cast<int>(JsonArray.size()); i++) {
		Result.resize(Result.size() + 1);
		Result[i] = CompilerType();
		Result[i].Name = JsonArray[i]["Name"].get<string>();
		Result[i].CompilCommands = JsonArray[i]["CompilCommands"].get<vector<string>>();
		Result[i].Args = JsonArray[i]["Args"].get<vector<string>>();
	}
	return Result;
}

vector<CompilerPoint> GetCompilerPoints() {

	ifstream File("CompilerPoints.json");
	vector<CompilerPoint> Result;
	json JsonArray;

	File >> JsonArray;
	
	for (int i = 0; i < static_cast<int>(JsonArray.size()); i++) {
		Result.resize(Result.size() + 1);
		Result[i] = CompilerPoint();
		Result[i].CompilerType = JsonArray[i]["CompilType"].get<string>();
		Result[i].ProgramName = JsonArray[i]["ProgramName"].get<string>();
		Result[i].CompilerData = JsonArray[i]["CompilData"].get<map<string, string>>();
	}

	return Result;
}