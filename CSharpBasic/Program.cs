// A C# console application to demonstrate fundamental programming concepts.

using System;
using System.Linq;
using System.Numerics;

public class Program
{
    // The main entry point of the application.
    public static void Main(string[] args)
    {

        // Call each function to demonstrate a specific concept.
        DemonstrateSyntax();
        DemonstrateTypeBasics();
        DemonstrateNumericTypes();
        DemonstrateBooleanAndOperators();
        DemonstrateStringsAndCharacters();
        DemonstrateArrays();
        DemonstrateVariablesAndParameters();
        DemonstrateExpressionsAndOperators();
        DemonstrateNullOperators();
    }

    // This function should demonstrate basic C# syntax.
    public static void DemonstrateSyntax()
    {
        Console.WriteLine("\n--- 1. C# Syntax ---");
        Console.WriteLine("Hello World!");
    }

    // This function should demonstrate the difference between value types and reference types.
    public static void DemonstrateTypeBasics()
    {
        Console.WriteLine("\n--- 2. Type Basics ---");
        // Your task:
        // 1. Declare an integer (int), which is a value type.
        // 2. Declare a string (string), which is a reference type.
        // 3. Print the value of each variable to the console.

        int someNumber = 0;
        string someWord = "Rosebud";

        Console.WriteLine(someNumber);
        Console.WriteLine(someWord);

    }

    // This function should demonstrate various numeric data types.
    public static void DemonstrateNumericTypes()
    {
        Console.WriteLine("\n--- 3. Numeric Types ---");
        // Your task:
        // 1. Declare an integer (int) and assign it a whole number.
        // 2. Declare a double and assign it a decimal number.
        // 3. Declare a decimal and assign it a decimal number with the 'm' suffix.
        // 4. Print the value of each variable to the console, clearly labeling each one.

        int wholeNumber = 0xff;
        double fractionValue = 0.3;
        decimal decimalNumber = 54.4M;

        Console.WriteLine($"Whole Number {wholeNumber}; Fraction {fractionValue}; Decimal Number {decimalNumber}");
    }

    // This function should demonstrate boolean type and logical operators.
    public static void DemonstrateBooleanAndOperators()
    {
        Console.WriteLine("\n--- 4. Boolean Type and Operators ---");
        // Your task:
        // 1. Declare two boolean variables, one set to true and one to false.
        // 2. Use the logical AND (&&) operator to combine them and print the result.
        // 3. Use the logical OR (||) operator to combine them and print the result.
        // 4. Use the logical NOT (!) operator on one of the variables and print the result.

        bool booleanTrue = true;
        bool booleanFalse = false;

        Console.WriteLine($"true AND false: {booleanTrue && booleanFalse}");
        Console.WriteLine($"true OR false: {booleanTrue || booleanFalse}");
        Console.WriteLine($"NOT (true AND false): {!(booleanTrue && booleanFalse)}");
        
        
    }

    // This function should demonstrate string and character manipulation.
    public static void DemonstrateStringsAndCharacters()
    {
        Console.WriteLine("\n--- 5. Strings and Characters ---");
        // Your task:
        // 1. Declare a character variable (char) with a single letter.
        // 2. Declare two string variables.
        // 3. Use string concatenation to combine them.
        // 4. Use string interpolation to combine them in a new way.
        // 5. Print the length of one of the strings.

        char singleLetter = '\u2048';
        Console.WriteLine(singleLetter);
        string stringOne = "Hello";
        Console.WriteLine($"String number one {stringOne}");
        string stringTwo = "World!!";
        Console.WriteLine($"String number two {stringTwo}");

        string stringOneTwo = $"{stringOne}{stringTwo}";

        Console.WriteLine($"Length of the Combined String: {stringOneTwo.Length}");

    }

    // This function should demonstrate how to declare, initialize, and access arrays.
    public static void DemonstrateArrays()
    {
        Console.WriteLine("\n--- 6. Arrays ---");
        // Your task:
        // 1. Declare an array of integers and initialize it with three numbers.
        // 2. Access and print the first element of the array.
        // 3. Declare an array of strings and initialize it with three names.
        // 4. Use a loop (like a `for` or `foreach` loop) to print every name in the array.

        int[,] identityMatrix = new int[3, 3]{
            {1, 0, 0},
            {0, 1, 0},
            {0, 0, 1}
        };

        Console.WriteLine($"First Element ([1, 1]): {identityMatrix[0, 0]}");
        for (int i = 0; i < 3; i++){
            for (int j = 0; j < 3; j++){
                Console.WriteLine(identityMatrix[i, j]);
            }
        }



    }

    // This function should demonstrate the use of variables and method parameters.
    public static void DemonstrateVariablesAndParameters()
    {
        Console.WriteLine("\n--- 7. Variables and Parameters ---");
        // Your task:
        // 1. Declare two integer variables inside this function.
        // 2. Create a new helper method (e.g., `Multiply`) that takes two integer parameters.
        // 3. Call your new helper method from this function, passing in the variables.
        // 4. Print the result returned from your helper method.
        int integerVariablesOne = 10;
        int integerVariablesTwo = 5;

        Console.WriteLine(Division(integerVariablesOne, integerVariablesTwo));

        // Bad practice tapi disuruh AI
        double Division (int baseNumber, int divisorNumber){
            return baseNumber / divisorNumber;
        }
    }

    // This function should demonstrate various expressions and operators.
    public static void DemonstrateExpressionsAndOperators()
    {
        Console.WriteLine("\n--- 8. Expressions and Operators ---");
        // Your task:
        // 1. Declare two integer variables, `a` and `b`.
        // 2. Use `a` and `b` to demonstrate the following arithmetic operators: +, -, *, /, and %. Print the result of each operation.
        // 3. Use `a` and `b` to demonstrate a few comparison operators, like `==` and `>`. Print the boolean result of each comparison.
        int integerA = 12;
        int integerB = 6;

        Console.WriteLine($"A + B = {integerA + integerB}");
        Console.WriteLine($"A - B = {integerA + integerB}");
        Console.WriteLine($"A / B = {integerA + integerB}");
        Console.WriteLine($"A * B = {integerA + integerB}");
        Console.WriteLine($"A < B ? {integerA < integerB}");
    }

    // This function should demonstrate the null-coalescing and null-conditional operators.
    public static void DemonstrateNullOperators()
    {
        Console.WriteLine("\n--- 9. Null Operators ---");
        // Your task:
        // 1. Declare a string variable and set its value to `null`.
        // 2. Declare a second string variable with a default value (e.g., "Unknown").
        // 3. Use the null-coalescing operator (??) to assign the default value to a third variable if the first is null. Print the result.
        /* 4. Use the null-conditional operator (?.) to safely access the `.Length` 
            property of the first string. Use the null-coalescing operator (??) 
            on the result to provide a default value (e.g., 0). Print the result.
        */

        string stringOfNull = null;
        string defaultString = "Unknown";

        Console.WriteLine($"Lentgh of string of null = {stringOfNull?.Length}");
        Console.WriteLine($"Value of string of null = {stringOfNull ?? defaultString}");

    }
}
