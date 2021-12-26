namespace GarageSpace.Vehicle
{
    public interface IVehicle
    {
        public string NumPlate { get; set; }
        public string Color { get; set; }

        public uint Tires { get; set; }
    }
}