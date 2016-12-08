namespace ArkhamHorrorLibrary.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ArkhamHorrorModel : DbContext
    {
        public ArkhamHorrorModel()
            : base("name=ArkhamHorrorModelSettings")
        {
        }

        public virtual DbSet<Ability> Abilities { get; set; }
        public virtual DbSet<AncientOne> AncientOnes { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Dimension> Dimensions { get; set; }
        public virtual DbSet<EncounterType> EncounterTypes { get; set; }
        public virtual DbSet<GameExtention> GameExtentions { get; set; }
        public virtual DbSet<GameLocation> GameLocations { get; set; }
        public virtual DbSet<GameStreet> GameStreets { get; set; }
        public virtual DbSet<Herald> Heralds { get; set; }
        public virtual DbSet<InvestigatorAbility> InvestigatorAbilities { get; set; }
        public virtual DbSet<Investigator> Investigators { get; set; }
        public virtual DbSet<MonsterMoveType> MonsterMoveTypes { get; set; }
        public virtual DbSet<Monster> Monsters { get; set; }
        public virtual DbSet<MonstersAmount> MonstersAmounts { get; set; }
        public virtual DbSet<MonsterType> MonsterTypes { get; set; }
        public virtual DbSet<Occupation> Occupations { get; set; }
        public virtual DbSet<SpecialEncounter> SpecialEncounters { get; set; }
        public virtual DbSet<AncientOnesAbility> AncientOnesAbilities { get; set; }
        public virtual DbSet<MonstersAbility> MonstersAbilities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ability>()
                .HasMany(e => e.AncientOnesAbilities)
                .WithRequired(e => e.Ability1)
                .HasForeignKey(e => e.Ability)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ability>()
                .HasMany(e => e.MonstersAbilities)
                .WithRequired(e => e.Ability1)
                .HasForeignKey(e => e.Ability)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AncientOne>()
                .HasMany(e => e.AncientOnesAbilities)
                .WithRequired(e => e.AncientOne1)
                .HasForeignKey(e => e.AncientOne)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Color>()
                .HasMany(e => e.GameLocations)
                .WithRequired(e => e.Color1)
                .HasForeignKey(e => e.Color)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Color>()
                .HasMany(e => e.GameStreets)
                .WithRequired(e => e.Color1)
                .HasForeignKey(e => e.Color)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Color>()
                .HasMany(e => e.MonsterMoveTypes)
                .WithRequired(e => e.Color1)
                .HasForeignKey(e => e.Color)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Color>()
                .HasMany(e => e.Dimensions)
                .WithMany(e => e.Colors)
                .Map(m => m.ToTable("DimensionsColors").MapLeftKey("Color").MapRightKey("Dimension"));

            modelBuilder.Entity<Dimension>()
                .HasMany(e => e.Monsters)
                .WithRequired(e => e.Dimension1)
                .HasForeignKey(e => e.Dimension)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EncounterType>()
                .HasMany(e => e.GameLocations)
                .WithRequired(e => e.EncounterType)
                .HasForeignKey(e => e.EncounterType1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EncounterType>()
                .HasMany(e => e.GameLocations1)
                .WithRequired(e => e.EncounterType3)
                .HasForeignKey(e => e.EncounterType2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GameExtention>()
                .HasMany(e => e.AncientOnes)
                .WithRequired(e => e.GameExtention1)
                .HasForeignKey(e => e.GameExtention)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GameExtention>()
                .HasMany(e => e.Dimensions)
                .WithRequired(e => e.GameExtention1)
                .HasForeignKey(e => e.GameExtention)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GameExtention>()
                .HasMany(e => e.GameLocations)
                .WithRequired(e => e.GameExtention1)
                .HasForeignKey(e => e.GameExtention)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GameExtention>()
                .HasMany(e => e.GameStreets)
                .WithRequired(e => e.GameExtention1)
                .HasForeignKey(e => e.GameExtention)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GameExtention>()
                .HasMany(e => e.Heralds)
                .WithRequired(e => e.GameExtention1)
                .HasForeignKey(e => e.GameExtention)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GameExtention>()
                .HasMany(e => e.Investigators)
                .WithRequired(e => e.GameExtention1)
                .HasForeignKey(e => e.GameExtention)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GameExtention>()
                .HasMany(e => e.Monsters)
                .WithRequired(e => e.GameExtention1)
                .HasForeignKey(e => e.GameExtention)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GameExtention>()
                .HasMany(e => e.MonstersAmounts)
                .WithRequired(e => e.GameExtention1)
                .HasForeignKey(e => e.GameExtention)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GameStreet>()
                .HasMany(e => e.GameLocations)
                .WithRequired(e => e.GameStreet)
                .HasForeignKey(e => e.NeighborhoodStreet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InvestigatorAbility>()
                .HasMany(e => e.Investigators)
                .WithMany(e => e.InvestigatorAbilities)
                .Map(m => m.ToTable("InvastigatorAbilities").MapLeftKey("Ability").MapRightKey("Investigator"));

            modelBuilder.Entity<InvestigatorAbility>()
                .HasMany(e => e.Investigators1)
                .WithMany(e => e.InvestigatorAbilities1)
                .Map(m => m.ToTable("InvastigatorAndAbilities").MapLeftKey("Ability").MapRightKey("Investigator"));

            modelBuilder.Entity<MonsterMoveType>()
                .HasMany(e => e.Monsters)
                .WithRequired(e => e.MonsterMoveType1)
                .HasForeignKey(e => e.MonsterMoveType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Monster>()
                .HasMany(e => e.MonstersAmounts)
                .WithRequired(e => e.Monster1)
                .HasForeignKey(e => e.Monster)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Monster>()
                .HasMany(e => e.MonstersAbilities)
                .WithRequired(e => e.Monster1)
                .HasForeignKey(e => e.Monster)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonsterType>()
                .HasMany(e => e.Monsters)
                .WithRequired(e => e.MonsterType1)
                .HasForeignKey(e => e.MonsterType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Occupation>()
                .HasMany(e => e.Investigators)
                .WithRequired(e => e.Occupation1)
                .HasForeignKey(e => e.Occupation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SpecialEncounter>()
                .HasMany(e => e.GameLocations)
                .WithOptional(e => e.SpecialEncounter1)
                .HasForeignKey(e => e.SpecialEncounter);
        }
    }
}
