#include <iostream>
#include <string>
#include <vector>
#include <fstream>

using namespace std;

void loadWords(vector<string>& words);
bool userInputHandler(string& maskWord, const string& targetWord, char inputChar);

const vector<string> m_images
{
    {   },
    {
        "\n"
        "\n"
        "\n"
        "\n"
        "\n"
        "\n"
        "\n"
        "\n"
        "\n"
        "\n"
        "\n"
        " $$$$$$$$$$$$$$$$$$$$$$$$$$$$\n"
        " $                          $\n"
    },
    {
        "        $$$$$$$$$$$$$$$\n"
        "                      $\n"
        "                      $\n"
        "                      $\n"
        "                      $\n"
        "                      $\n"
        "                      $\n"
        "                      $\n"
        "                      $\n"
        "                      $\n"
        "                      $\n"
        " $$$$$$$$$$$$$$$$$$$$$$$$$$$$\n"
        " $                          $\n"
    },
    {
        "        $$$$$$$$$$$$$$$\n"
        "        |             $\n"
        "        |             $\n"
        "        |             $\n"
        "        |             $\n"
        "                      $\n"
        "                      $\n"
        "                      $\n"
        "                      $\n"
        "                      $\n"
        "                      $\n"
        " $$$$$$$$$$$$$$$$$$$$$$$$$$$$\n"
        " $                          $\n"
    },
    {
        "        $$$$$$$$$$$$$$$\n"
        "        |             $\n"
        "        |             $\n"
        "        |             $\n"
        "        |             $\n"
        "        O             $\n"
        "                      $\n"
        "                      $\n"
        "                      $\n"
        "                      $\n"
        "                      $\n"
        " $$$$$$$$$$$$$$$$$$$$$$$$$$$$\n"
        " $                          $\n"
    },
    {
        "        $$$$$$$$$$$$$$$\n"
        "        |             $\n"
        "        |             $\n"
        "        |             $\n"
        "        |             $\n"
        "        O             $\n"
        "      /   \\           $\n"
        "                      $\n"
        "                      $\n"
        "                      $\n"
        "                      $\n"
        " $$$$$$$$$$$$$$$$$$$$$$$$$$$$\n"
        " $                          $\n"
    },
    {
        "        $$$$$$$$$$$$$$$\n"
        "        |             $\n"
        "        |             $\n"
        "        |             $\n"
        "        |             $\n"
        "        O             $\n"
        "      / | \\           $\n"
        "        |             $\n"
        "                      $\n"
        "                      $\n"
        "                      $\n"
        " $$$$$$$$$$$$$$$$$$$$$$$$$$$$\n"
        " $                          $\n"
    },
    {
        "        $$$$$$$$$$$$$$$\n"
        "        |             $\n"
        "        |             $\n"
        "        |             $\n"
        "        |             $\n"
        "        O             $\n"
        "      / | \\           $\n"
        "        |             $\n"
        "       / \\            $\n"
        "                      $\n"
        "                      $\n"
        " $$$$$$$$$$$$$$$$$$$$$$$$$$$$\n"
        " $                          $\n"
    }
};

int main()
{
    srand(time(NULL));
    vector<string> words(0);
    loadWords(words);

    Replay:

    string targetWord = words[rand() % words.size()];
    string maskWord(targetWord.size(), '*');
    cout << targetWord << endl;
    int tryCount = 7;

    while(tryCount > 0)
    {
        cout << m_images[7 - tryCount];

        cout << "Mask word: " << maskWord << endl << endl;
        cout << "Input: ";
        char input;
        cin >> input;
        if(userInputHandler(maskWord, targetWord, input) == false){
            tryCount--;
        }
        else {
            cout << "You guessed the letter" << endl;
        }

        system("cls");
    }

    cout << m_images[7];

    cout << "Replay? (y/N): ";
    char choice;
    cin >> choice;

    if(choice == 'y') {
        goto Replay;
    } 
}

bool userInputHandler(string& maskWord, const string& targetWord, char inputChar)
{
    for(size_t i = 0; i < targetWord.size(); i++)
    {
        if(targetWord[i] == inputChar)
        {
            maskWord[i] = inputChar;
            return true;
        }
    }
    return false;
}

void loadWords(vector<string>& words)
{
    ifstream file("words.txt", ios::in | ios::binary);

    if (file.is_open())
    {
        string line;
        while (getline(file, line))
        {
            words.push_back(line);
        }
    }
}