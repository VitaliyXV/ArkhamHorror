namespace ArkhamHorrorLibrary.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Investigator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Investigator()
        {
            InvestigatorAbilities = new HashSet<InvestigatorAbility>();
            InvestigatorAbilities1 = new HashSet<InvestigatorAbility>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string OriginalName { get; set; }

        [Required]
        [StringLength(50)]
        public string LocalName { get; set; }

        public int Occupation { get; set; }

        public int StartLocation { get; set; }

        public int Sanity { get; set; }

        public int Stamina { get; set; }

        public int Focus { get; set; }

        public string Description { get; set; }

        public int GameExtention { get; set; }

        public virtual GameExtention GameExtention1 { get; set; }

        public virtual Occupation Occupation1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvestigatorAbility> InvestigatorAbilities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvestigatorAbility> InvestigatorAbilities1 { get; set; }
    }
}
