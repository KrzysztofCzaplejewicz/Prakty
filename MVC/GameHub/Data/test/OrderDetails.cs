namespace GameHub.Data.test
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public int TeamId { get; set; }

        public int Quantity { get; set; }

        public virtual Orders Orders { get; set; }

        public virtual Teams Teams { get; set; }
    }
}
