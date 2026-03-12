using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            //throw new NotImplementedException();
            //return Console.ReadLine();
            string[] arr = args.Split(' ');
            string command = arr[0];
            string className = $"{command}Command";
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == className);
            if (type == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }
            ICommand command1 = (ICommand)Activator.CreateInstance(type);
            return command1.Execute(arr.Skip(1).ToArray());
        }
    }
}
