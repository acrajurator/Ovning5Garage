using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSpace.Vehicle
{
    internal class Bus : IVehicle
    {
        public Bus(string numPlate, string color, uint tires, uint seats)
        {
            NumPlate = numPlate;
            Color = color;
            Tires = tires;
            Seats = seats;
        }

        public string Color { get; set; }
        public string NumPlate { get; set; }
        public uint Tires { get; set; }
        public uint Seats { get; set; }
    }
}
