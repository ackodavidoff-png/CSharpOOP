using FootballManager.Core.Contracts;
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
    public class Controller : IController
    {
        private TeamRepository championship;
        public Controller()
        {
            championship = new TeamRepository();
        }
        public string ChampionshipRankings()
        {
            List<ITeam> ordered = championship.Models.OrderByDescending(team => team.ChampionshipPoints).ThenByDescending(team => team.PresentCondition).ToList();
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            sb.AppendLine(@"***Ranking Table***");
            for(int i = 0; i < ordered.Count; i++)
            {
                sb.AppendLine($"{i + 1}. {ordered[i]}/{ordered[i].TeamManager}");
            }
            return sb.ToString().TrimEnd();
        }

        public string JoinChampionship(string teamName)
        {
            if(championship.Models.Count >= championship.Capacity)
            {
                return OutputMessages.ChampionshipFull;
            }
            if(championship.Exists(teamName))
            {
                return string.Format(OutputMessages.TeamWithSameNameExisting, teamName);
            }
            championship.Add(new  Team(teamName));
            return string.Format(OutputMessages.TeamSuccessfullyJoined, teamName);
        }

        public string MatchBetween(string teamOneName, string teamTwoName)
        {
            ITeam team1 = championship.Get(teamOneName);
            ITeam team2 = championship.Get(teamTwoName);
            if(team1 == null || team2 == null)
            {
                return OutputMessages.OneOfTheTeamDoesNotExist;
            }
            if(team1.PresentCondition >  team2.PresentCondition)
            {
                team1.GainPoints(3);
                team1.TeamManager?.RankingUpdate(5);
                team2.TeamManager?.RankingUpdate(-5);
                return string.Format(OutputMessages.TeamWinsMatch, team1.Name, team2.Name);
            }
            else if(team2.PresentCondition > team1.PresentCondition)
            {
                team2.GainPoints(3);
                team1.TeamManager?.RankingUpdate(-5);
                team2.TeamManager?.RankingUpdate(5);
                return string.Format(OutputMessages.TeamWinsMatch, team2.Name, team1.Name);
            }
            else
            {
                team1.GainPoints(1);
                team2.GainPoints(1);
                return string.Format(OutputMessages.MatchIsDraw, team1.Name, team2.Name);
            }
        }

        public string PromoteTeam(string droppingTeamName, string promotingTeamName, string managerTypeName, string managerName)
        {
            ITeam droppingTeam = championship.Get(droppingTeamName);
            if(droppingTeam == null)
            {
                return string.Format(OutputMessages.DroppingTeamDoesNotExist, droppingTeamName);
            }
            if (championship.Exists(promotingTeamName))
            {
                return string.Format(OutputMessages.TeamWithSameNameExisting, promotingTeamName);
            }
            ITeam newTeam = new Team(promotingTeamName);
            bool managerExists = championship.Models.Any(team => team.TeamManager != null && team.TeamManager.Name == managerName);
            IManager manager;
            switch(managerTypeName)
            {
                case "AmateurManager":
                    manager = new AmateurManager(managerName);
                    break;
                case "SeniorManager":
                    manager = new SeniorManager(managerName);
                    break;
                case "ProfessionalManager":
                    manager = new ProfessionalManager(managerName);
                    break;
                default:
                    manager = null;
                    break;
            }
            if (!managerExists && manager != null)
            {
                newTeam.SignWith(manager);
            }
            foreach (ITeam team in championship.Models)
            {
                team.ResetPoints();
            }
            championship.Remove(droppingTeamName);
            championship.Add(newTeam);
            //throw new NotImplementedException();
            return $"Team {promotingTeamName} wins a promotion for the new season.";
        }

        public string SignManager(string teamName, string managerTypeName, string managerName)
        {
            ITeam team = championship.Get(teamName);
            if(team == null)
            {
                return string.Format(OutputMessages.TeamDoesNotTakePart, teamName);
            }
            IManager manager;
            switch (managerTypeName)
            {
                case "AmateurManager":
                    manager = new AmateurManager(managerName);
                    break;
                case "SeniorManager":
                    manager = new SeniorManager(managerName);
                    break;
                case "ProfessionalManager":
                    manager = new ProfessionalManager(managerName);
                    break;
                default:
                    return string.Format(OutputMessages.ManagerTypeNotPresented, managerTypeName);
            }
            if(team.TeamManager != null)
            {
                return string.Format(OutputMessages.TeamSignedWithAnotherManager, teamName, team.TeamManager.Name);
                //return string.Format(OutputMessages.TeamSignedWithAnotherManager, teamName, managerName);
            }
            if (championship.Models.Any(t => t.TeamManager != null && t.TeamManager.Name == managerName))
            {
                return string.Format(OutputMessages.ManagerAssignedToAnotherTeam, managerName);
            }
            team.SignWith(manager);
            return string.Format(OutputMessages.TeamSuccessfullySignedWithManager, managerName, teamName);
            //return string.Format(OutputMessages.TeamSignedWithAnotherManager, teamName, team.TeamManager.Name);
        }
    }
}
