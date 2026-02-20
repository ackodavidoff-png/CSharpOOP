using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double CakeGrams = 250;
        private const double CakeCalories = 1000;
        private const decimal CakePrice = (Decimal)5; //EUR
        public Cake(string name) : base(name, CakePrice, CakeGrams, CakeCalories)//, decimal price, double grams, double calories) : base(name, price, grams, calories)
        {
        }
    }
}
