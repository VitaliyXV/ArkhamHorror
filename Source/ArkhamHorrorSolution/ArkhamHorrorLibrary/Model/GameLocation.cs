namespace ArkhamHorrorLibrary.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GameLocation
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string OriginalName { get; set; }

        [Required]
        [StringLength(50)]
        public string LocalName { get; set; }

        public string Description { get; set; }

        public bool IsStabile { get; set; }

        public int? SpecialEncounter { get; set; }

        public int EncounterType1 { get; set; }

        public int EncounterType2 { get; set; }

        public int NeighborhoodStreet { get; set; }

        public int Color { get; set; }

        public int GameExtention { get; set; }

        public virtual Color Color1 { get; set; }

        public virtual EncounterType EncounterType { get; set; }

        public virtual EncounterType EncounterType3 { get; set; }

        public virtual GameExtention GameExtention1 { get; set; }

        public virtual GameStreet GameStreet { get; set; }

        public virtual SpecialEncounter SpecialEncounter1 { get; set; }
    }
}
