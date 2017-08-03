using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameHub.ViewModels
{
    [Table("PlayersView")]
    public partial class PlayersView
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Age { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string TeamName { get; set; }

        public int? Count { get; set; }
    }
}
