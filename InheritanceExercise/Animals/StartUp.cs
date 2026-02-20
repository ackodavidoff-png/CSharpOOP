using System;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string type = Console.ReadLine();
                if (type == "Beast!")
                {
                    break;
                }
                try
                {
                    string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (data.Length < 3)
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string gender = data[2];
                    switch (type)
                    {
                        case "Dog":
                            Animal dog = new Dog(name, age, gender);
                            Print(type, dog.ToString());
                            break;
                        case "Cat":
                            Animal cat = new Cat(name, age, gender);
                            Print(type, cat.ToString());
                            break;
                        case "Frog":
                            Animal frog = new Frog(name, age, gender);
                            Print(type, frog.ToString());
                            break;
                        case "Kitten":
                            Animal kitten = new Kitten(name, age);
                            Print(type, kitten.ToString());
                            break;
                        case "Tomcat":
                            Animal tomcat = new Tomcat(name, age);
                            Print(type, tomcat.ToString());
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                    Console.WriteLine("Invalid input!");
                }
            }
        }
        private static void Print(string type, string animal)
        {
            Console.WriteLine(type);
            Console.WriteLine(animal);
        }
    }
    public abstract class Animal
    {
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        private string name;
        private int age;
        private string gender;
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            }
        }
        public string Gender
        {
            get
            {
                return this.gender;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.gender = value;
            }
        }
        public abstract string ProduceSound();
        //{
        //}
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine($"{this.ProduceSound()}");
            return sb.ToString().TrimEnd();//;base.ToString();
        }
    }
    public class Cat : Animal
    {
        private const string Sound = "Meow meow";
        public Cat(string name, int age, string gender) : base(name, age, gender)
        {
        }
        public override string ProduceSound() => Sound;
        //{
        //    throw new NotImplementedException();
        //}
    }
    public class Kitten : Cat
    {
        //private const string KittenGender = "Female";
        private const string Sound = "Meow";
        public Kitten(string name, int age) : base(name, age, "Female")
        {
        }
        public override string ProduceSound() => Sound;
        //{
        //    return base.ProduceSound();
        //}
    }
    public class Tomcat : Cat
    {
        //private const string KittenGender = "Male";
        private const string Sound = "MEOW";
        public Tomcat(string name, int age) : base(name, age, "Male")
        {
        }
        public override string ProduceSound() => Sound;
        //{
        //    return base.ProduceSound();
        //}
    }
    public class Dog : Animal
    {
        private const string Sound = "Woof!";
        public Dog(string name, int age, string gender) : base(name, age, gender)
        {
        }
        public override string ProduceSound() => Sound;
    }
    public class Frog : Animal
    {
        private const string Sound = "Ribbit";
        public Frog(string name, int age, string gender) : base(name, age, gender)
        {
        }
        public override string ProduceSound() => Sound;
    }
}
