namespace GarageSpace.Vehicle
{
    public abstract class Vehicle : IVehicle
    {
        public string NumPlate { get; set; }
        public string Color { get; set; }
        public uint Tires { get; set; }
        public Vehicle (string numPlate, string color, uint tires)
        {
            NumPlate = numPlate.ToUpper();    
            Color = color.ToUpper();  
            Tires = tires;  
        }
        public override string ToString()
        {
            return $"Vehicle type: {this.GetType().Name} Number plate: {NumPlate} Color: {Color} Number of tires: {Tires}";
        }
    }
}
