using System.Collections.Generic;

namespace GameHub.Models
{
    public class Scores
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Scores()
        {
            Games = new HashSet<Games>();
        }

        public int Id { get; set; }

        public int ScoreHost { get; set; }

        public int ScoreVisitor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Games> Games { get; set; }


    }
}