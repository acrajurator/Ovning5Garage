using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSpace.Vehicle
{
    internal class Motorcycle : IVehicle
    {
        public Motorcycle(string numPlate, string color, uint tires, uint volume)
        {
            NumPlate = numPlate;
            Color = color;
            Tires = tires;
            Volume = volume;
        }


        public string Color { get; set; }
        public string NumPlate { get; set; }
        public uint Tires { get; set; }
        public uint Volume { get; set; }
    }
}
