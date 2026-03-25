using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday
{
    internal class Admin : User
    {
        public Admin(string username, string password) : base(username, password)
        {
        }
        public override bool HasDataAccess => true;
    }
}
