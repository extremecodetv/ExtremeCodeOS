#pragma once

#include "Game.h"
#include "Account.h"
#include "Program.h"
#include "OSApp.h"
#include "TicTacToe.h"
#include "AccessLevels.h"
#include "Kernel.h"


class Data {
public:
	static const int accountsCount = 1;
	static const int gamesCount = 1;
	static const int programsCount = 1;

	Account accounts[accountsCount] = {
		Account("admin", "admin", ADMIN)
	};
	Account currectAccount;

	Game *games[gamesCount] = {
		new TicTacToeGame()
	};
	Program* programs[programsCount] = {
		new Kernel()
	};

	Data() {}
};