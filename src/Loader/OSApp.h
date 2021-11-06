#pragma once

#include "AccessLevels.h"
#include <string>

using namespace std;

class OSApp {
private:
	int accessLevelForApp;
	
public:
	string appName;

	virtual void runApp() {}
	bool testAccessLevel(int accessLevel) {
		return accessLevel >= accessLevelForApp;
	}

	OSApp(string name, int accessLevel) {
		appName = name;
		accessLevelForApp = accessLevel;
	}OSApp() {}
};