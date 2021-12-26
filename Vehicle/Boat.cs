namespace GarageSpace.Vehicle
{
    internal class Boat : Vehicle, IVehicle
    {
        public Boat(string numPlate, string color, uint tires, uint length) : base(numPlate, color, tires)
        {
            Length = length;
        }


        public uint Length { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()} Lenght: {Length}";
        }
    }
}
