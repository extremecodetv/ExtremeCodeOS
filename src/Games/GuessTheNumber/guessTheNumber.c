#include <time.h>
#include <stdio.h>
#include <stdlib.h>
#include <inttypes.h>

int main()
{
    srand(time(NULL));
    
    printf("Choose difficulty (from 1 to 32767): ");
    
    short difficulty;
    scanf("%hi", &difficulty);
    
    if(difficulty <= 0) {
        printf("You lose :(");
        return 0;
    }
    
    auto int64_t num = 0, left = difficulty * (rand() % 100), right = difficulty * (left + (rand() % 100)), guessed = rand() % (right - left) + left;
    
    printf("Guess number from %" PRId64 " to %" PRId64 "!\n", left, right - 1);
    
    while(num != guessed) {
        scanf("%" PRId64, &num);
        
        if(num > guessed) {
            printf("Guessed number is lower. Try again!\n");
        }
        else if(num < guessed) {
            printf("Guessed number is bigger. Try again!\n");
        }
    }
    
    printf("Congartulations! You won!!!");
    return 0;
}
