using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    internal class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            //string input = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                string result = commandInterpreter.Read(input);
                if (result != null)
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
}