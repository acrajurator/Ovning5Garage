namespace GarageSpace.Vehicle
{
    public class Airplane : Vehicle, IVehicle
    {
        public Airplane(string numPlate, string color, uint tires, uint engines):base(numPlate, color,tires)
        {
            Engines = engines;
        }

        public uint Engines { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} Number of engines: {Engines}";
        }
    }
}
