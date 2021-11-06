#pragma once

#include "OSApp.h"

using namespace std;

class Program : public OSApp {
public:

	Program(string name, int accessLevel) : OSApp(name, accessLevel) {}
	Program() : OSApp() {}
};