using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership
{
    public abstract class Vehicle : IVehicle
    {
        private string model;
        private double price;
        private readonly List<string> buyers;
        protected Vehicle(string model, double price)
        {
            this.Model = model;
            this.Price = price;
            buyers = new List<string>();
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelIsRequired);
                }
                this.model = value; 
            }
        }

        public virtual double Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PriceMustBePositive);
                }
                this.price = value;
            }
        }

        public IReadOnlyCollection<string> Buyers => this.buyers.AsReadOnly();//{ get; private set; }

        public int SalesCount => buyers.Count;//{ get; private set;  }

        public void SellVehicle(string buyerName)
        {
            buyers.Add(buyerName);
        }
        public override string ToString()
        {
            return $"{Model} - Price: {Price:F2}, Total Model Sales: {SalesCount}";// base.ToString();
        }
    }
}
