using MVC.Models;
using System.Collections.Generic;

namespace MVC.ViewModels
{
    public class TeamCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}