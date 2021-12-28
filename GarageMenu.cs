// See https://aka.ms/new-console-template for more information

using GarageSpace;

public class GarageMenu
{

    static IUI ui = new ConsoleUI();
    IHandler handler = new GarageHandler(ui);
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
        ui.PrintString("Main Menu");
        ui.PrintString("1. Print all parked Vehicles");
        ui.PrintString("2. Print a specific vehicle type");
        ui.PrintString("3. Add / Remove Vehicle");
        ui.PrintString("4. Search vehicle based on number plate");
        ui.PrintString("5. Search vehicle based on properties.");
        ui.PrintString("6. Quit Program");
        uint option = Util.AskForUInt("# of your choice: ", ui); 

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
                ui.PrintString("Goodbye!");
                Environment.Exit(0);
                break;
            default:
                ui.PrintString("Please Pick one of the below!");
                MainMenu();
                break;
        }


    }

    private void PropertyMenu()
    {
        ui.PrintString("What properties do you want to search by?");

        ui.PrintString("1. Number plate");
        ui.PrintString("2. Number plate + Color");
        ui.PrintString("3. Number plate + Amount of Tires");
        ui.PrintString("4. Number plate + Amount of Tires + Color");
        ui.PrintString("5. Color");
        ui.PrintString("6. Color + Amount of Tires");
        ui.PrintString("7. Amount of Tires");
        ui.PrintString("8. Go back");

        uint option = Util.AskForUInt("# of your choice: ",ui);
        string numPlate;
        string color;
        uint tires;
        switch (option)
        {
            case 1:

                numPlate = Util.AskForString("What Number Plate?", ui); 
                handler.VehiclesByNrPlate(numPlate);
                break;
            case 2:
                numPlate = Util.AskForString("What Number Plate?", ui); 
                color = Util.AskForString("What Color?", ui);
                handler.VehiclesByNrPlateCol(numPlate, color);
                break;
            case 3:
                numPlate = Util.AskForString("What Number Plate?", ui); 
                tires = Util.AskForUInt("Number of tires: ", ui);
                handler.VehiclesByNrPlateTir(numPlate, tires);
                break;
            case 4:
                numPlate = Util.AskForString("What Number Plate?", ui); 
                color = Util.AskForString("What Color?", ui);
                tires = Util.AskForUInt("Number of tires: ", ui);
                handler.VehiclesByNrPlateColTir(numPlate, color, tires); 
                break;
            case 5:
                color = Util.AskForString("What Color?", ui);
                handler.VehiclesByColor(color);
                break;
            case 6:
                color = Util.AskForString("What Color?", ui);
                tires = Util.AskForUInt("Number of tires: ", ui);
                handler.VehiclesByColorTires(color, tires);
                break;
            case 7:
                tires = Util.AskForUInt("Number of tires: ", ui); 
                handler.VehiclesByTires(tires);
                break;

            case 8:
                MainMenu();
                break;
            default:
                ui.PrintString("Please Pick one of the below!");
                PropertyMenu();
                break;
        }
    }


    private void NumberPlateMenu()
    {
        var numPlate = Util.AskForString("What Number Plate?", ui);
        handler.VehiclesByNrPlate(numPlate);

        MainMenu();
    }

    private void AddRemoveMenu()
    {
        ui.PrintString("Do you want to remove or add a vehicle?");
        ui.PrintString("1. Add");
        ui.PrintString("2. Remove");
        ui.PrintString("3. Go back");
        uint option = Util.AskForUInt("# of your choice: ", ui);
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
                ui.PrintString("Please Pick one of the below!");
                AddRemoveMenu();
                break;
        }
    }

    private void RemoveVehicle()
    {
        uint option = Util.AskForUInt("Which parking spot do you want to remove a vehicle from?", ui); 
        bool success = handler.RemoveVehicle(option);
        if (success)
            ui.PrintString("You Removed a vehicle!");
        else
            ui.PrintString("There was no vehicle in that parking spot!");

        AddRemoveMenu();
    }

    private void AddVehicle()
    {
        if (!handler.AvailableSpots())
        {
            ui.PrintString("There are no parking spots available");
            MainMenu();

        }
        ui.PrintString("What type of vehicle do you want to add?");
        ui.PrintString("1. Airplane");
        ui.PrintString("2. Motorcycle");
        ui.PrintString("3. Car");
        ui.PrintString("4. Bus");
        ui.PrintString("5. Boat");
        ui.PrintString("6. Go back");
        uint option = Util.AskForUInt("# of your choice: ", ui); 
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
                ui.PrintString("Please Pick one of the below!");
                AddVehicle();
                break;


        };
        AddRemoveMenu();
    }

    private void AddBoat()
    {
        string numPlate = Util.AskForString("What number plate?", ui); ;
        string color = Util.AskForString("What Color?", ui);
        uint tires = Util.AskForUInt("How many tires?", ui);
        uint length = Util.AskForUInt("How long is it?", ui);
        bool success = handler.AddBoat(numPlate, color, tires, length);

        if (success)
            ui.PrintString("You added a vehicle!");
        else
            ui.PrintString("Number plate is already taken. Couldn't add your vehicle!");
    }

    private void AddBus()
    {
        string numPlate = Util.AskForString("What number plate?", ui); ;
        string color = Util.AskForString("What Color?", ui);
        uint tires = Util.AskForUInt("How many tires?", ui);
        uint seats = Util.AskForUInt("Number of seats?", ui);
        bool success = handler.AddBus(numPlate, color, tires, seats);
        if (success)
            ui.PrintString("You added a vehicle!");
        else
            ui.PrintString("Number plate is already taken. Couldn't add your vehicle!");
    }

    private void AddCar()
    {
        string numPlate = Util.AskForString("What number plate?", ui);
        string color = Util.AskForString("What Color?", ui);
        uint tires = Util.AskForUInt("How many tires?", ui);
        string fuel = Util.AskForString("What Fuel Type?", ui);
        bool success = handler.AddCar(numPlate, color, tires, fuel);
        if (success)
            ui.PrintString("You added a vehicle!");
        else
            ui.PrintString("Number plate is already taken. Couldn't add your vehicle!");
    }

    private void AddMotorcycle()
    {
        string numPlate = Util.AskForString("What number plate?", ui); ;
        string color = Util.AskForString("What Color?", ui);
        uint tires = Util.AskForUInt("How many tires?", ui);
        uint volume = Util.AskForUInt("Cylinder volume?", ui);
        bool success = handler.AddMotorcycle(numPlate, color, tires, volume);
        if (success)
            ui.PrintString("You added a vehicle!");
        else
            ui.PrintString("Number plate is already taken. Couldn't add your vehicle!");
    }

    private void AddAirplane()
    {
        string numPlate = Util.AskForString("What number plate?", ui); ;
        string color = Util.AskForString("What Color?", ui);
        uint tires = Util.AskForUInt("How many tires?", ui);
        uint engines = Util.AskForUInt("How many engines?", ui); 
        bool success = handler.AddAirplane(numPlate, color, tires, engines);
        if (success)
            ui.PrintString("You added a vehicle!");
        else
            ui.PrintString("Number plate is already taken. Couldn't add your vehicle!");

    }

    private void PrintSpecificMenu()
    {
        ui.PrintString("Which type of vehicles do you want to print?");
        ui.PrintString("1. Airplanes");
        ui.PrintString("2. Motorcycles");
        ui.PrintString("3. Cars");
        ui.PrintString("4. Bus");
        ui.PrintString("5. Boats");
        ui.PrintString("6. Go back");
        uint option = Util.AskForUInt("#of your choice:", ui); ;

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
                ui.PrintString("Please Pick one of the below!");
                PrintSpecificMenu();
                break;
        }

    }

    private void OptionalFillGarage()
    {
        ui.PrintString("Do you want to auto add vehicles to the garage?");
        ui.PrintString("1. Auto add vehicles.");
        ui.PrintString("2. Do not auto add vehicles");
        ui.PrintString("3. Quit program");
        uint option = Util.AskForUInt("Number of your choice?", ui); ;

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
                ui.PrintString("Goodbye!");
                Environment.Exit(0);
                break;

            default:
                ui.PrintString("Please Pick one of the below!");
                OptionalFillGarage();
                break;
        }
    }

    private void StartMenu()
    {

        ui.PrintString("Welcome to the garage");
        uint size = Util.AskForUInt("Amount of parking spots in your new garage?", ui); ;

        handler.CreateGarage(size);
        ui.PrintString("Your garage was created with " + size + " parking spots!");

    }


}