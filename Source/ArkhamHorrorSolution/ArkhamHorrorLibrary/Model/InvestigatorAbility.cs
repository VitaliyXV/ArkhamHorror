namespace ArkhamHorrorLibrary.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InvestigatorAbility
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InvestigatorAbility()
        {
            Investigators = new HashSet<Investigator>();
            Investigators1 = new HashSet<Investigator>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string OriginalName { get; set; }

        [Required]
        [StringLength(50)]
        public string LocalName { get; set; }

        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Investigator> Investigators { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Investigator> Investigators1 { get; set; }
    }
}
