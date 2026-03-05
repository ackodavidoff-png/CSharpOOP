namespace Vehicles;

public interface IVehicle
{
    double FuelQuantity { get; }
    double FuelConsumption { get; }
    //double FuelCapacity { get; }
    string Drive(double distance);
    void Refuel(double amount);
}