using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp
{
    public class FashionInfluencer : Influencer
    {
        //private const double engagementRate = 4;
        private const double factor = 0.1;
        public FashionInfluencer(string username, int followers) : base(username, followers, 0)
        {
            EngagementRate = 4;
        }
        public override int CalculateCampaignPrice()
        {
            return (int)Math.Floor(Followers * EngagementRate * factor);
        }
    }
}
