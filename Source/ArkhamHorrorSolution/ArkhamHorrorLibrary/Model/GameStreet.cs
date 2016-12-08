namespace ArkhamHorrorLibrary.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GameStreet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GameStreet()
        {
            GameLocations = new HashSet<GameLocation>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string OriginalName { get; set; }

        [Required]
        [StringLength(50)]
        public string LocalName { get; set; }

        public string Description { get; set; }

        public int Color { get; set; }

        public int GameExtention { get; set; }

        public virtual Color Color1 { get; set; }

        public virtual GameExtention GameExtention1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GameLocation> GameLocations { get; set; }
    }
}
