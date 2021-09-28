using DevTeamProject2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamProject2.Repo
{       //Use Crud! Manipulator and holder of data
    public class DevTeamRepo
    {
        private List<DevTeamContents> _listOfContent = new List<DevTeamContents>();
        
        //Create
        public void AddContentToList(DevTeamContents teamContent)
        {
            _listOfContent.Add(teamContent);
        }

        //Read
        public List<DevTeamContents> GetContentList()
        {
            return _listOfContent;

        }

        //Update
        public bool UpdateExistingContent(string originalTeamName, DevTeamContents newDevTeamContents)
        {    //Find the content
            DevTeamContents oldDevTeamContents = GetContentByTeamName(originalTeamName);

            //Update the content
            if (oldDevTeamContents != null)
            {
                oldDevTeamContents.TeamName = newDevTeamContents.TeamName;
                oldDevTeamContents.ListOfTeam = newDevTeamContents.ListOfTeam;
                oldDevTeamContents.TeamId = newDevTeamContents.TeamId;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveTeamContentFromList(string teamName)
        {
            DevTeamContents teamContents = GetContentByTeamName(teamName);
            if (teamContents == null)
            {
                return false;
            }

            int initialCount = _listOfContent.Count;
            _listOfContent.Remove(teamContents);

            if(initialCount> _listOfContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        //Helper Method
        public DevTeamContents GetContentByTeamName(string teamName) 
        {
            foreach (DevTeamContents teamContents in _listOfContent)
            {
                if (teamContents.TeamName.ToLower() == teamName.ToLower())
                {
                    return teamContents;
                }
            }
            return null;
        }
    }
}
