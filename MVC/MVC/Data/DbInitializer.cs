using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Data
{
    public class DbInitializer
    {
        public static void Initialize(Context context)
        {
            context.Database.CreateIfNotExists();
            if (context.Players.Any())
            {
                return;
            }

         
        }
    }
}