using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacs;


namespace Dapper
{

    public class Player
    {


        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }

        public int TeamId { get; set; }

        internal bool IsNew
        {
            get { return this.TeamId == default(int); }
        }

        public bool IsDeleted { get; set; }


    }

}
