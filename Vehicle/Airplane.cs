using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSpace.Vehicle
{
    internal class Airplane : IVehicle
    {
        public Airplane(string numPlate, string color, uint tires, uint engines)
        {
            NumPlate = numPlate;
            Color = color;
            Tires = tires;
            Engines = engines;
        }


        public string Color { get; set; }
        public string NumPlate { get; set; }
        public uint Tires { get; set; }
        public uint Engines { get; set; }
    }
}
