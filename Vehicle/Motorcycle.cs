namespace GarageSpace.Vehicle
{
    internal class Motorcycle : Vehicle, IVehicle
    {
        public Motorcycle(string numPlate, string color, uint tires, uint volume) : base(numPlate, color, tires)
        {
            Volume = volume;
        }
        public uint Volume { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()} Engine volume: {Volume}";
        }
    }
}
