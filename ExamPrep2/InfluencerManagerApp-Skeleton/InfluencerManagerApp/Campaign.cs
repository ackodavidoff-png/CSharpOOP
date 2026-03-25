using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp
{
    public abstract class Campaign : ICampaign
    {
        public Campaign(string brand, double budget)
        {
            this.Brand = brand;
            this.Budget = budget;
            contributors = new List<string>();
        }
        private string brand;
        private readonly List<string> contributors;
        public string Brand
        {
            get
            {
                return brand; 
            }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandIsRequired);
                }
                brand = value;
            }
        }

        //public double Budget { get; private set; }
        public double Budget { get; private set; }

        public IReadOnlyCollection<string> Contributors
        {
            get
            {
                return contributors.AsReadOnly(); 
            }
        }

        public void Engage(IInfluencer influencer)
        {
            if (!contributors.Contains(influencer.Username))
            {
                int price = influencer.CalculateCampaignPrice();
                contributors.Add(influencer.Username);
                Budget -= price;
            }
        }

        public void Gain(double amount)
        {
            Budget += amount;
        }
        public override string ToString()
        {
            return $"{GetType().Name} - Brand: {Brand}, Budget: {Budget}, Contributors: {contributors.Count}";
        }
    }
}
