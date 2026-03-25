using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp
{
    public abstract class Influencer : IInfluencer
    {
        public Influencer(string username, int followers, double engagementRate)
        {
            this.Username = username;
            this.Followers = followers;
            this.EngagementRate = engagementRate;
            this.participants = new List<string>();
            this.Income = 0;
        }
        private string username;
        private int followers;
        private readonly List<string> participants;
        public string Username
        {
            get
            {
                return this.username; 
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
                }
                this.username = value;
            }
        }

        public int Followers
        {
            get
            {
                return this.followers; 
            }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
                }
                this.followers = value;
            }
        }

        public double EngagementRate { get; protected set; }

        public double Income {  get; private set; }

        public IReadOnlyCollection<string> Participations => participants.AsReadOnly();

        public abstract int CalculateCampaignPrice();
        public void EarnFee(double amount)
        {
            this.Income += amount;
        }

        public void EndParticipation(string brand)
        {
            this.participants.Remove(brand);
        }

        public void EnrollCampaign(string brand)
        {
            this.participants.Add(brand);
        }
        public override string ToString()
        {
            return $"{Username} - Followers: {Followers}, Total Income: {Income}";
        }
    }
}
