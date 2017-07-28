namespace GameHub.Data.test
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Carts
    {
        [Key]
        public int RecordId { get; set; }

        public string CartId { get; set; }

        public int TeamId { get; set; }

        public int Count { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual Teams Teams { get; set; }
    }
}
