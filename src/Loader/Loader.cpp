#include <cstdio>
#include <iostream>
#include <string>
#include "Account.h"
#include "Game.h"
#include "Program.h"
#include "Data.h"
#include "AccessLevels.h"

using namespace std;

Data programData;

void LogIn()
{
    string userName;
    string userPass;

    while (true) {
        //printf("Please enter user name:");
        //cin >> userName;
        //printf("Please enter password:");
        //cin >> userPass;

        userName = "admin";
        userPass = "admin";

        for (int i = 0; i < programData.accountsCount; i++) {
            if (programData.accounts[i].Name == userName and programData.accounts[i].TestPass(userPass)) {
                programData.currectAccount = programData.accounts[i];
                return;
            }
        }

        printf("Invalid password or name.\n");
    }
}

int Select(string Variants[], int VariantsCount) {
    int Result = VariantsCount + 1;

    while (Result > VariantsCount || 0 > Result) {
        for (int i = 0; i < VariantsCount; i++) {
            printf(to_string(i + 1).c_str());
            printf(". ");
            printf(Variants[i].c_str());
            printf("\n");
        }

        cin >> Result;
    }
    return Result - 1;
}

int main()
{
    system("cd ..");
    printf("Welcome to ExtremeCodeOS.\n");
    LogIn();

    printf("Select action:\n");

    while (true) {
        static const int actionCount = 3;
        string Variants[actionCount];
        string gamesNames[programData.gamesCount];
        string programsNames[programData.programsCount];
        int program;
        int game;

        Variants[0] = "Exit.";
        Variants[1] = "Run game.";
        Variants[2] = "Run program.";

        for (int i = 0; i < programData.gamesCount; i++) {
            gamesNames[i] = programData.games[i]->appName;
        }

        for (int i = 0; i < programData.programsCount; i++) {
            programsNames[i] = programData.programs[i]->appName;
        }

        switch (Select(Variants, actionCount))
        {
            case 0:
                return 0;

            case 1:

                printf("\nSelect game:\n");
                game = Select(gamesNames, programData.gamesCount);
                if (programData.games[game]->testAccessLevel(programData.currectAccount.GetAccessLevel())) {
                    printf("\n");
                    programData.games[game]->runApp();
                } else
                {
                    printf("Access denied!\n");
                }
                break;

            case 2:

                printf("\nSelect program:\n");
                program = Select(programsNames, programData.programsCount);
                if (programData.programs[program]->testAccessLevel(programData.currectAccount.GetAccessLevel())) {
                    printf("\n");
                    programData.programs[program]->runApp();
                }
                else
                {
                    printf("Access denied!\n");
                }
                break;
        }

        printf("\n");
    }
}