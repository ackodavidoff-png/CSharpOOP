using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership
{
    public class CustomerRepository : IRepository<ICustomer>
    {
        public CustomerRepository()
        {
            customers = new List<ICustomer>();
        }
        private readonly List<ICustomer> customers;
        public IReadOnlyCollection<ICustomer> Models => customers.AsReadOnly();

        public void Add(ICustomer model)
        {
            this.customers.Add(model);
        }

        public bool Exists(string text)
        {
            return this.customers.Any(c => c.Name == text);
        }

        public ICustomer Get(string text)
        {
            return this.customers.FirstOrDefault(c => c.Name == text);
        }

        public bool Remove(string text)
        {
            ICustomer customer = this.customers.FirstOrDefault(c => c.Name == text);
            if (customer == null)
            {
                return false;
            }
            customers.Remove(customer);
            return true;
        }
    }
}
