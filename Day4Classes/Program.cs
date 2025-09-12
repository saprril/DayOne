namespace Day4Classes
{
    static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Vehicle Management System!");
            Console.WriteLine("---------------------------------------");

            // --- Task: Instantiate Classes and Call Methods ---

            // TODO: Create an instance of the Car class.
            // For example:
            Car whiteMustang = new Car("Ford", "Mustang", "White", 7.0, 60.6);
            Car silver900 = new Car("Saab", "900", "Silver", 10.2, 68.0);
            // TODO: Call the StartEngine() and Drive() methods for your car object.
            whiteMustang.StartEngine();
            whiteMustang.Drive();

            whiteMustang.Refuel(19);
            whiteMustang.Refuel(100);
            whiteMustang.Drive();

            // TODO: Use the indexer to get information about the car's parts and print them.
            // For example:
            // Console.WriteLine(myCar["engine"]);

            // TODO: Create an instance of the Motorcycle class.
            // For example:
            // Motorcycle myMotorcycle = new Motorcycle("Harley-Davidson", "Iron 883", "Black");

            // TODO: Call the StartEngine() and Drive() methods for your motorcycle object.

            // TODO: Call the Refuel() method on both your car and motorcycle objects.

            // --- Demonstrating Polymorphism ---
            Console.WriteLine("\n--- Demonstrating Polymorphism ---");
            // TODO: Create an array of type Vehicle and add your car and motorcycle instances to it.
            // Loop through the array and call the StartEngine() method on each object.
            // You should see the custom messages from each class.
        }
    }
}