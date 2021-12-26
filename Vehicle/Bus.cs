namespace GarageSpace.Vehicle
{
    internal class Bus : Vehicle, IVehicle
    {
        public Bus(string numPlate, string color, uint tires, uint seats) : base(numPlate, color, tires)
        {
            Seats = seats;
        }
        public uint Seats { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} Number of seats: {Seats}";
        }
    }
}
