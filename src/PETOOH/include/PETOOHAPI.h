/* *********************************************
 *  THIS SOFTWARE IS A PART OF ExtremeCodeOS
 *  Created by Nikita_Bunikido
 *  2021
 * ********************************************/

#ifndef __PETOOH_API
    #define __PETOOH_API

__PETOOH_API void help (void);
__PETOOH_API void error (char* text, bool critical);
__PETOOH_API char read_prog (char* prog, char* path);
__PETOOH_API bool is_char (char ch);
__PETOOH_API bool interprite (char* prog);

#if defined(__PETOOH_IMPLEMENTATION)

void help () {
    fprintf(stdout, "usage: pth <filename>");
    exit(1);
}

void error (char* text, bool critical){
    fprintf(stderr, "\nEPTA! %s: ", critical ? "error" : "warning");
    fprintf(stderr, text);
    if (critical)
        exit(1);
}

char read_prog (char* prog, char* path){
    FILE* pr = fopen(path, "r");
    if (NULL == pr) return 1;

    size_t i = 0;
    prog[i] = 1;

    do {
        if (i == MAX_BUFFER - 2)
            return 2;
        prog[i++] = fgetc(pr);
    } while (prog[i-1] != EOF);

    fclose(pr);
    prog[i] = '\0';
    return 0;
}

bool is_char(char ch){
    return ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'));
}

bool interprite(char* prog){
    main_buffer.cells = (unsigned char*)malloc(sizeof(unsigned char) * main_buffer.cells_num);
    for (int i = 0; i < main_buffer.cells_num; i++)
        main_buffer.cells[i] = 0;

    for (int i = 0; prog[i] != '\0'; i++){
        /* INCREMENTING - Ko*/
        if (prog[i] == 'K' && prog[i+1] == 'o'){
            i++;
            system_program[current_program_pointer++] = INCREMENT;
            continue;
        }

        /* DECREMENTING - kO */
        if (prog[i] == 'k' && prog[i+1] == 'O'){
            i++;
            system_program[current_program_pointer++] = DECREMENT;
            continue;
        }

        /*WORDS CHECKING*/
        if (is_char(prog[i])){
            char word[100];
            int j;
            for (j = i; is_char(prog[j]); ++j)
                word[j-i] = prog[j];
            word[j-i] = '\0';
            i+=strlen(word);

            for (int u = 0; u < 5; u++)
            if (!strcmp(word, commands[u]))
                system_program[current_program_pointer++] = u;

            //printf("%s\n", word);
        }
    }

    int num_of_in = 0;
    int p = 0;
    for (int i = 0; i < current_program_pointer; i++){
        switch (system_program[i]) {
        case MOVE_RIGHT:
            if (pointer < main_buffer.cells_num)
                ++pointer;
            else 
                error("pointer was outside right stack border.", true);
            break;
        case MOVE_LEFT:
            if (pointer > 0)
                --pointer;
            else
                error("pointer was outside left stack border.", true);
            break;
        case OUTPUT:
            fprintf(stdout, "%c", main_buffer.cells[pointer]);
            break;
        case BEGIN_WHILE:
            if (main_buffer.cells[pointer] != 0)
                ;
            else {
                int j = i;
                while (system_program[j] != END_WHILE)
                    j++;
                i = j;
            }
            break;
        case END_WHILE:
            if (main_buffer.cells[pointer] != 0){
                int j = i;
                while (system_program[j] != BEGIN_WHILE)
                    j--;
                i = j;
            }
            break;
        case DECREMENT:
            if (main_buffer.cells[pointer] == 0){
                if (Wall) error("decrementing 0. Setting to 255 automatically.", 0);   
                main_buffer.cells[pointer] = 255;
            }
            else
                --main_buffer.cells[pointer];
            break;
        case INCREMENT:
            if (main_buffer.cells[pointer] == 255){
                if (Wall) error("incrementing 255. Setting to 0 automattically.", 0);
                main_buffer.cells[pointer] = 0;
            }
            else
                ++main_buffer.cells[pointer];
            break;
        }
    }

    printf("\n\n\n    main buffer after interpretation:\n    ");
    for (int i = 0; i < 15; i++){
        printf("%2d ", main_buffer.cells[i]);
    }
    putchar(0xA);



    free(prog);
    free(main_buffer.cells);
    return 0;
}

#endif

#endif