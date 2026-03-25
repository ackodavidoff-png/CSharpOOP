using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership
{
    public abstract class Customer : ICustomer
    {
        protected Customer(string name)
        {
            this.Name = name;
            this.purchases = new List<string>();
        }
        private string name;
        private readonly List<string> purchases;
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.NameIsRequired);
                }
                this.name = value;
            }
        }

        public IReadOnlyCollection<string> Purchases => this.purchases;

        public void BuyVehicle(string vehicleModel)
        {
            purchases.Add(vehicleModel);
        }
        public override string ToString()
        {
            return $"{this.Name} - Purchases: {this.purchases.Count}";
        }
    }
}
