using GarageSpace.Vehicle;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSpace
{
    internal class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private IVehicle[] vehicles;
        public Garage(uint size)
        {
            vehicles = new IVehicle[size];
        }

        internal int AvailableSpots()
        {
            int x = 0;
            if (vehicles != null)
            {
                foreach (var vehicle in vehicles)
                {
                    if (vehicle == null)
                    x++;
                }
            }
            return x;
        }

        internal int FirstAvailableSpot()
        {
            if (vehicles != null)
            {
              for (int i = 0; i < vehicles.Count(); i++)
                {
                    if (vehicles[i] == null)
                        return i+1;
                }
            }
            return 0;
        }

        internal void AddVehicle(T vehicle, int x)
        {
            vehicles[x-1] = vehicle;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T v in vehicles)
                yield return v;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); 
        }

        internal bool RemoveVehicle(uint parkingSpot)
        {
            if (parkingSpot > 0 && parkingSpot < vehicles.Length && vehicles[parkingSpot-1] != null)
            {
                vehicles[parkingSpot - 1] = null;
                return true;

            }
            return false;
        }
    }
}
