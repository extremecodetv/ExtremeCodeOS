#include<string.h>
#include<stdlib.h>
#include<stdio.h>

#define FAILED(CODE, msg)\
    do {\
        fprintf(stderr, msg);\
        fprintf(stderr, "\n");\
        return CODE;\
    } while(0)

#define CLOSE_AND_FAIL(fp, msg)\
    do {\
        fprintf(stderr, msg);\
        fprintf(stderr, "\n");\
        fclose(fp);\
        exit(-1);\
    } while(0)

enum __ERRS{ FAILED_BAD_COMMAND= -1, 
             FAILED_POINTER_BELOW_ZERO= -2,
             FAILED_POINTER_OVERFLOW= -3,
             FAILED_TO_PARSE= -4 };


int result(const char* proga) {
    char buffer[30000];
    memset(buffer, 0, sizeof(buffer));
    int current = 0;

    for (int i = 0; i < strlen(proga); i++) {
        switch(proga[i]) {
            case '>':
                current++;
                break;
            case '<':
                current--;
                break;
            case '+':
                buffer[current] = (buffer[current]+1)%256;
                break;
            case '-':
                buffer[current]--;
                if (buffer[current] < 0)
                    buffer[current] = 255;
                break;
            case '.':
                putchar(buffer[current]);
                break;
            case ',':
                buffer[current] = getchar();
                break;
            case '[':
                {
                int bal = 0, j = i;
                if (!buffer[current])
                    bal++;
                while(bal) {
                    j++;
                    if (j < strlen(proga) && proga[j] == '[')
                        bal++;
                    else if (j >= strlen(proga))
                        FAILED(FAILED_TO_PARSE, "] doesn't match.");
                    else if (proga[j] == ']')
                        bal--;
                    else
                        continue;
                    i = j;
                }
                }
                break;
            case ']':
                {
                int bal = 0, j = i;
                if (buffer[current])
                    bal++;
                while(bal) {
                    j--;
                    if (j >= 0 && proga[j] == ']')
                        bal++;
                    else if (j < 0)
                        FAILED(FAILED_POINTER_BELOW_ZERO, "Below zero.");
                    else if (proga[j] == '[')
                        bal--;
                    else
                        continue;
                    i = j;
                }
                }
                break;
            case '\n': case 0: case ' ':
                break;
            default:
                printf("%c\n", proga[i]);
                FAILED(FAILED_BAD_COMMAND, "Failed to interprete command. Probably ty pishesh hernyu.");
        }
        if (current < 0)
            FAILED(FAILED_POINTER_BELOW_ZERO, "Below zero.");
        else if (current >= 30000)
            FAILED(FAILED_POINTER_OVERFLOW, "Overflow.");
    }
end:
    return 0;
}

void help_usage() {
    puts("Usage: bf <filename>");
    exit(0);
}

int main(int argc, char** argv) {
    if (argc < 2)
        help_usage();
    
    FILE* file = fopen(argv[1], "r");
    if (file == NULL) {
        fprintf(stderr, "Fail to read file, probably it's doesn't exist.\n");
        exit(-1);
    }

    static char* buffer;
    if (fseek(file, 0L, SEEK_END) == 0) {
        long bs = ftell(file);
        if (bs == -1)
            CLOSE_AND_FAIL(file, "Failed to get buffer size!");

        buffer = (char*)malloc(sizeof(char) * (bs+1));
        if (fseek(file, 0L, SEEK_SET) != 0)
            CLOSE_AND_FAIL(file, "Failed to get back to the start of the file!");

        size_t nl = fread(buffer, sizeof(char), bs, file);
        if (ferror(file) != 0)
            CLOSE_AND_FAIL(file, "Failed to read from file!");
        else
            buffer[nl+1] = 0; 
    }
    fclose(file);
    
    int res = result(buffer);
    return 0;
}

