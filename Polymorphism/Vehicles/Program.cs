namespace Vehicles;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        List<IVehicle> vehicles = new List<IVehicle>();
        string[] carTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        double fuelQuantity = double.Parse(carTokens[1]);
        double fuelConsumption = double.Parse(carTokens[2]);
        IVehicle  car = new Car(fuelQuantity, fuelConsumption);
        vehicles.Add(car);
        string[] truckTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        double truckQuantity = double.Parse(truckTokens[1]);
        double truckConsumption = double.Parse(truckTokens[2]);
        IVehicle truck = new Truck(truckQuantity, truckConsumption);
        vehicles.Add(truck);
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = input[0];
            string vehicle = input[1];
            IVehicle v = vehicles.FirstOrDefault(x => x.GetType().Name == vehicle);
            if (v == null)
            {
                Console.WriteLine("Invalid vehicle type");
            }
            if (command == "Drive")
            {
                double distance = double.Parse(input[2]);
                Console.WriteLine(v.Drive(distance));
            }
            else if (command == "Refuel")
            {
                double fuelAmount = double.Parse(input[2]);
                v.Refuel(fuelAmount);
            }
        }

        foreach (IVehicle vehicle in vehicles)
        {
            Console.WriteLine(vehicle.ToString());
        }
    }
}