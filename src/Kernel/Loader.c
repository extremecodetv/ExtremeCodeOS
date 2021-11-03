#include "stdio.h"
#include "string.h"
#include "stdlib.h"

int main(int argc, char** argv) {
    int input;

    printf("1. Run kernel.\n");
    printf("2. Run UI.\n");
    printf("3. Exit.\n");

    scanf("%d", &input);

    switch (input)
    {
        case 1:
            Run()
            break;
        
        case 2:
            printf("Sorry.\n");
            scanf("%d", &input);
            quit(0);
            break;
        
        case 3:
            quit(0);
            break;
    }
}

int Run() {

}