using MyFileClass;
using System;

namespace ConsoleForTestingFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing File.ReadAllLines: ");
            Console.WriteLine();

            var lines = File.ReadAllLines("testFile.txt");

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("Press <enter> to test File.ReadAllText.");
            Console.ReadLine();

            Console.WriteLine("Testing File.ReadAllText: ");
            Console.WriteLine();

            var text = File.ReadAllText("testFile.txt");
            Console.WriteLine(text);

            Console.ReadLine();
        }
    }
}
