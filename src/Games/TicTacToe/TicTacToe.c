/* *********************************************
 *  THIS SOFTWARE IS A PART OF ExtremeCodeOS
 *  Created by Nikita_Bunikido
 *  2021
 * 
 *  compile with gcc:
 * 	    gcc TicTacToe.c -O1 -o TicTacToe
 * 
 * ********************************************/

#include "stdio.h"
#include "stdlib.h"
#include "conio.h"
#include "time.h"

#define cells_x     3
#define cells_y     3

typedef struct {
    size_t _x;
    size_t _y;
} point;

int board[cells_x][cells_y] = {0};

static char get_char(int c){
    switch (c) {
    case 0:
        return 32;
    case 1:
        return 'X';
    case 2:
        return '0';
    }
}

static point user_input(void){
    char c;
    c = getch() - '1';
    for (int i = 0; i < cells_x; ++i)
        for (int j = 0; j < cells_y; ++j)
            if ((i + j * cells_x) == c)
                return (point){i, j};
    return (point){-1, -1};
}

static void print_board(void){
    for (int i = 0; i < cells_x; i++){
        for (int j = 0; j < cells_y; j++){
            putchar(get_char(board[j][i]));
            if (j != cells_y - 1)
                putchar('|');
        }
        putchar(0xA);
        if (i != cells_x - 1){
        for (int u = 0; u < cells_x * 2 - 1; u++)
            putchar('-');
        }
        putchar(0xA);
    }
}

static void ai(){
    point a = (point){rand()%cells_x, rand()%cells_y};

    while (board[a._x][a._y]){
        a._x = rand()%cells_x;
        a._y = rand()%cells_y;
    }
    board[a._x][a._y] = 2;
    return;
}

int check(int wh){
    int i, j, shx = 0, shy = 0;
    for(i = 0; i < 3; i++){
        shx = 0;
        for(j = 0; j < 3; j++){
            if(board[i][j] == wh)
                shx++;
            if(shx == 3)
                return 1;
        }
    }
    for(j = 0; j < 3; j++){
        shx = 0;
        for(i = 0; i < 3; i++){
            if(board[i][j] == wh)
                shx++;
            if(shx == 3)
                return 1;
        }
    }
    shx = shy = 0;
    for(i = 0; i < 3; i++){
        if(board[i][i] == wh) 
            shx++;
        if(board[i][2-i] == wh)
            shy++;
        if(shx == 3 || shy == 3)
            return 1;
    }
    return 0;
}

int nonecheck(void){
    int i, j;
    for(i = 0; i < 3; i++)
        for(j = 0; j < 3; j++)
            if(board[i][j] == 0)
                return 0;
    return 1;
}

int main(int argc, char** argv){
    srand(time(NULL));
    point ch = {0};
    while (ch._x != -1 && ch._y != -1){
        system("cls");
        print_board();
        ch = user_input();
        if (!board[ch._x][ch._y])
            board[ch._x][ch._y] = 1;
        
        if (check(1))   { system("cls"); print_board(); printf("X Win!\npress [enter] to exit\n");   getchar(); break; }
        if (check(2))   { system("cls"); print_board(); printf("0 Win!\npress [enter] to exit\n");   getchar(); break; }
        if (nonecheck()){ system("cls"); print_board(); printf("none Win!\npress [enter] to exit\n");getchar(); break; }
        ai();
    }
    return 0;
}