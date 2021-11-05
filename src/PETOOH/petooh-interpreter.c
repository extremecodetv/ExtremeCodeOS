/* *********************************************
 *  THIS SOFTWARE IS A PART OF ExtremeCodeOS
 *  Created by Nikita_Bunikido
 *  2021
 * 
 *  compile with gcc:
 * 	    gcc petooh-interpreter.c -O1 -o pth
 * 
 * ********************************************/

#include "stdio.h"
#include "stdlib.h"
#include "stdbool.h"
#include "string.h"

#define MAX_BUFFER      2048
#define __VERSION       "0.0.1 beta"

bool Wall = false;

struct {
    const long cells_num;
    unsigned char* cells;
} main_buffer = {30000, NULL};

long pointer = 0;
long current_program_pointer = 0;

typedef enum {
    MOVE_RIGHT,
    MOVE_LEFT,
    OUTPUT,
    BEGIN_WHILE,
    END_WHILE,
    INCREMENT,
    DECREMENT
} action;

action system_program[100000];

static const char* commands[] = {
    "Kudah",
    "kudah",
    "Kukarek",
    "Kud",
    "kud"
};

#define __PETOOH_IMPLEMENTATION
#include "include\PETOOHAPI.h"

int main(int argc, char** argv){
    char exit_code;
    if (argc < 2)
        help();

    if (argc > 2 && !strcmp("--Wall", argv[2]))
        Wall = true;
    if (argc >= 2 && !strcmp("--version", argv[1])){
        printf("\npth.exe (PTH) v%s (C) Nikita-Bunikido\n", __VERSION);
        printf("PETOOH interpreter for \'ExtremeCodeOS\'\n");
        printf("-2021\n\n");
        exit(0);
    }
    
    char* buffer = (char*)malloc(sizeof(char) * MAX_BUFFER);
    if(exit_code = read_prog(buffer, argv[1]))
        switch (exit_code){
        case 1:
            error("can't open the file.", true);
            break;
        case 2:
            error("buffer overflow.", true);
            break;
        }
    
    exit_code = interprite(buffer);
    printf("\n    interpretation ended with exit code [0x%d]\n    ", exit_code ? 1 : 0);
    system("pause");
    return exit_code;
}