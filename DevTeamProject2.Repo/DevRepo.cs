using DevTeamProject2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamProject2.Repo
{    //Use Crud!
    public class DevRepo
    {
        private List<DevContents> _listOfContent = new List<DevContents>();

        //Create
        public void AddContentToList(DevContents devContent)
        {
            _listOfContent.Add(devContent);
        }

        //Read
        public List<DevContents> GetContentList()
        {
            return _listOfContent;

        }

        //Update
        public bool UpdateExistingContent(string originalFirstName, DevContents newDevContents)
        {    //Find the content
            DevContents oldDevContents = GetContentByFirstName(originalFirstName);

            //Update the content
            if (oldDevContents != null)
            {
                oldDevContents.FirstName = newDevContents.FirstName;
                oldDevContents.LastName = newDevContents.LastName;
                oldDevContents.DevId = newDevContents.DevId;
                oldDevContents.Pluralsight = newDevContents.Pluralsight;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveTeamContentFromList(string firstName)
        {
            DevContents devContents = GetContentByFirstName(firstName);
            if (devContents == null)
            {
                return false;
            }

            int initialCount = _listOfContent.Count;
            _listOfContent.Remove(devContents);

            if (initialCount > _listOfContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        //Helper Method
        public DevContents GetContentByFirstName(string firstName)
        {
            foreach (DevContents devContent in _listOfContent)
            {
                if (devContent.FirstName.ToLower() == firstName.ToLower())
                {
                    return devContent;
                }
            }

            return null;
        }    
    }   
}
