using CarDealership.Core.Contracts;
using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership
{
    internal class Controller : IController
    {
        public Controller()
        {
            dealership = new Dealership();
        }
        private readonly IDealership dealership;
        public string AddCustomer(string customerTypeName, string customerName)
        {
            ICustomer customer;// = new Customer();
            if (customerTypeName == nameof(IndividualClient))
            {
                customer = new IndividualClient(customerName);
            }
            else if (customerTypeName == nameof(LegalEntityCustomer))
            {
                customer = new LegalEntityCustomer(customerName);
            }
            else
            {
                return string.Format(OutputMessages.InvalidType, customerTypeName);
            }
            if(this.dealership.Customers.Exists(customerName))
            {
                return string.Format(OutputMessages.CustomerAlreadyAdded, customerName);
            }
            this.dealership.Customers.Add(customer);
            return string.Format(OutputMessages.CustomerAddedSuccessfully, customerName);
        }

        public string AddVehicle(string vehicleTypeName, string model, double price)
        {
            IVehicle vehicle;
            if(vehicleTypeName == nameof(SaloonCar))
            {
                vehicle = new SaloonCar(model, price);
            }
            else if(vehicleTypeName == nameof(SUV))
            {
                vehicle = new SUV(model, price);
            }
            else if(vehicleTypeName == nameof(Truck))
            {
                vehicle = new Truck(model, price);
            }
            else
            {
                return $"{vehicleTypeName} is not a valid type.";
            }
            if (dealership.Vehicles.Exists(model))
            {
                return $"{model} already exists as an offer in the dealership.";
            }
            this.dealership.Vehicles.Add(vehicle);
            return $"{vehicleTypeName}: {model} is listed in the dealership. Price: {vehicle.Price:F2}";
        }

        public string CustomerReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Customer Report:");
            foreach (ICustomer customer in this.dealership.Customers.Models.OrderBy(x => x.Name)) //в началото имаше въпрос
            {
                sb.AppendLine(customer.ToString());
                sb.AppendLine("-Models:");
                if(customer.Purchases.Any())
                {
                    foreach(string purchase in customer.Purchases.OrderBy(x => x))//в началото имаше въпрос
                    {
                        sb.AppendLine($"--{purchase}");
                    }
                }
                else
                {
                    sb.AppendLine("--none");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string PurchaseVehicle(string vehicleTypeName, string customerName, double budget)
        {
            ICustomer customer = dealership.Customers.Get(customerName);
            if (customer == null)
            {
                return $"{customerName} has no profile in the dealership.";
            }
            List<IVehicle> vehicles = dealership.Vehicles.Models.Where(v => v.GetType().Name == vehicleTypeName).ToList();
            if(!vehicles.Any())
            {
                return $"{vehicleTypeName} is not listed for sale in the dealership.";
            }
            if (customer is IndividualClient && !(vehicleTypeName == nameof(SaloonCar) || vehicleTypeName == nameof(SUV)))
            {
                return $"{customerName} is not eligible to purchase a {vehicleTypeName}.";
            }
            if (customer is LegalEntityCustomer && !(vehicleTypeName == nameof(SUV) || vehicleTypeName == nameof(Truck)))
            {
                return $"{customerName} is not eligible to purchase a {vehicleTypeName}.";
            }
            IVehicle? affordable = vehicles.Where(v => v.Price <= budget).OrderByDescending(v =>  v.Price).FirstOrDefault();
            if (affordable == null)
            {
                return $"{customerName} does not have enough budget to purchase {vehicleTypeName}.";
            }
            customer.BuyVehicle(affordable.Model);
            affordable.SellVehicle(customer.Name);
            return $"{customerName} purchased a {affordable.Model}."; //Да не забравя да добавя знака за долар.
        }

        public string SalesReport(string vehicleTypeName)
        {
            StringBuilder sb = new StringBuilder();
            List<IVehicle> vehicles = dealership.Vehicles.Models.Where(v => v.GetType().Name == vehicleTypeName).OrderBy(v => v.Model).ToList();
            sb.AppendLine($"{vehicleTypeName} Sales Report:");
            int total = 0;
            foreach (IVehicle vehicle in vehicles)
            {
                total += vehicle.SalesCount;
                sb.AppendLine($"--{vehicle}");
            }
            sb.AppendLine($"-Total Purchases: {total}");
            return sb.ToString().TrimEnd();
        }
    }
}
