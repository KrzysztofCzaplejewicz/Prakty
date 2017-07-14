using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersUoW
{
   
    
    public class Players
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public virtual Teams Teamss { get; set; }
    }

    public class Teams
   
    {
        public Teams()
        { 

            Playerss = new List<Players>();
        }
    public int Id { get; set; }
        public string TeamName { get; set; }
        public string Town { get; set; }
        public List<Players> Playerss { get; set; }

        public string TeamCode => TeamName.Substring(0, 1) + ":" + Town.Substring(0, 1);
    }
}
