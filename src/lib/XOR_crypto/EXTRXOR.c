#include <stdio.h>
main(int argc,char**argv){
if(argc!=3)return 1;
FILE*f=fopen(argv[1],"r");
char b[0xFFFF];int i;
for(i=0;(b[i]=fgetc(f))!=EOF;b[i++]^=atoi(argv[2]));
b[i]='\0';
f=(fclose(f),f=fopen(argv[1],"w"));
return fprintf(f,"%s",b),fclose(f);
}