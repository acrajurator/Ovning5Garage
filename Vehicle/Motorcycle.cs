namespace GarageSpace.Vehicle
{
    public  class Motorcycle : Vehicle
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
