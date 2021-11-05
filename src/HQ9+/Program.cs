using System.ComponentModel.Design;
using System.Collections.Generic;
using System;

namespace HQ9_
{
    class Program
    {
        delegate void Func();
        static void WriteSong() {
            for(int i = 99; i > 1; i--) {
                Console.WriteLine($"{i} bottles of beer on the wall, {i} bottles of beer");
                Console.WriteLine($"Take one down and pass it around, {i-1} bottles of beer on the wall");
            }
            Console.WriteLine("1 bottle of beer on the wall, 1 bottle of beer");
            Console.WriteLine("Take one down and pass it around, no bottles of beer on the wall");
        }
        static void Main(string[] args)
        {
            Console.Write("Enter source code: ");
            string source = Console.ReadLine();

            int reg = 0;

            var commands = new Dictionary<char, Func> {
                {'H', () => Console.WriteLine("Hello, World!")},
                {'Q', () => Console.WriteLine(source)},
                {'9', () => WriteSong()},
                {'+', () => reg++}
            };

            foreach(char c in source.ToUpper()){
                if(!commands.ContainsKey(c)){
                    Console.WriteLine($"Syntax error: Unknown character \'{c}\'");
                    return;
                }
                commands[c]();
            }
        }
    }
}
