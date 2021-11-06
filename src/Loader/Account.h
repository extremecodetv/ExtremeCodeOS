#pragma once

#include <string>

using namespace std;

class Account
{
public:
	string Name;

	Account() {}
	Account(string name, string pass, int AccessLevel) {
		Name = name;
		Password = pass;
		accessLevel = AccessLevel;
	}

	bool TestPass(string pass) {
		return Password == pass;
	}

	int GetAccessLevel() {
		return accessLevel;
	}

private:
	string Password = "";
	int accessLevel;
};