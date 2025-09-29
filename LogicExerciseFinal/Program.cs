using System.Collections;

namespace LogicExerciseFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello");


            FooBar fbController = new FooBar(3, "Foo");

            fbController.PrintNumber(10);
            fbController.AddRules(6, "bar");
            fbController.AddRules(5, "jazz");
            BitArray sampleBA = fbController.ModuloProcessor(30);

        }

        public int GetInput()
        {
            Console.WriteLine("Give me some number: ");

            string userInputtedNumber = Console.ReadLine() ?? "1";
            int userInputtedInteger = 0;
            if (Int32.TryParse(userInputtedNumber, out userInputtedInteger))
            {
                return userInputtedInteger;
            }
            else
            {
                return -1;
            }
        }
    }
}