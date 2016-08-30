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
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Dimension> Dimensions { get; set; }
        public virtual DbSet<GameExtention> GameExtentions { get; set; }
        public virtual DbSet<MonsterMoveType> MonsterMoveTypes { get; set; }
        public virtual DbSet<Monster> Monsters { get; set; }
        public virtual DbSet<MonsterType> MonsterTypes { get; set; }
        public virtual DbSet<MonstersAmount> MonstersAmounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ability>()
                .HasMany(e => e.Monsters)
                .WithMany(e => e.Abilities)
                .Map(m => m.ToTable("MonstersAbilities").MapLeftKey("Ability").MapRightKey("Monster"));

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

            modelBuilder.Entity<GameExtention>()
                .HasMany(e => e.Dimensions)
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

            modelBuilder.Entity<MonsterType>()
                .HasMany(e => e.Monsters)
                .WithRequired(e => e.MonsterType1)
                .HasForeignKey(e => e.MonsterType)
                .WillCascadeOnDelete(false);
        }
    }
}
