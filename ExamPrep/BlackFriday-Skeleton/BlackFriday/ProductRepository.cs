using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday
{
    internal class ProductRepository : IRepository<IProduct>
    {
        public ProductRepository()
        {
            models = new List<IProduct>();
        }
        private List<IProduct> models;
        public IReadOnlyCollection<IProduct> Models => models.AsReadOnly();

        public void AddNew(IProduct model)
        {
            models.Add(model);
        }

        public bool Exists(string name)
        {
            return models.Any(p => p.ProductName == name);
        }

        public IProduct GetByName(string name)
        {
            return models.FirstOrDefault(p => p.ProductName == name);
        }
    }
}
