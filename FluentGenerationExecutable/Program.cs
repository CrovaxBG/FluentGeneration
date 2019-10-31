using System;
using FluentGeneration;

namespace FluentGenerationExecutable
{
    class Program
    {
        static void Main(string[] args)
        {
            new GenerationBuilder().DefineClass();
            Console.WriteLine("Hello World!");
        }
    }
}
