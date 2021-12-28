using GarageSpace.Vehicle;
using System.Collections;

namespace GarageSpace
{
    public interface IGarage<T> : IEnumerable<T> where T : IVehicle
    {
        public int FirstAvailableSpot();


        public void AddVehicle(T vehicle, int parkingSpot);
        public IEnumerator<T> GetEnumerator();
        abstract IEnumerator IEnumerable.GetEnumerator();
        public bool RemoveVehicle(uint parkingSpot);
    }
}
