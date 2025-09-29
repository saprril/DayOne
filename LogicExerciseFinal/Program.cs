using System.Collections;

namespace LogicExerciseFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello");


            FooBar MyClass = new FooBar();

            MyClass.AddRules(3, "foo");
            MyClass.AddRules(4, "baz");
            MyClass.AddRules(5, "bar");
            MyClass.AddRules(7, "jazz");
            MyClass.AddRules(9, "huzz");

            // MyClass.PrintNumber(24);
            int number = GetInput();
            if (number > 0)
            {
                MyClass.PrintNumber(number);
            }
            else
            {
                Console.WriteLine("Nope!");
            }

        }

        public static int GetInput()
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