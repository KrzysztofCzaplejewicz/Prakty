using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Contacs
{
   public  interface IPlayerRepository
   {
       Player Find(int id);
       List<Team> GetAll();
       Player Add(Player player);
       Player Update(Player player);
       void Remove(int id);

       
       List<Player> GetFullPlayer();
       void Save(Player player);
       Team Add(Team team);
       Player GetFullPlayer(int id);
    }
}
