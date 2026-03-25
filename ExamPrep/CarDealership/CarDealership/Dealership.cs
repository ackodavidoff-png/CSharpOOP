using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership
{
    public class Dealership : IDealership
    {
        public Dealership()
        {
            this.Vehicles = new VehicleRepository();
            this.Customers = new CustomerRepository();
        }
        public IRepository<IVehicle> Vehicles { get; }
        public IRepository<ICustomer> Customers { get; }
    }
}
