namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> list = new List<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] info = Console.ReadLine().Split();
                string name = info[0];
                string surname = info[1];
                int age = int.Parse(info[2]);
                Person toAdd = new Person(name, surname, age);
                list.Add(toAdd);
            }
            list = list.OrderBy(person  => person.FirstName).ThenBy(person => person.Age).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].ToString());
            }
        }
    }
}
