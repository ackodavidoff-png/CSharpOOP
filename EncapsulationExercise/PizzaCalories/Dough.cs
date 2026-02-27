using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    internal class Dough
    {
        private const double BaseCalories = 2;
        private string flourType;
        private string bakingTechnique;
        private double weight;
        private Dictionary<string, double> flourTypes;
        private Dictionary<string, double> bakingTechniques;
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            flourTypes = new Dictionary<string, double>()
            {
                {
                    "white",
                    1.5
                },
                {
                    "wholegrain",
                    1
                }
            };
            bakingTechniques = new Dictionary<string, double>()
            {
                {
                    "crispy",
                    0.9
                },
                {
                    "chewy",
                    1.1
                },
                {
                    "homemade",
                    1
                }
            };
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
            //this.flourTypes = flourTypes;
            //this.bakingTechniques = bakingTechniques;
            //FlourType = flourType;
            //BakingTechnique = bakingTechnique;
            //Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (!flourTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value.ToLower();
            }
        }
        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (!bakingTechniques.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value.ToLower();
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(@"Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }
        public double Calories
        {
            get
            {
                double flour = flourTypes[this.FlourType];
                double technique = bakingTechniques[this.BakingTechnique];
                //return BaseCalories * technique * flour;
                return BaseCalories * this.Weight * flour * technique;
            }
        }
    }
}
