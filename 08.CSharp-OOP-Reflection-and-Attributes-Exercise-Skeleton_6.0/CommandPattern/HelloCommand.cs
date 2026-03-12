using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommandPattern.Core.Contracts;
using ICommand = CommandPattern.Core.Contracts.ICommand;

namespace CommandPattern
{
    internal class HelloCommand : ICommand
    {
        //public HelloCommand()
        //{
        //}
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}
