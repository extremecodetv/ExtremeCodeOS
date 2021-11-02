#!/usr/bin/bash
gcc biboran.c -O3 -o test `pkg-config --cflags --libs gtk+-3.0`
