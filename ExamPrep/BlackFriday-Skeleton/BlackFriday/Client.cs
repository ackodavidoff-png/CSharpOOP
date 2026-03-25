using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday
{
    internal class Client : User
    {
        public Client(string  username, string password) : base(username, password)
        {
            purchases = new Dictionary<string, bool>();
        }
        private Dictionary<string, bool> purchases;
        public override bool HasDataAccess => false;
        public IReadOnlyDictionary<string, bool> Purchases => purchases;
        public void PurchaseProduct(string productName, bool blackFridayFlag)
        {
            purchases.Add(productName, blackFridayFlag);
        }

    }
}
