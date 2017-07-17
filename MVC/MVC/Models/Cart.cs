using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string  CartId { get; set; }
        public int TeamId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
         public virtual Team Team { get; set; }
    }
}