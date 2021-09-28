using DevTeamProject2.Data;
using DevTeamProject2.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamProject.ui
{
    class ProgramUI
    {
        private DevTeamRepo _contentTeamRepo = new DevTeamRepo();

        private DevRepo _contentDevRepo = new DevRepo();

        //Method that runs/starts the app
        public void Run()
        {
            Menu();
        }

        //Menu

        private void Menu()
        {
            bool keepRunning = true;
            while(keepRunning)
            {
                //Display Options to user
                Console.WriteLine("Enter the number for your selection:\n" +
                       "1. Create developer \n" +
                       "2. Create team \n" +
                       "3. View all developers \n" +
                       "4. View all teams \n" +
                       "5. Update developer data \n" +
                       "6. Update team data \n" +
                       "7. Delete developer \n" +
                       "8. Delete team \n" +
                       "9. Exit");

                // Get user's input
                string input = Console.ReadLine();

                //Evaluate input and act 

                switch (input)
                {
                    case "1":
                        CreateNewDeveloper();
                        break;

                    case "2":
                        CreateNewTeam();
                        break;

                    case "3":
                        DisplayAllDevelopers();
                        break;

                    case "4":
                        DisplayAllTeams();
                        break;

                    case "5":
                        UpdateDeveloperData();
                        break;

                    case "6":
                        UpdateTeamData();
                        break;

                    case "7":
                        DeleteDeveloper();
                        break;

                    case "8":
                        DeleteTeam();
                        break;

                    case "9":
                        //Exit
                        Console.WriteLine("Ta Ta For Now!");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;

                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateNewDeveloper()

        {
            Console.Clear();
            DevContents newDevContents = new DevContents();

            Console.WriteLine("Enter developer first name");
            newDevContents.FirstName = Console.ReadLine();
            Console.WriteLine("Enter developer last name");
            newDevContents.LastName = Console.ReadLine();

            //First Name + Last Name
            //or..
            //Last Name?

            //Devid
            Console.Clear();
            Console.WriteLine("Enter developer ID");
            string devIdAsString = Console.ReadLine();
            newDevContents.DevId = int.Parse(devIdAsString);

            //Pluralsight
            Console.Clear();
            Console.WriteLine("Pluralsight access? (y/n)");
            string pluralSightAsString = Console.ReadLine().ToLower();

            if(pluralSightAsString == "y")
            {
                newDevContents.Pluralsight = true;
            }
            else
            {
                newDevContents.Pluralsight = false;
            }

            _contentDevRepo.AddContentToList(newDevContents);

        }
        
        private void CreateNewTeam()
        

        {
            Console.Clear();
            DevTeamContents newDevTeamContents = new DevTeamContents();
            //Team Name
            Console.WriteLine("Enter team name:");
            newDevTeamContents.TeamName = Console.ReadLine();
            //List of Team
            Console.Clear();
            Console.WriteLine("View team");
            newDevTeamContents.TeamName = Console.ReadLine();

            //TeamId
            Console.Clear();
            Console.WriteLine("Enter team ID");
            string teamIdAsString = Console.ReadLine();
            newDevTeamContents.TeamId = int.Parse(teamIdAsString);


            _contentTeamRepo.AddContentToList(newDevTeamContents);

        }
    
        private void DisplayAllDevelopers()
        {
            List<DevContents> listOfContent = _contentDevRepo.GetContentList();

            foreach(DevContents contents in listOfContent)
            {
                Console.WriteLine($"First Name: {contents.FirstName}\n" +
                    $"Last Name: {contents.LastName} ");
            }
        }

        private void DisplayAllTeams()
        {
            Console.Clear();
            List<DevTeamContents> listOfContent = _contentTeamRepo.GetContentList();


            foreach (DevTeamContents contents in listOfContent)
            {
                Console.WriteLine($"Team Name {contents.TeamName}");
            }
        }

        private void UpdateDeveloperData()
        {
            Console.Clear();
            //Display All Content
            DisplayAllDevelopers();
            Console.WriteLine("Enter developer updates");
            //Get Data
            string oldDevContents = Console.ReadLine();

            DevContents newDevContents = new DevContents();

            Console.Clear();
            Console.WriteLine("Enter developer first name");
            newDevContents.FirstName = Console.ReadLine();
            Console.WriteLine("Enter developer last name");
            newDevContents.LastName = Console.ReadLine();


            Console.Clear();
            Console.WriteLine("Enter developer ID");
            string devIdAsString = Console.ReadLine();
            newDevContents.DevId = int.Parse(devIdAsString);

            //Pluralsight
            Console.Clear();
            Console.WriteLine("Pluralsight access? (y/n)");
            string pluralSightAsString = Console.ReadLine().ToLower();

            if (pluralSightAsString == "y")
            {
                newDevContents.Pluralsight = true;
            }
            else
            {
                newDevContents.Pluralsight = false;
            }

            //Verify
           bool wasUpdated = _contentDevRepo.UpdateExistingContent(oldDevContents, newDevContents);
            Console.Clear();
            if(wasUpdated)
            {
                Console.WriteLine("Successfully updated!");
            }

            else
            {
                Console.WriteLine("Unable to update.");
            }
        }

        private void UpdateTeamData()
        {
            Console.Clear();
            //Display All Content and ask for update
            DisplayAllTeams();
            Console.WriteLine("Enter team update:");
            //GetData
            string oldDevTeamContents = Console.ReadLine();

            DevTeamContents newDevTeamContents = new DevTeamContents();
            //Team Name
            Console.WriteLine("Enter team name:");
            newDevTeamContents.TeamName = Console.ReadLine();
            //List of Team
            Console.WriteLine("View team");
            newDevTeamContents.TeamName = Console.ReadLine();

            //TeamId
            Console.WriteLine("Enter team ID");
            string teamIdAsString = Console.ReadLine();
            newDevTeamContents.TeamId = int.Parse(teamIdAsString);

            bool wasUpdated = _contentTeamRepo.UpdateExistingContent(oldDevTeamContents, newDevTeamContents);

            if (wasUpdated)
            {
                Console.WriteLine("Successfully updated!");
            }

            else
            {
                Console.WriteLine("Unable to update.");
            }

        }

        private void DeleteDeveloper()
        {
            Console.Clear();
            //Get content to delete
            DisplayAllDevelopers();
            Console.WriteLine("Enter developer to remove:");

            string input = Console.ReadLine();
            //Call delete method
            bool wasDeleted = _contentDevRepo.RemoveTeamContentFromList(input);
            if (wasDeleted)
            {
                Console.WriteLine("Successfully deleted.");
            }
            else
            {
                Console.WriteLine("Unable to delete.");
            }          

        }

        private void DeleteTeam()
        {
            Console.Clear();
            //Get content to delete
            DisplayAllTeams();
            Console.WriteLine("Enter team to remove:");

            string input = Console.ReadLine();
            //Call delete method
            bool wasDeleted = _contentTeamRepo.RemoveTeamContentFromList(input);
            if (wasDeleted)
            {
                Console.WriteLine("Successfully deleted.");
            }
            else
            {
                Console.WriteLine("Unable to delete.");
            }

        }
     
    }
}
    

