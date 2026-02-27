using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    internal class Pizza
    {
        private string name;
        private List<Topping> toppings;
        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            toppings = new List<Topping>();
        }
        public string Name
        {
            get => this.name;
            set
            {
                if(value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        public Dough Dough
        {
            get;
            set;
        }
        public double Calories
        {
            get
            {
                return Dough.Calories + toppings.Sum(t => t.Calories);
            }
        }
        public void AddTopping(Topping topping)
        {
            if(toppings.Count == 10)
            {
                throw new ArgumentException(@"Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Calories:F2} Calories.";// base.ToString();
        }
    }
}
