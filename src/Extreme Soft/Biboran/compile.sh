#!/usr/bin/bash
gcc biboran.c -O3 -o biboran `pkg-config --cflags --libs gtk+-3.0`
