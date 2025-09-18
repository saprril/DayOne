using System.Numerics;
using System.Globalization;

namespace Day7FormattingParsingConverting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Parse and TryParse
            string stringNumber = "123";

            int intNumber = int.Parse(stringNumber);
            bool tryIntNumber = int.TryParse(stringNumber, out int output);

            Console.WriteLine(intNumber * 2);

            Console.WriteLine(tryIntNumber);
            Console.WriteLine(output);

            // Culture Sensitivity
            double usDouble = double.Parse("1.234", CultureInfo.GetCultureInfo("en-US"));
            Console.WriteLine(usDouble / 10);
            
            


        }


        // Custom Format Provider

    }

}