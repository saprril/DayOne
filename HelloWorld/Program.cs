using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // Test.TestMethod();
            Test instanceOfTest = new Test();
            instanceOfTest.TestMethod();
        }
    }
   
   class Test
   {
       public void TestMethod()
       {
           Console.WriteLine("This is a test method.");
       }
   }
}