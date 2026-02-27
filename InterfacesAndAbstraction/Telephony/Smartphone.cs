using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Interfaces;

namespace Telephony
{
    internal class Smartphone : ICallable, IBrowsable
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
            return $"Calling... {num}";
        }
        public string Browse(string url)
        {
            for(int i = 0; i < url.Length; i++)
            {
                if (char.IsDigit(url[i]))
                {
                    throw new ArgumentException("Invalid URL!");
                }
            }
            return $"Browsing: {url}!";
        }
    }
}
