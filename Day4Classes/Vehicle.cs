namespace Day4Classes
{

    // This is the base code for your C# assignment.
    // Your task is to complete the sections marked with "TODO" and "Student's Task".
    // The comments will guide you on what needs to be implemented.

    using System;
    using System.Dynamic;

    // --- Abstract Class and Inheritance ---
    // This abstract class will serve as the base for all vehicles.
    // It uses fields, properties, and a constructor.
    public abstract class Vehicle
    {
        // A private field to store the color of the vehicle.
        private string _color;

        // A public property to access the color field.
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        // A public property to hold the make of the vehicle.
        public string Make { get; set; }

        // A public property to hold the model of the vehicle.
        public string Model { get; set; }

        public double FuelEcon { get; set; }

        public double TankCapacity{ get; set; }

        // The base constructor for the Vehicle class.
        public Vehicle(string make, string model, string color, double fuelEcon, double tankCapacity)
        {
            Make = make;
            Model = model;
            _color = color;
            FuelEcon = fuelEcon;
            TankCapacity = tankCapacity;
        }

        // --- Polymorphism & Virtual Function ---
        // This virtual method can be overridden by derived classes.
        public virtual void StartEngine()
        {
            Console.WriteLine($"The engine of the {Make} {Model} is starting...");
        }

        // --- Abstract Method ---
        // This abstract method must be implemented by all derived classes.
        public abstract void Drive();
    }

    // --- Student's Task: Complete the Car Class ---
    // This class inherits from Vehicle and should implement the ITransport interface.
    // TODO: Implement the ITransport interface correctly.
    public class Car : Vehicle, ITransport
    {
        // A custom indexer for the Car class.
        // TODO: Complete the indexer implementation to return information about a part.
        public string this[string part]
        {
            get
            {
                switch (part.ToLower())
                {
                    case "engine":
                        return "The powerhouse of the car.";
                    case "tires":
                        return "Four tires.";
                    case "exhaust":
                        return "Smoke 'em.";
                    default:
                        return "Part not found.";
                }
            }
        }

        // A private field to track the car's fuel level.
        private double _fuelLevel;

        // TODO: Create a constructor for the Car class that uses the 'base' keyword to call the parent constructor.
        // The constructor should also initialize the fuel level.
        public Car(string make, string model, string color, double fuelEcon, double tankCapacity) : base(make, model, color, fuelEcon, tankCapacity)
        {
            _fuelLevel = 50.0; // Starting with a half-tank
        }

        // --- Polymorphism & Method Overriding ---
        // TODO: Override the StartEngine() method to provide a unique message for a Car.
        public override void StartEngine()
        {
            Console.WriteLine($"Vroom! Vroom! You have started the {Color} {Model} {Make}");
        }

        // --- Abstract Method Implementation ---
        public override void Drive()
        {
            Random randomDistanceGenerator = new Random();

            double tankLitreage = TankCapacity * (_fuelLevel / 100);
            double maxDistance = tankLitreage * FuelEcon;

            double randomDrivingDistance = randomDistanceGenerator.Next(0, (int)maxDistance);
            double fuelConsumption = randomDrivingDistance / FuelEcon;

            _fuelLevel = ((tankLitreage - fuelConsumption) / TankCapacity) * 100;

            Console.WriteLine($"The Car {Color} {Make} {Model} is driving for {randomDrivingDistance} km, there are {_fuelLevel} percent remaining fuel.");
            Console.WriteLine($"{fuelConsumption} Liters consumed");

        }

        // --- Interface Method Implementation ---
        // TODO: Implement the Refuel() method from the ITransport interface.
        // This method should add fuel and print the new fuel level.
        public void Refuel(double amount)
        {
            Console.WriteLine($"This car ({Color} {Make} {Model}) is being refueled!");
            if (amount > 100 - _fuelLevel)
            {
                Console.WriteLine("The fuel tank is already full!");
                _fuelLevel = 100.0;
            }
            else if (amount < 0)
            {
                Console.WriteLine("Oops! Looks like you can't have negative number in real world");
            }
            else
            {
                _fuelLevel = _fuelLevel + amount;
                Console.WriteLine($"Now you have {_fuelLevel} percent of fuel");
            }
        }
    }

    // --- Student's Task: Complete the Motorcycle Class ---
    // This class also inherits from Vehicle and should implement the ITransport interface.
    // TODO: Implement the ITransport interface correctly.

    // --- Interface ---
    // The interface defines a contract that classes can adhere to.
    public interface ITransport
    {
        void Refuel(double amount);
    }
}