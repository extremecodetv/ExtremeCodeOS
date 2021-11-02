#include "stdio.h"
#include "string.h"

#define BUFSIZE 1024

int main()
{
    char exit[] = "exit";
    char ls[] = "ls";
    char echo[] = "echo";

    printf("\n\nWelcome to ExtremeOS Terminal\n\n");

    char buffer[BUFSIZE];

    for (;;) {
        printf ("C:/home/dekstop $ ");
        fflush (stdout);
        gets(buffer);
        
        if (strcmp(ls, buffer) == 0) 
        {
            printf("--r--w--r admin admin 3.6GB porn\n");
            printf("--r--w--r admin admin 53KB kernel.c\n");
            printf("--r--w--r admin admin 53KB GTAV.exe\n");
        };

        if (memcmp(echo, buffer, strlen(echo)) == 0) 
        {
            buffer[BUFSIZE] = '\0';
            printf("%s\n", buffer + 5);
        } 
        else if (memcmp(exit, buffer, strlen(exit)) == 0) 
        {
            break;
        }
    } 

    return 0;
}
