namespace PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] tokens1 = Console.ReadLine().Split(' ');
                string[] tokens2 = Console.ReadLine().Split(' ');
                string name = tokens1[1];
                Dough dough = new Dough(tokens2[1], tokens2[2], double.Parse(tokens2[3]));
                Pizza pizza = new Pizza(name, dough);
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "END")
                    {
                        break;
                    }
                    string[] tokens = input.Split();
                    Topping topping = new Topping(tokens[1], double.Parse(tokens[2]));
                    pizza.AddTopping(topping);
                }
                Console.WriteLine(pizza.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);// ToString());
            }
        }
    }
}
