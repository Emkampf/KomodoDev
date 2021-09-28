using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamProject2.Data
{
    public class DevContents
    {
            //Plain Old C# Objects
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public int DevId { get; set; }

            public bool Pluralsight { get; set; }

            //Constructors
            public DevContents() { }

            public DevContents(string firstName, string lastName, int devId, bool pluralsight)
            {
                FirstName = firstName;
                LastName = lastName;
                DevId = devId;
                Pluralsight = pluralsight;
            }
        


    }
}
