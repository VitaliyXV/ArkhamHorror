namespace ArkhamHorrorLibrary.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dimension
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dimension()
        {
            Monsters = new HashSet<Monster>();
            Colors = new HashSet<Color>();
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

        public virtual GameExtention GameExtention1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Monster> Monsters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Color> Colors { get; set; }
    }
}
