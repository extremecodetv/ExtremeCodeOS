#pragma once

#include "CompilerPoint.h"
#include "CompilerType.h"
#include "CompilerBlock.h"
#include "json.hpp"
#include <vector>
#include <string>
#include <fstream>
#include <filesystem> 

namespace fs = std::filesystem;
using namespace nlohmann;

vector<CompilerType> GetCompilerTypes() {

	ifstream File("CompilerTypes.json");
	vector<CompilerType> Result;
	json JsonArray;

	File >> JsonArray;
	Result = vector<CompilerType>(JsonArray.size());
	for (size_t i = 0;  i < JsonArray.size(); i++) {
		Result[i] = CompilerType();
		Result[i].Name = JsonArray[i]["Name"].get<string>();
		Result[i].CompilCommands = JsonArray[i]["CompilCommands"].get<vector<string>>();
		Result[i].Args = JsonArray[i]["Args"].get<vector<string>>();
	}
	return Result;
}

CompilerPoint GetCompilerPoint(json &Json) {
	CompilerPoint Result;

	Result = CompilerPoint();
	Result.CompilerData = Json["CompilData"].get<map<string, string>>();
	Result.CompilerType = Json["CompilType"].get<string>();
	if (Json["IfSuccessful"].is_null()) {
		Result.IfSuccessful = vector<string>(0);
	} else {
		Result.IfSuccessful = Json["IfSuccessful"].get<vector<string>>();
	}
	if (Json["IfFailed"].is_null()) {
		Result.IfSuccessful = vector<string>(0);
	} else {
		Result.IfFailed = Json["IfFailed"].get<vector<string>>();
	}

	return Result;
}

CompilerBlock GetCompilerBlock(json &JsonArray, string FileName) {
	CompilerBlock Result = CompilerBlock();
	vector<string> Keys;
	map<string, json> JsonPoints;

	Result.ProgramName = JsonArray["ProgramName"].get<string>();
	Result.MinimumCompiledPoints = JsonArray["MinimumCompiledPoints"].get<int>();
	JsonPoints = JsonArray["Points"].get<map<string, json>>();

	for (const auto& [key, _] : JsonPoints) {
    	Keys.push_back(key);
	}

	Result.Points = map<string, CompilerPoint>();
	for (size_t i; i < Keys.size(); i++) {
		Result.Points[Keys[i]] = GetCompilerPoint(JsonPoints[Keys[i]]);
	}

	return Result;
}

vector<CompilerBlock> GetCompilerBlocks() {
	fstream File;
	json JsonArray;
	vector<fs::path> BlocksDirs;
	vector<CompilerBlock> Result;
	fs::path MainPath = fs::path("CompilerPoints");
	//maxsssssssss: Да, да я вообще не понимаю что это унга-бунга означает :) ->
	std::copy(fs::directory_iterator(MainPath), fs::directory_iterator(), std::back_inserter(BlocksDirs));

	Result = vector<CompilerBlock>(BlocksDirs.size());
	for (size_t i = 0; i < Result.size(); i++) {
		File.open(BlocksDirs[i]);
		File >> JsonArray;
		Result[i] = GetCompilerBlock(JsonArray, MainPath.string());
		File.close();
		JsonArray.clear();
	}
	return Result;
}