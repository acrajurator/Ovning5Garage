namespace GarageSpace.Vehicle
{
    public class Car : Vehicle
    {
        public Car(string numPlate, string color, uint tires, string fuel) : base(numPlate, color, tires)
        {
            Fuel = fuel.ToUpper();
        }
        public string Fuel { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()} Fuel type: {Fuel}";
        }
    }
}
