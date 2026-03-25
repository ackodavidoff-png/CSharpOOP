using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday
{
    public abstract class Product : IProduct
    {
        protected Product(string productName, double basePrice)
        {
            this.ProductName = productName;
            this.BasePrice = basePrice;
            this.IsSold = false;
        }
        private string productName;
        private double basePrice;
        public string ProductName
        {
            get
            {
                return productName; 
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ProductNameRequired);
                }
                productName = value;
            }
        }

        public double BasePrice
        {
            get
            {
                return basePrice; 
            }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.ProductPriceConstraints);
                }
                basePrice = value; 
            }
        }

        public virtual double BlackFridayPrice => this.BasePrice;

        public bool IsSold { get; private set;  }

        public void ToggleStatus()
        {
            this.IsSold = !this.IsSold;
        }

        public void UpdatePrice(double newPriceValue)
        {
            this.BasePrice = newPriceValue;
        }
        public override string ToString()
        {
            return $"Product: {this.ProductName}, Price: {this.BasePrice:F2}, You Save: {(this.BasePrice-BlackFridayPrice):F2}";
        }
    }
}
