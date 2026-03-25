using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday
{
    internal class Application : IApplication
    {
        public Application()
        {
            this.Products = new ProductRepository();
            this.Users = new UserRepository();
        }
        public IRepository<IProduct> Products { get; private set; }

        public IRepository<IUser> Users  { get; private set; }
    }
}
