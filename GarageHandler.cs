using GarageSpace.Vehicle;

namespace GarageSpace
{
    internal class GarageHandler : IHandler
    {
        Garage<IVehicle>? garage;

        public void CreateGarage(uint size)
        {
            garage = new Garage<IVehicle>(size);
        }
        public bool AddAirplane(string numPlate, string color, uint tires, uint engines)
        {

            Airplane airplane = new Airplane(numPlate.ToUpper(), color.ToUpper(), tires, engines);
            if (garage != null && garage.AvailableSpots() > 0)
            {


                int x = garage.FirstAvailableSpot();
                if (x > 0)
                {
                    garage.AddVehicle(airplane, x);
                    return true;
                }
            }
            return false;
        }
        public bool AddBus(string numPlate, string color, uint tires, uint seats)
        {
            Bus bus = new Bus(numPlate.ToUpper(), color.ToUpper(), tires, seats);
            if (garage != null && garage.AvailableSpots() > 0)
            {


                int x = garage.FirstAvailableSpot();
                if (x > 0)
                {
                    garage.AddVehicle(bus, x);
                    return true;
                }
            }

            return false;
        }


        public bool AddBoat(string numPlate, string color, uint tires, uint lenght)
        {

            Boat boat = new Boat(numPlate.ToUpper(), color.ToUpper(), tires, lenght);
            if (garage != null && garage.AvailableSpots() > 0)
            {


                int x = garage.FirstAvailableSpot();
                if (x > 0)
                {
                    garage.AddVehicle(boat, x);
                    return true;
                }
            }
            return false;
        }

        public bool AddCar(string numPlate, string color, uint tires, string fuel)
        {
            Car car = new Car(numPlate.ToUpper(), color.ToUpper(), tires, fuel.ToUpper());
            if (garage != null && garage.AvailableSpots() > 0)
            {


                int x = garage.FirstAvailableSpot();
                if (x > 0)
                {
                    garage.AddVehicle(car, x);
                    return true;
                }
            }
            return false;

        }

        public bool AddMotorcycle(string numPlate, string color, uint tires, uint volume)
        {
            Motorcycle motorcycle = new Motorcycle(numPlate.ToUpper(), color.ToUpper(), tires, volume);
            if (garage != null && garage.AvailableSpots() > 0)
            {


                int x = garage.FirstAvailableSpot();
                if (x > 0)
                {
                    garage.AddVehicle(motorcycle, x);
                    return true;
                }
            }
            return false;

        }


        public void PrintVehicles()
        {
            if (garage != null)
            {
                int x = 0;
                foreach (var var in garage)
                {
                    x++;
                    if (var != null)
                        Console.WriteLine(var.ToString());
                }
            }

        }

        public void PrintVehicles(VehicleType value)
        {
            if (garage != null)
            {
                foreach (var var in garage)
                {
                    //toDo think of a better way
                    switch (value)
                    {
                        case VehicleType.Car:
                            if (var is Car)
                                Console.WriteLine(var.ToString());
                            break;
                        case VehicleType.Airplane:
                            if (var is Airplane)
                                Console.WriteLine(var.ToString());
                            break;
                        case VehicleType.Boat:
                            if (var is Boat)
                                Console.WriteLine(var.ToString());
                            break;
                        case VehicleType.Bus:
                            if (var is Bus)
                                Console.WriteLine(var.ToString());
                            break;
                        case VehicleType.Motorcycle:
                            if (var is Motorcycle)
                                Console.WriteLine(var.ToString());
                            break;
                        default:
                            throw new NotImplementedException();

                    }

                }
            }
        }

        public void VehiclesByColor(string color)
        {
            if (garage != null)
            {
                garage.Where(x => x != null && x.Color.Equals(color.ToUpper())).ToList().ForEach(x =>
                {
                    Console.WriteLine(x.ToString());
                });
            }
        }

        public void VehiclesByColorTires(string color, uint tires)
        {
            if (garage != null)
            {
                garage.Where(x => x != null && x.Color.Equals(color.ToUpper()) && x.Tires.Equals(tires)).ToList().ForEach(x =>
                {
                    Console.WriteLine(x.ToString());
                });
            }
        }

        public void VehiclesByNrPlate(string numPlate)
        {
            if (garage != null)
            {
                garage.Where(x => x != null && x.NumPlate.Equals(numPlate.ToUpper())).ToList().ForEach(x =>
            {
                Console.WriteLine(x.ToString());
            });
            }
        }

        public void VehiclesByNrPlateCol(string numPlate, string color)
        {
            if (garage != null)
            {
                garage.Where(x => x != null && x.NumPlate.Equals(numPlate.ToUpper()) && x.Color.Equals(color.ToUpper())).ToList().ForEach(x =>
                {
                    Console.WriteLine(x.ToString());
                });
            }
        }

        public void VehiclesByNrPlateColTir(string numPlate, string color, uint tires)
        {
            if (garage != null)
            {
                garage.Where(x => x != null && x.NumPlate.Equals(numPlate.ToUpper()) && x.Color.Equals(color.ToUpper()) && x.Tires.Equals(tires)).ToList().ForEach(x =>
        {
            Console.WriteLine(x.ToString());
        });
            }
        }

        public void VehiclesByNrPlateTir(string numPlate, uint tires)
        {
            if (garage != null)
            {
                garage.Where(x => x != null && x.NumPlate.Equals(numPlate.ToUpper()) && x.Tires.Equals(tires)).ToList().ForEach(x =>
    {
        Console.WriteLine(x.ToString());
    });
            }
        }

        public void VehiclesByTires(uint tires)
        {
            if (garage != null)
            {
                garage.Where(x => x != null && x.Tires.Equals(tires)).ToList().ForEach(x =>
             {
                 Console.WriteLine(x.ToString());
             });
            }
        }

        public bool AvailableSpots()
        {
            int x = 0;
            if (garage != null)
            {
                x = garage.AvailableSpots();
            }
            return x > 0;
        }

        public bool RemoveVehicle(uint parkingSpot)
        {
            if (garage != null && parkingSpot > 0)
            {
                return garage.RemoveVehicle(parkingSpot);
            }
            return false;
        }

        public void PrintNumPlate(string numberPlate)
        {
            if (garage != null)
            {
                foreach (var var in garage)
                {
                    if (var != null && var.NumPlate.Equals(numberPlate.ToUpper()))
                    {
                        Console.WriteLine(var);
                        break;
                    }
                }
            }

        }
    }



}






