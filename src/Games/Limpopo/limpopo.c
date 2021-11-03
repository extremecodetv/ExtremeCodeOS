#include <stdio.h>
#include <inttypes.h>

int main() {
    auto uint64_t num;
    printf("\n Enter random number: ");

    scanf("%d", &num);
    printf("\n You lose. My number is bigger than yours: %d", num + 1);

    printf("\n \n Want to play one more time? (Enter 1): ");

    printf("\n");
    int fin;
    scanf("%d", &fin);

    if (fin == 1){
        return main();
    }
    return 0;
}
