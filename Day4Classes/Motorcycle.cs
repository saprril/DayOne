namespace Day4Classes
{

    public struct RidingTime {
        public int hours;
        public int minutes;
        public int seconds;

        public RidingTime(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }
    }
    public class Motorcycle : Vehicle, ITransport
    {
        // A private field for the motorcycle's fuel level.
        private double _fuelLevel;
        private static readonly double _averageSpeed = 38.27;

        // TODO: Create a constructor for the Motorcycle class using the 'base' keyword.
        public Motorcycle(string make, string model, string color, double fuelEcon, double tankCapacity) : base(make, model, color, fuelEcon, tankCapacity)
        {
            _fuelLevel = 100.0; // Starting with a full tank
        }

        // TODO: Implement the abstract Drive() method with a custom message.
        public override void Drive()
        {
            Random randomDistanceGenerator = new Random();

            double tankLitreage = TankCapacity * (_fuelLevel / 100);
            double maxDistance = tankLitreage * FuelEcon;

            double randomRidingDistance = randomDistanceGenerator.Next(0, (int)maxDistance);

            var totalRidingTime = new RidingTime((int)(randomRidingDistance/_averageSpeed), 54, 3);

            double fuelConsumption = randomRidingDistance / FuelEcon;

            _fuelLevel = ((tankLitreage - fuelConsumption) / TankCapacity) * 100;
            Console.WriteLine($"Driving distance: {randomRidingDistance} kms");
            Console.WriteLine($"The {Color} {Make} {Model} bike is driving for {totalRidingTime.hours} hours {totalRidingTime.minutes} minutes {totalRidingTime.seconds} seconds");
            Console.WriteLine($"there are {_fuelLevel} percent remaining fuel.");
        }

        // --- Interface Method Implementation ---
        // TODO: Implement the Refuel() method from the ITransport interface.
        // This method should add fuel and print the new fuel level.
        public void Refuel(double amount)
        {
            Console.WriteLine($"This motorcycle ({Color} {Make} {Model}) is being refueled!");
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
                Console.WriteLine($"Now you have {_fuelLevel} percent of full tank");
            }
        }
    }
}