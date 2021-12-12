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

    for (size_t i2 = 0; i2 < String.size(); i2++) {
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

int RunCommands(CompilerPoint Point, CompilerType CorrectType, string ProgramName) {
    vector<string> CommandPart;
    vector<string> Temp;
    string ResultCommand;

    for (size_t i = 0; i < CorrectType.CompilCommands.size(); i++) {

        CommandPart = Split(CorrectType.CompilCommands[i], '{');
        ResultCommand = string();
        ResultCommand.append(CommandPart[0]);
        for (size_t i2 = 1; i2 < CommandPart.size(); i2++) {
            Temp = Split(CommandPart[i2], '}');
            ResultCommand.append(Point.CompilerData[Temp[0]]);
            ResultCommand.append(Temp[1]);
        }

        ResultCommand.append(" > nul 2>> Logs/Error");
        ResultCommand.append(ProgramName);
        ResultCommand.append(".log");

        if (system(ResultCommand.c_str()) != 0) {
            return 0;
        }

    }

    return 1;
}

int CompilCompilerPoint(vector<CompilerType> &CompilerTypes, CompilerPoint Point, string ProgramName) {
    CompilerType CorrectType;
    string ResultCommand;
    vector<string> CommandPart;
    vector<string> Temp;
    string CompilCommand;
    bool FoundCorrectType = false;
    bool InName = false;
    string Name;

    for (size_t i = 0; i < CompilerTypes.size(); i++) {
        if (CompilerTypes[i].Name == Point.CompilerType) {
            CorrectType = CompilerTypes[i];
            FoundCorrectType = true;
        }
    }

    if (!FoundCorrectType) {
        Log(ERROR, "В программе " + ProgramName + " указан некорректный тип компиляции!", "Не удалось скомпилировать: " + ProgramName);
        return 0;
    }

    for (size_t i = 0; i < CorrectType.Args.size(); i++) {
        if (Point.CompilerData.find(CorrectType.Args[i]) == Point.CompilerData.end()) {
            Log(ERROR, "В программе " + ProgramName + " отсутствуют требуемые аргументы для компиляции!", "Не удалось скомпилировать " + ProgramName);
            return 0;
        }
    }

    return RunCommands(Point, CorrectType, ProgramName);
}

int CompilCompilerBlock(vector<CompilerType> &CompilerTypes, CompilerBlock Block) {
    vector<string> CompilerPointsNames = {"main"};
    vector<string> Temp = vector<string>();
    size_t OldSize;
    int CompiledPoints = 0;

    while (CompilerPointsNames.size()) {
        Temp = vector<string>(0);

        for (size_t i = 0; i < CompilerPointsNames.size(); i++) {
            if (Block.Points.find(CompilerPointsNames[i]) == Block.Points.end()) {
                Log(ERROR, "Не удалось найти точку компиляцию по имени " + CompilerPointsNames[i] + " в программе " + Block.ProgramName, "Не удалось скомпилировать программу " + Block.ProgramName);
            } else {
                if (CompilCompilerPoint(CompilerTypes, Block.Points[CompilerPointsNames[i]], Block.ProgramName)) {
                    CompiledPoints++;
                    OldSize = Temp.size();
                    Temp.resize(Block.Points[CompilerPointsNames[i]].IfSuccessful.size() + OldSize);
                    for (size_t i = 0; i < Block.Points[CompilerPointsNames[i]].IfSuccessful.size(); i++) {
                        Temp[OldSize + i] = Block.Points[CompilerPointsNames[i]].IfSuccessful[i];

                    }
                } else {
                    OldSize = Temp.size();
                    Temp.resize(Block.Points[CompilerPointsNames[i]].IfFailed.size() + OldSize);
                    for (size_t i = 0; i < Block.Points[CompilerPointsNames[i]].IfFailed.size(); i++) {
                        Temp[OldSize + i] = Block.Points[CompilerPointsNames[i]].IfFailed[i];

                    }
                }
            }
        }

        CompilerPointsNames = Temp;
    }

    if (Block.MinimumCompiledPoints <= CompiledPoints) {
        Log(SUCESSFULL, "Скомпилировано " + to_string(CompiledPoints) + " из " + to_string(Block.Points.size()) + " точек, в программе " + Block.ProgramName, "Скомпилированна программа " + Block.ProgramName);
        return 1;
    }
    else {
        Log(ERROR, "Скомпилировано " + to_string(CompiledPoints) + " из " + to_string(Block.Points.size()) + " (минимум для удачной компиляции " + to_string(Block.MinimumCompiledPoints) + " ) точек,  в программе " + Block.ProgramName, "Недастаточно скомпилировано точек компиляции, в программе " + Block.ProgramName);
        return 0;
    }
}

int main()
{
    system("chcp 65001 > nul 2> nul");
    system("mkdir Logs > nul 2> nul");
    system("del Logs\\* / S / Q > nul 2> nul");
    setlocale(LC_ALL, "Russia");

    int CompiledPrograms = 0;
    vector<CompilerType> CompilerTypes;
    vector<CompilerBlock> CompilerBlocks;

    CompilerBlocks = GetCompilerBlocks();
    CompilerTypes = GetCompilerTypes();

    for (size_t i = 0; i < CompilerBlocks.size(); i++) {
        CompilCompilerBlock(CompilerTypes, CompilerBlocks[i]);
    }

    cout << endl << string(10, '-') << endl << "Удачно: " << CompiledPrograms << endl << "Не удалось: " << static_cast<int>(CompilerBlocks.size()) - CompiledPrograms << endl << string(10, '-') << endl;
    
    Close();
    //getchar();
    return 0;
}