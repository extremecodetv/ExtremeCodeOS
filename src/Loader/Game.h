#pragma once

#include "OSApp.h"
#include "AccessLevels.h"

using namespace std;

class Game : public OSApp {
public:

	Game(string name) : OSApp(name, GAMER_USER) {}
	Game() : OSApp() {}
};
