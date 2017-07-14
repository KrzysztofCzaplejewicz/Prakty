using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Contacs
{
   public  class Team
    {
        internal int IdId;

        public Team()
        {
            this.Players = new List<Player>();
        }
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string Town { get; set; }

        


        public List<Player> Players { get; set; }


        public bool IsNew
        {
            get { return this.Id == default(int); }
        }
    }

}






