using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Interfaces;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string num)
        {
            for(int i = 0; i < num.Length; i++)
            {
                if(!char.IsDigit(num[i]))
                {
                    throw new ArgumentException("Invalid number!");
                }
            }
            //if (num.Any(d => char.IsDigit(d)))
            //{
            //    throw new ArgumentException("Invalid number!");
            //}
            return $"Dialing... {num}";
        }
    }
}
