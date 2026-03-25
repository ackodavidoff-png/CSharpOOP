using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager
{
    public class AmateurManager : Manager
    {
        private const double InitialRanking = 15;
        public AmateurManager(string name) : base(name, InitialRanking)
        {
        }

        public override void RankingUpdate(double updateValue)
        {
            base.Ranking += updateValue * 0.75;
        }
    }
}
