using System.Text;

namespace LogicExercise2
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Give me some number: ");

            string userInputtedNumber = Console.ReadLine() ?? "1";
            int userInputtedInteger = 0;
            Func<int, string> numberProcessorDelegate = NumberProcessor;

            if (Int32.TryParse(userInputtedNumber, out userInputtedInteger))
            {
                List<string> stringSequence = FooBarProcessor(userInputtedInteger, numberProcessorDelegate);
                PrintArray(stringSequence);
            }
            else
            {
                Console.WriteLine("Nope!");
            }

        }
        public static void PrintArray<T>(List<T> arrayOfString)
        {
            StringBuilder outputString = new StringBuilder();

            foreach (T item in arrayOfString)
            {
                outputString.Append($"{item?.ToString()}, ");
            }
            if (outputString.Length > 0)
            {
                outputString.Length = outputString.Length - 2;
            }
            Console.WriteLine($"{outputString}");
        }

        

        public static List<string> FooBarProcessor(int value, Func<int, string> numPrcDelegate)
        {
            List<string> stringSequence = new List<string>();

            for (int i = 1; i < value + 1; i++)
            {
                string result = numPrcDelegate(i);
                stringSequence.Add(result);
            }

            return stringSequence;
        }

        /*
        Note to future me:
        If you want to add more divisor (e.g. 11: bla), 
        just add the label, enum, and mod operation to each corresponding type below
        */
        public static readonly string[] labels = { "foo", "bar", "jazz" }; // Number divisor label

        [Flags]
        public enum Divisibility : byte
        {
            /*
            Flag Enumerators of each divisor
            */
            None = 0, //000
            DivisibleBy3 = 1 << 0, //001
            DivisibleBy5 = 1 << 1, //010
            DivisibleBy7 = 1 << 2 // 100
        }

        public static Divisibility ModuloProcessor(int value)
        {
            /*
            A Function that returns the divisibility flag of an integer
            */
            Divisibility evaluation = Divisibility.None;

            if (value % 3 == 0)
            {
                evaluation |= Divisibility.DivisibleBy3;
            }
            if (value % 5 == 0)
            {
                evaluation |= Divisibility.DivisibleBy5;
            }
            if (value % 7 == 0)
            {
                evaluation |= Divisibility.DivisibleBy7;
            }

            return evaluation;
        }

        

        public static string FooBarJazzBuilder(byte flag)
        {
            /*
            A function that returns a string based on the flag and labels
            */
            StringBuilder decisionSb = new StringBuilder();

            for (int i = 0; i < labels.Length; i++)
            {
                if ((flag & (1 << i)) != 0)
                {
                    decisionSb.Append(labels[i]);
                }
            }

            return decisionSb.ToString();
        }

        public static string NumberProcessor(int value)
        {
            /*
            A function that connects FooBarJazzBuilder and ModuloProcessor
            */
            string result = "";
            if (ModuloProcessor(value) == Divisibility.None)
            {
                result = value.ToString();
            }
            else
            {
                result = FooBarJazzBuilder((byte)ModuloProcessor(value));
            }
            return result;
        }
    }

}
