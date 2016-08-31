namespace ArkhamHorrorLibrary.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Monster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Monster()
        {
            MonstersAmounts = new HashSet<MonstersAmount>();
            MonstersAbilities = new HashSet<MonstersAbility>();
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

        public int MonsterMoveType { get; set; }

        public int MonsterType { get; set; }

        public int Dimension { get; set; }

        public int Toughness { get; set; }

        public int Awareness { get; set; }

        public int HorrorRating { get; set; }

        public int HorrorDamage { get; set; }

        public int CombatRating { get; set; }

        public int CombatDamage { get; set; }

        public virtual Dimension Dimension1 { get; set; }

        public virtual GameExtention GameExtention1 { get; set; }

        public virtual MonsterMoveType MonsterMoveType1 { get; set; }

        public virtual MonsterType MonsterType1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonstersAmount> MonstersAmounts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonstersAbility> MonstersAbilities { get; set; }
    }
}
