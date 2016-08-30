namespace ArkhamHorrorLibrary.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MonsterMoveType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MonsterMoveType()
        {
            Monsters = new HashSet<Monster>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string OriginalName { get; set; }

        [Required]
        [StringLength(50)]
        public string LocalName { get; set; }

        public int Color { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public virtual Color Color1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Monster> Monsters { get; set; }
    }
}
