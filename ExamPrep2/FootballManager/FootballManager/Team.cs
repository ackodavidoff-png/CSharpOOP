using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * namespace FootballManager.Utilities.Messages
{
    public class ExceptionMessages
    {
        public const string ManagerNameNull = "Manager's name cannot be null or empty.";
        public const string TeamNameNull = "Team name cannot be null or empty.";
    }
}
namespace FootballManager.Utilities.Messages
{
    public class OutputMessages
    {
        //Common
        public const string ManagerTypeNotPresented = "{0} is an invalid manager type for the application.";
        public const string ManagerAssignedToAnotherTeam = "Manager {0} is already assigned to another team.";

        //Join Championship
        public const string TeamWithSameNameExisting = "{0} has already joined the Championship.";
        public const string TeamSuccessfullyJoined = "{0} has successfully joined the Championship.";
        public const string ChampionshipFull = "Championship is full!";

        //Sign Manager
        public const string TeamDoesNotTakePart = "Team {0} does not take part in the Championship.";
        public const string TeamSignedWithAnotherManager = "Team {0} has already signed a contract with {1}.";
        public const string TeamSuccessfullySignedWithManager = "Manager {0} is assigned to team {1}.";

        //Match Between       
        public const string OneOfTheTeamDoesNotExist = "This match does not meet the regulation rules of the Championship.";
        public const string TeamWinsMatch = "Team {0} wins the match against {1}.";
        public const string MatchIsDraw = "The match between {0} and {1} ends in a draw.";

        //Promote Team        
        public const string DroppingTeamDoesNotExist = "Team {0} does not exist in the Championship.";
        public const string TeamHasBeenPromoted = "Team {0} wins a promotion for the new season.";
    }
}

 */
namespace FootballManager
{
    internal class Team : ITeam
    {
        public Team(string name)
        {
            this.Name = name;
            this.ChampionshipPoints = 0;
        }
        private string _name;
        public string Name
        {
            get
            {
                return this._name; 
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.TeamNameNull);
                }
                this._name = value;
            }
        }

        public int ChampionshipPoints { get; private set; }

        public IManager TeamManager { get; private set; }

        public int PresentCondition
        {
            get
            {
                if(this.TeamManager == null)
                {
                    return 0;
                }
                if (this.ChampionshipPoints == 0)
                {
                    return (int)Math.Floor(this.TeamManager.Ranking);
                }
                return (int)Math.Floor(this.ChampionshipPoints * this.TeamManager.Ranking);
            }
        }

        public void GainPoints(int points)
        {
            this.ChampionshipPoints += points;
        }

        public void ResetPoints()
        {
            this.ChampionshipPoints = 0;
        }

        public void SignWith(IManager manager)
        {
            this.TeamManager = manager;
        }
        public override string ToString()
        {
            return $"Team: {this.Name} Points: {this.ChampionshipPoints}";
        }
    }
}
