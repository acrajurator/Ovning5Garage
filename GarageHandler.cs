using GarageSpace.Vehicle;

namespace GarageSpace
{
    public class GarageHandler : IHandler
    {
        IGarage<IVehicle>? garage;
        IUI ui;

        public GarageHandler(IUI ui)
        {
            this.ui = ui;
        }
        public void CreateGarage(uint size)
        {
            garage = new Garage<IVehicle>(size);


        }
        public bool AddAirplane(string numPlate, string color, uint tires, uint engines)
        {

            var airplane = new Airplane(numPlate.ToUpper(), color.ToUpper(), tires, engines);

            return AddVehicle(airplane);


        }

        private bool AddVehicle(IVehicle vehicle)
        {
            if (garage != null && garage.FirstAvailableSpot() > 0 && !IsDuplicateNumPlate(vehicle.NumPlate.ToUpper()))
            {
                int x = garage.FirstAvailableSpot();
                if (x > 0)
                {
                    garage.AddVehicle(vehicle, x);
                    return true;
                }
            }
            return false;
        }

        public bool AddBus(string numPlate, string color, uint tires, uint seats)
        {
            var bus = new Bus(numPlate.ToUpper(), color.ToUpper(), tires, seats);
            return AddVehicle(bus);
        }


        public bool AddBoat(string numPlate, string color, uint tires, uint lenght)
        {

            Boat boat = new Boat(numPlate.ToUpper(), color.ToUpper(), tires, lenght);
            return AddVehicle(boat);

        }

        public bool AddCar(string numPlate, string color, uint tires, string fuel)
        {
            var car = new Car(numPlate.ToUpper(), color.ToUpper(), tires, fuel.ToUpper());
            return AddVehicle(car);


        }

        public bool AddMotorcycle(string numPlate, string color, uint tires, uint volume)
        {

            var motorcycle = new Motorcycle(numPlate.ToUpper(), color.ToUpper(), tires, volume);
            return AddVehicle(motorcycle);


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
                        ui.PrintString(var.ToString());
                }
            }

        }

        public void PrintVehicles(VehicleType value)
        {
            if (garage != null)
            {
                foreach (var var in garage)
                {
                    switch (value)
                    {
                        case VehicleType.Car:
                            if (var is Car)
                                ui.PrintString(var.ToString());
                            break;
                        case VehicleType.Airplane:
                            if (var is Airplane)
                                ui.PrintString(var.ToString());
                            break;
                        case VehicleType.Boat:
                            if (var is Boat)
                                ui.PrintString(var.ToString());
                            break;
                        case VehicleType.Bus:
                            if (var is Bus)
                                ui.PrintString(var.ToString());
                            break;
                        case VehicleType.Motorcycle:
                            if (var is Motorcycle)
                                ui.PrintString(var.ToString());
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
                    ui.PrintString(x.ToString());
                });
            }
        }

        public void VehiclesByColorTires(string color, uint tires)
        {
            if (garage != null)
            {
                garage.Where(x => x != null && x.Color.Equals(color.ToUpper()) && x.Tires.Equals(tires)).ToList().ForEach(x =>
                {
                    ui.PrintString(x.ToString());
                });
            }
        }

        public void VehiclesByNrPlate(string numPlate)
        {
            if (garage != null)
            {
                garage.Where(x => x != null && x.NumPlate.Equals(numPlate.ToUpper())).ToList().ForEach(x =>
            {
                ui.PrintString(x.ToString());
            });
            }
        }

        public void VehiclesByNrPlateCol(string numPlate, string color)
        {
            if (garage != null)
            {
                garage.Where(x => x != null && x.NumPlate.Equals(numPlate.ToUpper()) && x.Color.Equals(color.ToUpper())).ToList().ForEach(x =>
                {
                    ui.PrintString(x.ToString());
                });
            }
        }

        public void VehiclesByNrPlateColTir(string numPlate, string color, uint tires)
        {
            if (garage != null)
            {
                garage.Where(x => x != null && x.NumPlate.Equals(numPlate.ToUpper()) && x.Color.Equals(color.ToUpper()) && x.Tires.Equals(tires)).ToList().ForEach(x =>
        {
            ui.PrintString(x.ToString());
        });
            }
        }

        public void VehiclesByNrPlateTir(string numPlate, uint tires)
        {
            if (garage != null)
            {
                garage.Where(x => x != null && x.NumPlate.Equals(numPlate.ToUpper()) && x.Tires.Equals(tires)).ToList().ForEach(x =>
                  {
                      ui.PrintString(x.ToString());
                  });
            }
        }

        public void VehiclesByTires(uint tires)
        {
            if (garage != null)
            {
                garage.Where(x => x != null && x.Tires.Equals(tires)).ToList().ForEach(x =>
             {
                 ui.PrintString(x.ToString());
             });
            }
        }

        public bool AvailableSpots()
        {
            int x = 0;
            if (garage != null)
            {
                x = garage.FirstAvailableSpot();
            }
            return x > 0;
        }

        public bool RemoveVehicle(uint parkingSpot)
        {
            if (garage != null && parkingSpot > 0)
            {
                try
                {
                    return garage.RemoveVehicle(parkingSpot);

                }
                catch (ArgumentOutOfRangeException)
                {

                }
            }
            return false;
        }

        public bool IsDuplicateNumPlate(string numberPlate)
        {
            if (garage != null)
            {
                foreach (var var in garage)
                {
                    if (var != null && var.NumPlate.Equals(numberPlate.ToUpper()))
                    {
                        return true;

                    }
                }
            }
            return false;

        }
    }



}






