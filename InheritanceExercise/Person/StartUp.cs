using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            if (age < 0)
            {
                Console.WriteLine("Age must be positive!");
            }
            else if (age > 15)
            {
                Person person = new Person(name, age);
                Console.WriteLine(person.ToString());
            }
            else
            {
                Child child = new Child(name, age);
                Console.WriteLine(child.ToString());
            }

        }
    }
    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"Person -> Name: {this.Name}, Age: {this.Age}";//base.ToString();
        }
    }
    public class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {
        }
        public override string ToString()
        {
            return $"Child -> Name: {this.Name}, Age: {this.Age}";//base.ToString();
        }
    }
}