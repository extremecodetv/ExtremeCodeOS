#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef long long S64;
/* Minimal difference for the array memory reallocation. */
#define _MIN_DIFF 64
#define _DEFAULT_SIZE 1024


int main() {
    S64 _size = _DEFAULT_SIZE;
    char* buffer = (char*)malloc(_DEFAULT_SIZE);
    memset(buffer, 0, sizeof(buffer));

    printf("\n Enter random number: ");

    char c;
    S64 i;
    /* Dynamic array, the only limit is memory. */
    for (i = 0; (c = getchar()) != EOF && c != '\n'; i++) {
        if (c < '0' || c > '9') {
            fprintf(stderr, "Bad input!\n");
            exit(0);
        }
        buffer[i] = c;
        if (sizeof(buffer)-i <= _MIN_DIFF) {
            _size += _DEFAULT_SIZE;
            buffer = (char*)realloc(buffer, _size);
        }
    }
    buffer[i] = EOF;

    int mod = 1;
    char last = ' ';

    for (S64 j = i-1; j >= 0; j--) {
        int res = (buffer[j] - '0') + mod;
        mod = res/10;
        buffer[j] = (res%10) + '0';
        if (res < 10)
            break;
        if (res >= 10 && j == 0)
            last = mod + '0';
    }


    printf("\nYou lose. My number is bigger than yours: %c%s\n", last, buffer);
    fflush(stdin);

    printf("Want to play one more time? (Enter 1): ");
    /* Here need to implement more correct the \n control. */
    int ans;
    char l;
    scanf(" %d%c", &ans, &l);

    if (ans == 1) {
        fflush(stdin);
        free(buffer);
        main();
    }

    return 0;
}
