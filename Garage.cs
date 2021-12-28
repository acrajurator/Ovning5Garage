using GarageSpace.Vehicle;
using System.Collections;

namespace GarageSpace
{
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private IVehicle[] vehicles;
        public Garage(uint size)
        {
            vehicles = new IVehicle[size];
        }

        public int FirstAvailableSpot()
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

        public void AddVehicle(T vehicle, int parkingSpot)
        {
            if (parkingSpot < 1 || parkingSpot > vehicles.Count())
                throw new ArgumentOutOfRangeException(nameof(parkingSpot), $"{parkingSpot} is not a parking spot within the garage size");
            else if (vehicles[parkingSpot - 1] == null)
                vehicles[parkingSpot - 1] = vehicle;
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

        public bool RemoveVehicle(uint parkingSpot)
        {
            if (parkingSpot < 1 || parkingSpot > vehicles.Count())
                throw new ArgumentOutOfRangeException(nameof(parkingSpot), $"{parkingSpot} is not a parking spot within the garage size");
            else if (vehicles[parkingSpot-1] != null)
            {
                vehicles[parkingSpot - 1] = null;
                return true;

            }
            return false;
        }
    }
}
