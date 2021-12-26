// See https://aka.ms/new-console-template for more information

using GarageSpace;

public class GarageMenu
{
    IHandler handler = new GarageHandler();
    public GarageMenu()
    {
    }

    public void RunMenu()
    {
        StartMenu();
        OptionalFillGarage();
        MainMenu();


    }

    private void MainMenu()
    {
       // Console.Clear();

        Console.WriteLine("Main Menu");
        Console.WriteLine("1. Print all parked Vehicles");
        Console.WriteLine("2. Print a specific vehicle type");
        Console.WriteLine("3. Add / Remove Vehicle");
        Console.WriteLine("4. Search vehicle based on numberplate");
        Console.WriteLine("5. Search vehicle based on properties.");
        Console.WriteLine("6. Quit Program");
        uint option = InputUint(6);

        switch (option)
        {
            case 1:
                handler.PrintVehicles();
                MainMenu();
                break;
            case 2:
                PrintSpecificMenu();
                MainMenu();
                break;
            case 3:
                AddRemoveMenu();
                MainMenu();
                break;
            case 4:
                NumberPlateMenu();
                MainMenu();
                break;
            case 5:
                PropertyMenu();
                MainMenu();
                break;
            case 6:
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
                break;
            default:
                throw new NotImplementedException();
        }


    }

    private void PropertyMenu()
    {
        Console.WriteLine("What properties do you want to search by?");

        Console.WriteLine("1. Number plate");
        Console.WriteLine("2. Number plate + Color");
        Console.WriteLine("3. Number plate + Amount of Tires");
        Console.WriteLine("4. Number plate + Amount of Tires + Color");
        Console.WriteLine("5. Color");
        Console.WriteLine("6. Color + Amount of Tires");
        Console.WriteLine("7. Amount of Tires");
        Console.WriteLine("8. Go back");

        uint option = InputUint(8);
        string numPlate;
        string color;
        uint tires;
        switch (option)
        {
            case 1:

                Console.WriteLine("Write the number plate");
                numPlate = InputString();
                handler.VehiclesByNrPlate(numPlate);
                break;
            case 2:
                Console.WriteLine("Write the number plate");
                numPlate = InputString();

                Console.WriteLine("Write the color");
                color = InputString();
                handler.VehiclesByNrPlateCol(numPlate, color);
                break;
            case 3:
                Console.WriteLine("Write the number plate");
                numPlate = InputString();
                Console.WriteLine("Write the number of tires");
                tires = InputUint();
                handler.VehiclesByNrPlateTir(numPlate, tires);
                break;
            case 4:
                Console.WriteLine("Write the number plate");
                numPlate = InputString();
                Console.WriteLine("Write the color");
                color = InputString();
                Console.WriteLine("Write the number of tires");
                tires = InputUint();
                handler.VehiclesByNrPlateColTir(numPlate, color, tires);;
                break;
            case 5:
                Console.WriteLine("Write the color");
                color = InputString();
                handler.VehiclesByColor(color);
                break;
            case 6:
                Console.WriteLine("Write the color");
                color = InputString();
                Console.WriteLine("Write the number of tires");
                tires = InputUint();
                handler.VehiclesByColorTires(color, tires);
                break;
            case 7:
                Console.WriteLine("Write the number of tires");
                tires = InputUint();
                handler.VehiclesByTires(tires);
                break;

            case 8:
                MainMenu();
                break;
            default:
                throw new NotImplementedException();
        }
    }


    private void NumberPlateMenu()
    {
        Console.WriteLine("Whats the Number plate of the vehicle you want to print?");
        var numberPlate = InputString();
            numberPlate.ToUpper();
        //toDo Search for numberplate
        handler.PrintNumPlate(numberPlate);

            Console.WriteLine("You looked for a number plate");

        MainMenu();
    }

    private void AddRemoveMenu()
    {
        //Console.Clear();
        Console.WriteLine("Do you want to remove or add a vehicle?");
        Console.WriteLine("1. Add");
        Console.WriteLine("2. Remove");
        Console.WriteLine("3. Go back");
        uint option = InputUint(3);
        switch (option)
        {
            case 1:
                AddVehicle();
                break;
            case 2:
                RemoveVehicle();
                break;
            case 3:
                MainMenu();
                break;
            default:
                throw new NotImplementedException();
        }
    }

    private void RemoveVehicle()
    {
        Console.WriteLine("Which parking spot do you want to remove a vehicle from?");
        uint option = InputUint();
        bool success = handler.RemoveVehicle(option);
        if (success)
            Console.WriteLine("You Removed a vehicle!");
        else
            Console.WriteLine("There was no vehicle in that parking spot!");

        AddRemoveMenu();
    }

    private void AddVehicle()
    {
        if (!handler.AvailableSpots())
        {
            Console.WriteLine("There are no parking spots available");   
        }
        Console.WriteLine("What type of vehicle do you want to add?");
        Console.WriteLine("1. Airplane");
        Console.WriteLine("2. Motorcycle");
        Console.WriteLine("3. Car");
        Console.WriteLine("4. Bus");
        Console.WriteLine("5. Boat");
        Console.WriteLine("6. Go back");
        uint option = InputUint(6);
        switch (option)
        {
            case 1:
                AddAirplane();
                break;
            case 2:
                AddMotorcycle();
                break;
            case 3:
                AddCar();
                break;
            case 4:
                AddBus();
                break;
            case 5:
                AddBoat();
                break;
            case 6:
                MainMenu();
                break;
            default:
                throw new NotImplementedException();
        };
        AddRemoveMenu();
    }

    private void AddBoat()
    {
        Console.WriteLine("What number plate?");
        string numPlate = InputString().ToUpper();
        Console.WriteLine("What Color?");
        string color = InputString().ToUpper();
        Console.WriteLine("How many tires?");
        uint tires = InputUint();
        Console.WriteLine("How long is it?");
        uint lenght = InputUint();
         bool success = handler.AddBoat(numPlate, color, tires, lenght);

        if (success)
            Console.WriteLine("You added a vehicle!");
        else
            Console.WriteLine("Parking is full. Couldn't add your vehicle!");
    }

    private void AddBus()
    {
        Console.WriteLine("What number plate?");
        string numPlate = InputString().ToUpper();
        Console.WriteLine("What Color?");
        string color = InputString().ToUpper();
        Console.WriteLine("How many tires?");
        uint tires = InputUint();
        Console.WriteLine("Number of seats?");
        uint seats = InputUint();
        bool success = handler.AddBus(numPlate, color, tires, seats);
        if (success)
            Console.WriteLine("You added a vehicle!");
        else
            Console.WriteLine("Parking is full. Couldn't add you vehicle!");
    }

    private void AddCar()
    {
        Console.WriteLine("What number plate?");
        string numPlate = InputString().ToUpper();
        Console.WriteLine("What Color?");
        string color = InputString().ToUpper();
        Console.WriteLine("How many tires?");
        uint tires = InputUint();
        Console.WriteLine("What Fuel type?");
        string fuel = InputString().ToUpper();
        bool success = handler.AddCar(numPlate, color, tires, fuel);
        if (success)
            Console.WriteLine("You added a vehicle!");
        else
            Console.WriteLine("Parking is full. Couldn't add you vehicle!");
    }

    private void AddMotorcycle()
    {
        Console.WriteLine("What number plate?");
        string numPlate = InputString().ToUpper();
        Console.WriteLine("What Color?");
        string color = InputString().ToUpper();
        Console.WriteLine("How many tires?");
        uint tires = InputUint();
        Console.WriteLine("Cylinder volume?");
        uint volume = InputUint();
        bool success = handler.AddMotorcycle(numPlate, color, tires, volume);
        if (success)
            Console.WriteLine("You added a vehicle!");
        else
            Console.WriteLine("Parking is full. Couldn't add you vehicle!");
    }

    private void AddAirplane()
    {
        Console.WriteLine("What number plate?");
        string numPlate = InputString().ToUpper();
        Console.WriteLine("What Color?");
        string color = InputString().ToUpper();
        Console.WriteLine("How many tires?");
        uint tires = InputUint();
        Console.WriteLine("How many engines?");
        uint engines = InputUint();
        bool success = handler.AddAirplane(numPlate, color, tires, engines);
        if (success)
            Console.WriteLine("You added a vehicle!");
        else
            Console.WriteLine("Parking is full. Couldn't add you vehicle!");

    }

    private void PrintSpecificMenu()
    {
        //Console.Clear();
        Console.WriteLine("Which type of vehicles do you want to print?");
        Console.WriteLine("1. Airplanes");
        Console.WriteLine("2. Motorcycles");
        Console.WriteLine("3. Cars");
        Console.WriteLine("4. Bus");
        Console.WriteLine("5. Boats");
        Console.WriteLine("6. Go back");
        uint option = InputUint(6);

        switch (option)
        {
            case 1:
                handler.PrintVehicles(VehicleType.Airplane);
                break;
            case 2:
                handler.PrintVehicles(VehicleType.Motorcycle);
                break;
            case 3:
                handler.PrintVehicles(VehicleType.Car);
                break;
            case 4:
                handler.PrintVehicles(VehicleType.Bus);
                break;
            case 5:
                handler.PrintVehicles(VehicleType.Boat);
                break;
            case 6:
                MainMenu();
                break;
            default:
                throw new NotImplementedException();
        }

    }

    private void OptionalFillGarage()
    {
        //Console.Clear();
        Console.WriteLine("Do you want to auto add vehicles to the garage?");
        Console.WriteLine("1. Auto add vehicles.");
        Console.WriteLine("2. Do not auto add vehicles");
        Console.WriteLine("3. Quit program");
        uint option = InputUint(3);

        switch (option)
        {
            case 1:
                //toDo fill garage;
                 handler.AddAirplane("abc123", "yellow", 3, 4);
                 handler.AddMotorcycle("cde452", "white", 2, 10);
                 handler.AddCar("ret521", "red", 4, "normal");
                handler.AddCar("bla111", "pink", 4, "special");
                 handler.AddBus("dra333", "yellow", 8, 22);
                handler.AddBoat("pizza", "red", 0, 10);

                break;
            case 2:
                //Dont add;
                break;
            case 3:
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
                break;
            default:
                throw new NotImplementedException();
        }
    }

    private void StartMenu()
    {

        Console.Clear();
        Console.WriteLine("Welcome to the garage");
        Console.WriteLine("How many parking spots do you want your new garage to have?");
        uint size = InputUint();

        handler.CreateGarage(size);
        Console.Clear();
        Console.WriteLine("Your garage was created with " + size + " parking spots!");

    }


    private uint InputUint(uint options = 4294967295)
    {
        uint choice = 0;
        uint.TryParse(Console.ReadLine(), out choice);

        while (choice > options || choice < 1)
        {
            Console.WriteLine();
            Console.WriteLine("Please try again");
            uint.TryParse(Console.ReadLine(), out choice);
        }
        return choice;

    }
    private string InputString()
    {
        var input = Console.ReadLine();
        if (input == null)
        {
            Console.WriteLine("Please try again");
            return InputString();
        }
        else
            return input;

    }

}