using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSpace.Vehicle
{
    internal class Car : IVehicle
    {
        public Car(string numPlate, string color, uint tires, string fuel)
        {
            NumPlate = numPlate;
            Color = color;
            Tires = tires;
            Fuel = fuel;
        }


        public string Color { get; set; }
        public string NumPlate { get; set; }
        public uint Tires { get; set; }
        public string Fuel { get; set; }
    }
}
