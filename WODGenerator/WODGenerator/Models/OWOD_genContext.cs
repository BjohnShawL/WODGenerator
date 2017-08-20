using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WODGenerator.Models
{
    public partial class OWOD_genContext : DbContext
    {
        public virtual DbSet<Abilities> Abilities { get; set; }
        public virtual DbSet<Attributes> Attributes { get; set; }
        public virtual DbSet<Characters> Characters { get; set; }
        public virtual DbSet<GameCampaign> GameCampaign { get; set; }
        public virtual DbSet<GameMaster> GameMaster { get; set; }
        public virtual DbSet<Knowledge> Knowledge { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
        public virtual DbSet<Talents> Talents { get; set; }

        public OWOD_genContext(DbContextOptions<OWOD_genContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abilities>(entity =>
            {
                entity.HasKey(e => e.AblId);

                entity.ToTable("abilities", "OWOD_gen");

                entity.HasIndex(e => e.KnowledgeId)
                    .HasName("knowledge_ID_idx");

                entity.HasIndex(e => e.SkillsId)
                    .HasName("skills_ID_idx");

                entity.HasIndex(e => e.TalentId)
                    .HasName("talent_ID_idx");

                entity.Property(e => e.AblId)
                    .HasColumnName("abl_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.KnowledgeId).HasColumnName("knowledge_ID");

                entity.Property(e => e.SkillsId).HasColumnName("skills_ID");

                entity.Property(e => e.TalentId).HasColumnName("talent_ID");

                entity.HasOne(d => d.Knowledge)
                    .WithMany(p => p.Abilities)
                    .HasForeignKey(d => d.KnowledgeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("knowledge_ID");

                entity.HasOne(d => d.Skills)
                    .WithMany(p => p.Abilities)
                    .HasForeignKey(d => d.SkillsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("skills_ID");

                entity.HasOne(d => d.Talent)
                    .WithMany(p => p.Abilities)
                    .HasForeignKey(d => d.TalentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("talent_ID");
            });

            modelBuilder.Entity<Attributes>(entity =>
            {
                entity.HasKey(e => e.AttribId);

                entity.ToTable("attributes", "OWOD_gen");

                entity.Property(e => e.AttribId)
                    .HasColumnName("attrib_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Appear)
                    .HasColumnName("appear")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Cha)
                    .HasColumnName("cha")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Dex)
                    .HasColumnName("dex")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Intel)
                    .HasColumnName("intel")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Manip)
                    .HasColumnName("manip")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Perc)
                    .HasColumnName("perc")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Stam)
                    .HasColumnName("stam")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Str)
                    .HasColumnName("str")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Wits)
                    .HasColumnName("wits")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Characters>(entity =>
            {
                entity.HasKey(e => e.CharId);

                entity.ToTable("characters", "OWOD_gen");

                entity.HasIndex(e => e.AblId)
                    .HasName("abl_ID_idx");

                entity.HasIndex(e => e.AttribId)
                    .HasName("attrib_ID_idx");

                entity.HasIndex(e => e.GameId)
                    .HasName("game_ID_idx");

                entity.HasIndex(e => e.LocId)
                    .HasName("loc_ID_idx");

                entity.Property(e => e.CharId)
                    .HasColumnName("char_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AblId).HasColumnName("abl_ID");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Alignment)
                    .HasColumnName("alignment")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AttribId).HasColumnName("attrib_ID");

                entity.Property(e => e.GameId).HasColumnName("game_ID");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Inventory).HasColumnName("inventory");

                entity.Property(e => e.LocId).HasColumnName("loc_ID");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PlotHook).HasColumnName("plot_hook");

                entity.Property(e => e.Species)
                    .HasColumnName("species")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.Abl)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.AblId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abl_ID");

                entity.HasOne(d => d.Attrib)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.AttribId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("attrib_ID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.CharactersNavigation)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("game_ID");

                entity.HasOne(d => d.Loc)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.LocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_loc_ID");
            });

            modelBuilder.Entity<GameCampaign>(entity =>
            {
                entity.HasKey(e => e.GameId);

                entity.ToTable("gameCampaign", "OWOD_gen");

                entity.Property(e => e.GameId)
                    .HasColumnName("game_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CampaignName)
                    .HasColumnName("campaign_name")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Characters).HasColumnName("characters");

                entity.Property(e => e.GameType)
                    .HasColumnName("game_type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GmName)
                    .HasColumnName("gm_name")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Players).HasColumnName("players");
            });

            modelBuilder.Entity<GameMaster>(entity =>
            {
                entity.HasKey(e => e.GmId);

                entity.ToTable("gameMaster", "OWOD_gen");

                entity.Property(e => e.GmId)
                    .HasColumnName("gm_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.GmName)
                    .HasColumnName("gm_name")
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Knowledge>(entity =>
            {
                entity.ToTable("knowledge", "OWOD_gen");

                entity.Property(e => e.KnowledgeId)
                    .HasColumnName("knowledge_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Academics).HasColumnName("academics");

                entity.Property(e => e.Bureaucracy).HasColumnName("bureaucracy");

                entity.Property(e => e.Computer).HasColumnName("computer");

                entity.Property(e => e.Cosmology).HasColumnName("cosmology");

                entity.Property(e => e.Enigmas).HasColumnName("enigmas");

                entity.Property(e => e.Finance).HasColumnName("finance");

                entity.Property(e => e.Greymare).HasColumnName("greymare");

                entity.Property(e => e.HearthWisdom).HasColumnName("hearth_wisdom");

                entity.Property(e => e.Investigation).HasColumnName("investigation");

                entity.Property(e => e.Law).HasColumnName("law");

                entity.Property(e => e.Linguistics).HasColumnName("linguistics");

                entity.Property(e => e.Medicine).HasColumnName("medicine");

                entity.Property(e => e.Occult).HasColumnName("occult");

                entity.Property(e => e.Politics).HasColumnName("politics");

                entity.Property(e => e.Rituals).HasColumnName("rituals");

                entity.Property(e => e.Science).HasColumnName("science");

                entity.Property(e => e.Seneschal).HasColumnName("seneschal");

                entity.Property(e => e.Theology).HasColumnName("theology");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasKey(e => e.LocId);

                entity.ToTable("locations", "OWOD_gen");

                entity.Property(e => e.LocId)
                    .HasColumnName("loc_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FactionId).HasColumnName("faction_ID");

                entity.Property(e => e.Gauntlet).HasColumnName("gauntlet");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Skills>(entity =>
            {
                entity.ToTable("skills", "OWOD_gen");

                entity.Property(e => e.SkillsId)
                    .HasColumnName("skills_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnimalKen).HasColumnName("animal_ken");

                entity.Property(e => e.Archery).HasColumnName("archery");

                entity.Property(e => e.Commerce).HasColumnName("commerce");

                entity.Property(e => e.Crafts).HasColumnName("crafts");

                entity.Property(e => e.Drive).HasColumnName("drive");

                entity.Property(e => e.Ettiquette).HasColumnName("ettiquette");

                entity.Property(e => e.Firearms).HasColumnName("firearms");

                entity.Property(e => e.MartialArts).HasColumnName("martial_arts");

                entity.Property(e => e.Melee).HasColumnName("melee");

                entity.Property(e => e.Performance).HasColumnName("performance");

                entity.Property(e => e.Ride).HasColumnName("ride");

                entity.Property(e => e.Security).HasColumnName("security");

                entity.Property(e => e.Stealth).HasColumnName("stealth");

                entity.Property(e => e.Survival).HasColumnName("survival");
            });

            modelBuilder.Entity<Talents>(entity =>
            {
                entity.HasKey(e => e.TalentId);

                entity.ToTable("talents", "OWOD_gen");

                entity.Property(e => e.TalentId)
                    .HasColumnName("talent_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alertness).HasColumnName("alertness");

                entity.Property(e => e.Athletics).HasColumnName("athletics");

                entity.Property(e => e.Awareness).HasColumnName("awareness");

                entity.Property(e => e.Brawl).HasColumnName("brawl");

                entity.Property(e => e.Dodge).HasColumnName("dodge");

                entity.Property(e => e.Empathy).HasColumnName("empathy");

                entity.Property(e => e.Expression).HasColumnName("expression");

                entity.Property(e => e.Intimidation).HasColumnName("intimidation");

                entity.Property(e => e.Intuition).HasColumnName("intuition");

                entity.Property(e => e.Kenning).HasColumnName("kenning");

                entity.Property(e => e.Leadership).HasColumnName("leadership");

                entity.Property(e => e.Ledgermain).HasColumnName("ledgermain");

                entity.Property(e => e.MartialArts).HasColumnName("martial_arts");

                entity.Property(e => e.Persuasion).HasColumnName("persuasion");

                entity.Property(e => e.PrimalUrge).HasColumnName("primal_urge");

                entity.Property(e => e.Streetwise).HasColumnName("streetwise");

                entity.Property(e => e.Subterfuge).HasColumnName("subterfuge");
            });
        }
    }
}
