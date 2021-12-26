using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSpace.Vehicle
{
    internal class Boat : IVehicle
    {
        public Boat(string numPlate, string color, uint tires, uint lenght)
        {
            NumPlate = numPlate;
            Color = color;
            Tires = tires;
            Lenght = lenght;
        }

 
        public string Color { get; set; }
        public uint Lenght { get; set; }
        public string NumPlate { get; set; }
        public uint Tires { get; set; }
    }
}
