using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameHub.Models
{
    public partial class Leagues
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Leagues()
        {
            Games = new HashSet<Games>();
            Teams = new HashSet<Teams>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string LeagueName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Games> Games { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teams> Teams { get; set; }

    }
}
