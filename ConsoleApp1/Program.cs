//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//OOP Assignment
Console.WriteLine("Welcome to Tool Vehicle Tax Management System");
Console.WriteLine();

Console.Write("Enter the number of vehicles: ");
int numVehicles = int.Parse(Console.ReadLine());

for (int i = 0; i < numVehicles; i++)
{
    Console.WriteLine($"\nEnter details for vehicle {i + 1}:");
    Console.Write("Vehicle ID: ");
    int vehicleID = int.Parse(Console.ReadLine());

    Console.Write("Registration Number: ");
    string regNo = Console.ReadLine();

    Console.Write("Model: ");
    int model =Convert.ToInt32(Console.ReadLine());

    Console.Write("Brand: ");
    string brand = Console.ReadLine();


    Console.Write("Vehicle Type:\n1.Car\n2.Bike\n3.HeavyVehicle: ");
    int vehicleType =Convert.ToInt32(Console.ReadLine());

    ToolVehicle vehicle = null;

    switch (vehicleType)
    {
        case 1:
            vehicle = new Car(vehicleID, regNo, model, brand);
            break;
        case 2:
            vehicle = new Bike(vehicleID, regNo, model, brand);
            break;
        case 3:
            vehicle = new HeavyVehicle(vehicleID, regNo, model, brand);
            break;
        default:
            Console.WriteLine("Invalid vehicle type!");
            continue;
    }

    Console.Write("Did the vehicle pay tax? (yes/no): ");
    string payTax = Console.ReadLine().ToLower();

    if (payTax == "yes")
    {
        vehicle.PayTax();
    }
    else
    {
        vehicle.TotNonTaxpay();
    }
}

// Displaying statistics
Console.WriteLine($"\nTotal Vehicles: {ToolVehicle.TotalVehicles}");
Console.WriteLine($"Total Tax Paying Vehicles: {ToolVehicle.TotalTaxPayingVehicles}");
Console.WriteLine($"Total Non-Tax Paying Vehicles: {ToolVehicle.TotalNonTaxPayingVehicles}");
Console.WriteLine($"Total Tax Collected: {ToolVehicle.TotalTaxCollected:C}");


public abstract class ToolVehicle
{
    int VehicleID;
    string RegNo;
    int Model;
    string Brand;
    string VehicleType;

    public static int TotalVehicles = 0;
    public static int TotalTaxPayingVehicles = 0;
    public static int TotalNonTaxPayingVehicles = 0;
    public static decimal TotalTaxCollected = 0;
    public  ToolVehicle(int VehicleID, string RegNo,int Model,string Brand,string VehicleType)
    {
        this.VehicleID = VehicleID;
        this.RegNo = RegNo;
        this.Model = Model;
        this.Brand = Brand;
        this.VehicleType = VehicleType;
        TotalVehicles++; 
    }
    public abstract void PayTax();
   
 
    public  void TotNonTaxpay()
    {
        TotalNonTaxPayingVehicles++;
    }
    protected void UpdateTax(decimal taxAmount)
    {
        TotalTaxCollected += taxAmount;
        TotalTaxPayingVehicles++;
    }

}

public class Car : ToolVehicle
{
   
    public Car(int VehicleID, string RegNo, int Model, string Brand):base(VehicleID,RegNo,Model,Brand,"Car")
    {
       
    }
   

    public override void PayTax()
    {
        const decimal taxAmount = 2.0m;
        UpdateTax(taxAmount);
    }
    
}
public class Bike : ToolVehicle
{

    public Bike(int VehicleID, string RegNo, int Model, string Brand) : base(VehicleID, RegNo, Model, Brand,  "Bike")
    {

    }


    public override void PayTax()
    {
        const decimal taxAmount = 1.0m;
        UpdateTax(taxAmount);
    }

}
public class HeavyVehicle : ToolVehicle
{

    public HeavyVehicle(int VehicleID, string RegNo, int Model, string Brand) : base(VehicleID, RegNo, Model, Brand,  "HeavyBike")
    {

    }

    
    public override void PayTax()
    {
        const decimal taxAmount = 4.0m;
        UpdateTax(taxAmount);
    }

}
