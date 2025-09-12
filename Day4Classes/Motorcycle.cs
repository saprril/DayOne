namespace Day4Classes
{


    public class Motorcycle : Vehicle, ITransport
    {
        // A private field for the motorcycle's fuel level.
        private double _fuelLevel;

        // TODO: Create a constructor for the Motorcycle class using the 'base' keyword.
        public Motorcycle(string make, string model, string color, double fuelEcon, double tankCapacity) : base(make, model, color, fuelEcon, tankCapacity)
        {
            _fuelLevel = 100.0; // Starting with a full tank
        }

        // TODO: Implement the abstract Drive() method with a custom message.
        public override void Drive()
        {
            Random randomDistanceGenerator = new Random();
            double distance = randomDistanceGenerator.Next(0, (int)(this.FuelEcon * this._fuelLevel));
            this._fuelLevel = this._fuelLevel - distance * this.FuelEcon;
            Console.WriteLine($"The {Color} {Make} {Model} bike is driving for {distance}, there are {_fuelLevel} percent remaining fuel.");
        }

        // --- Interface Method Implementation ---
        // TODO: Implement the Refuel() method from the ITransport interface.
        // This method should add fuel and print the new fuel level.
        public void Refuel(double amount)
        {
            Console.WriteLine($"This motorcycle ({Color} {Make} {Model}) iss being refueled!");
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
                Console.WriteLine($"Now you have {_fuelLevel}");
            }
        }
    }
}