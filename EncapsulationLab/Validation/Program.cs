namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> staff = new List<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] info = Console.ReadLine().Split();
                    string name = info[0];
                    string surname = info[1];
                    int age = int.Parse(info[2]);
                    decimal salary = decimal.Parse(info[3]);
                    Person toAdd = new Person(name, surname, age, salary);
                    staff.Add(toAdd);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            decimal percentage = decimal.Parse(Console.ReadLine());
            staff.ForEach(worker => worker.IncreaseSalary(percentage));
            for (int i = 0; i < staff.Count; i++)
            {
                Console.WriteLine(staff[i].ToString());
            }
        }
    }
}
