// See https://aka.ms/new-console-template for more information
using System.Text;


Console.WriteLine("Give me some number: ");

string userInputtedNumber = Console.ReadLine()??"1";
int userInputtedInteger = 0;

if (Int32.TryParse(userInputtedNumber, out userInputtedInteger))
{
    StringBuilder outputStringBuilder = new System.Text.StringBuilder();

    for (int i = 1; i < userInputtedInteger + 1; i++)
    {
        if (i % 3 == 0 && i % 5 == 0)
        {
            outputStringBuilder.Append("foobar");
        }
        else if (i % 3 == 0)
        {
            outputStringBuilder.Append("foo");
        }
        else if (i % 5 == 0)
        {
            outputStringBuilder.Append("bar");
        }
        else
        {
            outputStringBuilder.Append(i.ToString());
        }
        outputStringBuilder.Append(", ");
    }
    Console.WriteLine(outputStringBuilder.ToString().TrimEnd(' ', ','));
}
else
{
    Console.WriteLine("Nope!");
}

