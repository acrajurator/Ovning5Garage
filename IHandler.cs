namespace GarageSpace
{
    public interface IHandler
    {
        void PrintVehicles();
        void PrintVehicles(VehicleType value);
        void CreateGarage(uint size);


        void VehiclesByNrPlate(string numPlate);
        void VehiclesByNrPlateCol(string numPlate, string color);
        void VehiclesByNrPlateTir(string numPlate, uint tires);
        void VehiclesByNrPlateColTir(string numPlate, string color, uint tires);
        void VehiclesByColor(string color);
        void VehiclesByColorTires(string color, uint tires);
        void VehiclesByTires(uint tires);
        bool AddBoat(string numPlate, string color, uint tires, uint lenght);
        bool AddBus(string numPlate, string color, uint tires, uint seats);
        bool AddCar(string numPlate, string color, uint tires, string fuel);
        bool AddMotorcycle(string numPlate, string color, uint tires, uint volume);
        bool AddAirplane(string numPlate, string color, uint tires, uint engines);
        bool AvailableSpots();
        bool RemoveVehicle(uint parkingSpot);
        void PrintNumPlate(string numberPlate);
    }
}