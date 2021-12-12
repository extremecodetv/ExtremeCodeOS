#include <map>
#include <string>
#include "CompilerPoint.h"

using namespace std;

struct CompilerBlock {
    map<string, CompilerPoint> Points;
    string ProgramName;
    int MinimumCompiledPoints;
};