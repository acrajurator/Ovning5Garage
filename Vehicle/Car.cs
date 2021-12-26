namespace GarageSpace.Vehicle
{
    internal class Car : Vehicle, IVehicle
    {
        public Car(string numPlate, string color, uint tires, string fuel) : base(numPlate, color, tires)
        {
            Fuel = fuel;
        }
        public string Fuel { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()} Fuel type: {Fuel}";
        }
    }
}
