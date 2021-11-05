/* *********************************************
 *  THIS SOFTWARE IS A PART OF ExtremeCodeOS
 *  Created by Nikita_Bunikido
 *  2021
 * 
 *  compile with gcc:
 * 	    gcc runner.c -O1 -o runner
 * 
 * ********************************************/

#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <conio.h>
#include <malloc.h>
#include <time.h>

#ifdef _WIN32 
	#include "windows.h"
	void sleep(unsigned int milliseconds){
		Sleep(milliseconds);
	}

#else
	#include "unistd.h"
	void sleep(unsigned int milliseconds){
		u_sleep((int)(milliseconds / 1000.0f));
	}
#endif

#define ROAD_LEN	30
#define ROAD_CHAR	'_'
#define ROADS		3

#define BLOCK_COUNT		7
#define BLOCK_DISTANCE	28

#define SCORE_STREAM "score.txt"

const char* game_over_message = "GAME OVER!\n";
char block_app[] = {219, 178, 177, 176, 202, 186, 184, 64};
long t = 0;
long _sleep_time = 45;

enum key_bd {
	UP =   72,
	DOWN = 80
};

struct block {
	COORD pos;
	char character;
};

struct {
	long road;
	long offset;
	long score;
	char character;
} player = {0, 3, 0, '#'};

struct block* blocks[BLOCK_COUNT] = {NULL};

struct block* create_block(COORD pos){
	struct block* r = (struct block*)malloc(sizeof(struct block));
	r->pos = pos;
	r->character = (char)block_app[rand()%(sizeof(block_app) / sizeof(block_app[0]))];
	return r;
}

void destruct_block(struct block* b){
	free(b);
	return;
}

static void move_blocks(void){
	for (int i = 0; i < BLOCK_COUNT; i++){
		blocks[i]->pos.X--;
		if (blocks[i]->pos.X < 0){
			blocks[i]->pos.X = ROAD_LEN;
			blocks[i]->pos.Y = rand()%3;
		}
	}
	return;
}

static int block_drawing(int _x, int _y){
	for (int i = 0; i < BLOCK_COUNT; i++)
		if (_x == blocks[i]->pos.X && _y == blocks[i]->pos.Y)
			return i;
	return -1;
}

static bool game_over_check(void){
	for (int i = 0; i < BLOCK_COUNT; i++)
		if ((player.offset == blocks[i]->pos.X-1 &&
			player.road == blocks[i]->pos.Y) ||
			(player.offset == blocks[i]->pos.X   &&
			player.road == blocks[i]->pos.Y))
			return true;
	return false;
}

static void print_screen(void){
	int p;
	SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), (COORD){0, 0});
	for (int j = 0; j < ROADS; j++){
		for (int i = 0; i < ROAD_LEN; i++){
			if (j == player.road && i == player.offset)
			putchar(player.character);
			else if ((p = block_drawing(i, j)) != -1)
				putchar(blocks[p]->character);
			else
			putchar(ROAD_CHAR);
		}
		putchar(0xA);
	}
	printf("SCORE - %d\n", player.score);
	return;
}

static void user_input(char in){
	switch (in){
		case UP:
			player.road -= (player.road > 0) ? 1 : 0;
			break;
		case DOWN:
			player.road += (player.road < ROADS-1) ? 1 : 0;
			break;
	}	
	return;
}

static bool user_input_menu (){
	auto char c;
	FILE* f = NULL;
	__menu:
	system("cls");
	printf("ExtremeCodeOS runner\n");
	printf("p - [play]\n");
	printf("e - [exit]\n");
	printf("s - [settings]\n> ");

	scanf("\n%c", &c);

	switch (c) {
	case 'p':
		return false;
	case 'e':
		return true;
	case 's':
		system("cls");
		printf("Settings tab\n");
		printf("c - [change player] - \'%c\'\n", player.character);
		printf("s - [clear high score]\n");
		printf("r - [return to menu]\n> ");

		scanf("\n%c", &c);
		switch (c) {
		case 'c':
			printf("old player - \'%c\'\nnew player - ", player.character);
			scanf("\n%c", &player.character);
			printf("character changed.\n");
			sleep(300);
			goto __menu;
			break;
		case 's':
			f = fopen(SCORE_STREAM, "w");
			fprintf(f, "0");
			fclose(f);
			printf("high score cleaned.\n");
			sleep(300);
			goto __menu;
			break;
		case 'r':
			goto __menu;
		}
		return false;
	}
	return false;
}

int main(int argc, char** argv){
	char c = 1;
	srand(time(NULL));

	if (user_input_menu())
		exit(0);

	system("cls");

	FILE* stream = fopen(SCORE_STREAM, "r");

	bool down_press = false;
	bool up_press = false;

	for (int i = 0; i < BLOCK_COUNT; i++)
		blocks[i] = create_block((COORD){ROAD_LEN + rand()%BLOCK_DISTANCE, rand()%3});

#ifdef _WIN32
	while (!(GetKeyState('Q') < 0)) {
#else
	while (c != 'q') {
#endif
		print_screen();

		if(game_over_check()){
			fseek(stream, 0, 0);
			int best = 0;
			char prom[20];
			fgets(prom, 20, stream);
			best = atoi(prom);

			printf("\n%sBEST SCORE - %d\n", game_over_message, player.score > best ? player.score : best);
			
			if (player.score > best){
				fclose(stream);
				stream = fopen(SCORE_STREAM, "w");
				fprintf(stream, "%d", player.score);
				fclose(stream);
				stream = fopen(SCORE_STREAM, "r");
			}
			system("pause");
			exit(0);
		}

		c = 0;
		#ifdef _WIN32
		if (!(GetKeyState(VK_UP) < 0)) up_press = false;
		if (!(GetKeyState(VK_DOWN) < 0)) down_press = false;
		

		if (GetKeyState(VK_UP) < 0 && up_press == false){
			c = UP;
			up_press = true;
		}
		if (GetKeyState(VK_DOWN) < 0 && down_press == false){
			c = DOWN;
			down_press = true;
		}
		#else
			c = getch();
		#endif

		user_input(c);
		move_blocks();
		t++;
		player.score += !(t % 5) ? 1 : 0;
		if (player.score % 20 == 0)
			_sleep_time--;
		sleep(_sleep_time);
	}

	for (int i = 0; i < BLOCK_COUNT; i++)
		destruct_block(blocks[i]);
	fclose(stream);
	return 0;
}