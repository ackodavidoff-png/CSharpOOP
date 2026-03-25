using FootballManager.Models.Contracts;
using FootballManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager
{
    internal class TeamRepository : IRepository<ITeam>
    {
        private readonly List<ITeam> teams;
        public TeamRepository()
        {
            this.teams = new List<ITeam>(); 
        }
        public IReadOnlyCollection<ITeam> Models => teams.AsReadOnly();

        public int Capacity => 10;

        public void Add(ITeam model)
        {
            if(this.teams.Count < 10)
            {
                this.teams.Add(model);
            }
        }

        public bool Exists(string name)
        {
            return this.teams.Any(t => t.Name == name);
        }

        public ITeam Get(string name)
        {
            return teams.FirstOrDefault(t => t.Name == name);
        }

        public bool Remove(string name)
        {
            ITeam team = Get(name);
            if (team == null)
            {
                return false;
            }
            this.teams.Remove(team);
            return true;
        }
    }
}
