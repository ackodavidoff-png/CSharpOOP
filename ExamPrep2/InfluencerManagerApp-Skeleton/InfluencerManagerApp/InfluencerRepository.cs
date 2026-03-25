using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp
{
    internal class InfluencerRepository : IRepository<IInfluencer>
    {
        public InfluencerRepository()
        {
            influencers = new List<IInfluencer>();
        }
        private readonly List<IInfluencer> influencers;
        public IReadOnlyCollection<IInfluencer> Models => influencers.AsReadOnly();

        public void AddModel(IInfluencer model)
        {
            influencers.Add(model);
        }

        public IInfluencer FindByName(string name)
        {
            return influencers.FirstOrDefault(influencer => influencer.Username == name);
        }

        public bool RemoveModel(IInfluencer model)
        {
            return influencers.Remove(model);
        }   
    }
}
