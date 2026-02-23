namespace ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Person> people = new List<Person>();
                List<Product> products = new List<Product>();
                string[] input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (string inputItem in input)
                {
                    string[] arguments = inputItem.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    string name = arguments[0];
                    decimal balance = decimal.Parse(arguments[1]);
                    Person toAdd = new Person(name, balance);
                    people.Add(toAdd);
                }
                input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (string item  in input)
                {
                    string[] arguments = item.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = arguments[0];
                    decimal price = decimal.Parse(arguments[1]);
                    Product toAdd = new Product(name, price);
                    products.Add(toAdd);
                }
                while(true)
                {
                    string input1 = Console.ReadLine();
                    if(input1 == "END")
                    {
                        foreach (var person in people)
                        {
                            Console.WriteLine(person);
                        }
                        break;
                    }
                    string[] arguments = input1.Split();
                    string personName = arguments[0];
                    string productName = arguments[1];
                    Person toShop = people.First(p => p.Name == personName);
                    Product toBuy = products.First(a => a.Name == productName);
                    toShop.BuyProduct(toBuy);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
