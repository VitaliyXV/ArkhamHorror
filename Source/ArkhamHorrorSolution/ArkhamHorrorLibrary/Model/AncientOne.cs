namespace ArkhamHorrorLibrary.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AncientOne
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AncientOne()
        {
            AncientOnesAbilities = new HashSet<AncientOnesAbility>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string OriginalName { get; set; }

        [Required]
        [StringLength(50)]
        public string LocalName { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public int GameExtention { get; set; }

        [StringLength(500)]
        public string Worshippers { get; set; }

        [StringLength(500)]
        public string AncientPower { get; set; }

        [StringLength(500)]
        public string Attack { get; set; }

        public int CombatRating { get; set; }

        public int DoomTrack { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AncientOnesAbility> AncientOnesAbilities { get; set; }

        public virtual GameExtention GameExtention1 { get; set; }
    }
}
