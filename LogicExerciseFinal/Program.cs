namespace LogicExerciseFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello");

            FooBar fbController = new FooBar(3, "Foo");

            fbController.PrintNumber(10);
        }
    }
}