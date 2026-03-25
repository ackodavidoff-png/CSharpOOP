using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        public VehicleRepository()
        {
            this.models = new List<IVehicle>();
        }
        private readonly List<IVehicle> models;
        public IReadOnlyCollection<IVehicle> Models => models.AsReadOnly();

        public void Add(IVehicle model)
        {
            this.models.Add(model);
        }

        public bool Exists(string text)
        {
            return this.models.Any(v => v.Model == text);
        }

        public IVehicle Get(string text)
        {
            return models.FirstOrDefault(v => v.Model == text);
        }

        public bool Remove(string text)
        {
            IVehicle model = this.models.FirstOrDefault(v => v.Model == text);
            if (model == null)
            {
                return false;
            }
            this.models.Remove(model);
            return true;
        }
    }
}
