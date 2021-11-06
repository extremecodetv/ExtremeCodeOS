#include "stdio.h"
#include "string.h"
#include "stdlib.h"

#define BUFSIZE 1024
#define COMMANDS_COUNT  7
#define WELCOME_MSG \
" _____     _                           _____           _       _____ _____ \n"\
"|  ___|   | |                         /  __ \\         | |     |  _  /  ___|\n"\
"| |____  _| |_ _ __ ___ _ __ ___   ___| /  \\/ ___   __| | ___ | | | \\ `--. \n"\
"|  __\\ \\/ / __| '__/ _ \\ '_ ` _ \\ / _ \\ |    / _ \\ / _` |/ _ \\| | | |`--. \\\n"\
"| |___>  <| |_| | |  __/ | | | | |  __/ \\__/\\ (_) | (_| |  __/\\ \\_/ /\\__/ /\n"\
"\\____/_/\\_\\___|_|  \\___|_| |_| |_|\\___|\\____/\\___/ \\__,_|\\___| \\___/\\____/ \n"\
"                                terminal v0.0.1\n"\                             

static const char* commands_arr[COMMANDS_COUNT] = {
    "exit",
    "ls",
    "echo",
    "clear",
    "touch",
    "rm",
    "neofetch",
};

typedef enum {
    E_SUCCESS,
    E_UNKNOWN,
    E_EMPTY
} req_exit_code_t;

typedef enum {
    C_EXIT,
    C_LS,
    C_ECHO,
    C_CLEAR,
    C_TOUCH,
    C_RM,
    C_NEOFETCH,
} command_t;

typedef struct {
    size_t size;
    char   input[BUFSIZE];
    command_t cm;
} terminal_req_t;

static terminal_req_t get_user_input (void){
    terminal_req_t __req = {BUFSIZE, "", -1};
    fflush (stdout);
    gets (__req.input);

    for (size_t i = 0; i < COMMANDS_COUNT; i++)
        if (!memcmp(commands_arr[i], __req.input, strlen(commands_arr[i]))){
            __req.cm = i;
            break;
        }
    
    return __req;
}

static req_exit_code_t terminal(terminal_req_t __req){
    char prom[BUFSIZE];
    FILE* info;
    FILE* file;
    switch (__req.cm){
    case C_EXIT:
        exit(0);
    case C_LS:
        printf("--r--w--r admin admin 3.6GB porn\n");
        printf("--r--w--r admin admin 53KB kernel.c\n");
        printf("--r--w--r admin admin 53KB GTAV.exe\n");
        break;
    case C_ECHO:
        __req.input[__req.size] = '\0';
        printf("%s\n", __req.input + strlen(commands_arr[C_ECHO]) + 1);
        break;
    case C_CLEAR:
        system("cls");
        break;
    case C_TOUCH:
        printf("^Z to complete operation.\n");
        strcpy(prom, "copy con area\\");
        strcat (prom, __req.input + strlen(commands_arr[C_TOUCH]) + 1);
        system(prom);
        break;
    case C_RM:
        strcpy(prom, "del area\\");
        strcat(prom, __req.input + strlen(commands_arr[C_RM]) + 1);
        system(prom);
        break;
    case C_NEOFETCH:
        info = fopen("res\\about.txt", "r");
        for(int i = 0, c = 0; (c = fgetc(info)) != EOF; ++i)
            putchar(c);
        fclose(info);
        putchar(0xA);
        break;
    default:
        return (*__req.input == '\0') ? E_EMPTY : E_UNKNOWN;
    }
    return E_SUCCESS;
}

int main(int argc, char** argv){
   printf(WELCOME_MSG);
   system("cd area");
   terminal_req_t rq = {0};

    for (;;) {
        printf ("area/: ~$ ");
        
        rq = get_user_input();
        switch (terminal(rq)) {
        case E_EMPTY:   ; break;
        case E_SUCCESS: ; break;
        case E_UNKNOWN: 
            printf("terminal error: unknown command: \"%s\"\n", rq.input);
            break;
        }
    } 

    return 0;
}
