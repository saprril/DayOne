using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // Noise.FromOutside();
            Noise noiseVariable = new Noise();
            noiseVariable.FromOutside();
        }
    }

}