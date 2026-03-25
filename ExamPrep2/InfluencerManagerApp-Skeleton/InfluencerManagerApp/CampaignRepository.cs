using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp
{
    internal class CampaignRepository : IRepository<ICampaign>
    {
        public CampaignRepository()
        {
            models = new List<ICampaign>();
        }
        private readonly List<ICampaign> models;
        public IReadOnlyCollection<ICampaign> Models => models.AsReadOnly();

        public void AddModel(ICampaign model)
        {
            models.Add(model);
        }

        public ICampaign FindByName(string name)
        {
            return models.FirstOrDefault(campaign => campaign.Brand == name);
        }

        public bool RemoveModel(ICampaign model)
        {
            return models.Remove(model);
        }
    }
}
