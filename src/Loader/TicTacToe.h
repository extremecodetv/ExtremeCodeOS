#pragma once

#include <cstdio>

class TicTacToeGame : public Game {
public:
	TicTacToeGame() : Game("Tic Tac Toe!") {}

	void runApp() override {
		system("Games/TicTacToe/TicTacToe");
	}
};