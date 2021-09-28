using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamProject2.Data
{
   public class DevTeamContents
    {
        //Plain Old C# Objects
        public string TeamName { get; set; }

        public List<DevContents> ListOfTeam { get; set; }

        public int TeamId { get; set; }

        //Constructors
        public DevTeamContents() { }


        public DevTeamContents(string teamName, List<DevContents> listOfTeam, int teamId)
        {
            TeamName = teamName;
            ListOfTeam = listOfTeam;
            TeamId = teamId;
        }

    }
}
