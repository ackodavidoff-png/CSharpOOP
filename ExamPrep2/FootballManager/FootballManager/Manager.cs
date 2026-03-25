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
    public abstract class Manager : IManager
    {
        protected Manager(string name, double ranking)
        {
            this.Name = name;
            this.Ranking = ranking;
        }
        private string name;
        private double ranking;
        public string Name 
        {
            get
            {
                return this.name; 
            }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ManagerNameNull);
                }
                this.name = value; 
            }
        }

        public double Ranking
        {
            get
            {
                return this.ranking; 
            }
            protected set
            {
                if (value < 0)
                {
                    this.ranking = 0;
                }
                else if (value > 100)
                {
                    this.ranking = 100;
                }
                else
                {
                    this.ranking = value;
                }
            }
        }

        public abstract void RankingUpdate(double updateValue);
        //{
        //    throw new NotImplementedException();
        //}
        public override string ToString()
        {
            return @$"{this.Name} - {this.GetType().Name} (Ranking: {this.Ranking:F2})";//base.ToString();
        }
    }
}
