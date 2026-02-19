using System;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine();
        }
    }
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            //this.FuelConsumption = 1.25;
        }
        public virtual double DefaultFuelConsumption => 1.25;
        //{
        //    get;
        //    set;
        //}
        public virtual double FuelConsumption => this.DefaultFuelConsumption;
        //{
        //    get;
        //    set;
        //}
        public double Fuel
        {
            get;
            set;
        }
        public int HorsePower
        {
            get;
            set;
        }
        virtual public void Drive(double kilometers)
        {
            //The default fuel consumption for Vehicle is 1.25.Some of the classes have different default fuel consumption values:
            //•	SportCar – DefaultFuelConsumption = 10
            //•	RaceMotorcycle – DefaultFuelConsumption = 8
            //•	Car – DefaultFuelConsumption = 3
            //Zip your solution without the bin and obj folders and upload it in Judge.
            //this.DefaultFuelConsumption = 1.25;
            double fuelNeeded = kilometers * this.FuelConsumption;
            if(Fuel >= fuelNeeded)
            {
                this.Fuel -= fuelNeeded;
            }
        }
    }
    public class Motorcycle : Vehicle
    {
        public Motorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
            //this.DefaultFuelConsumption = 1.25;
        }
    }
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
            //this.DefaultFuelConsumption = 8;
        }
        public override double DefaultFuelConsumption => 8;
    }
    public class CrossMotorcycle : Motorcycle
    {
        public CrossMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
    }
    public class Car : Vehicle
    {
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
            //this.DefaultFuelConsumption = 3;
        }
        public override double DefaultFuelConsumption => 3;
    }
    public class FamilyCar : Car
    {
        public FamilyCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
    }
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
            //this.DefaultFuelConsumption = 10;
        }
        public override double DefaultFuelConsumption => 10;
    }
}
