using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RuneGlossary.Resurrected.Infrastructure.Entities;
using System.Runtime.CompilerServices;

namespace RuneGlossary.Resurrected.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ClassEntity> Classes { get; set; }
        public DbSet<ItemTypeEntity> ItemtTypes { get; set; }
        public DbSet<RuneEntity> Runes { get; set; }

        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClassEntity>()
                .Build();
            modelBuilder.Entity<ItemTypeEntity>()
                .Build();
            modelBuilder.Entity<SkillEntity>()
                .Build();
        }
    }

    internal static class DatabaseContextExtensions
    {
        public static void Build(this EntityTypeBuilder<ClassEntity> builder)
        {
            builder.ToTable("classes", "resurrected")
                .HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");
            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();
        }

        public static void Build(this EntityTypeBuilder<ItemTypeEntity> builder)
        {
            builder.ToTable("item_types", "resurrected")
                .HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");
            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();
            builder.Property(e => e.Class)
                .HasColumnName("class")
                .IsRequired()
                .HasConversion(new EnumToStringConverter<ItemClass>());
        }

        public static void Build(this EntityTypeBuilder<RuneEntity> builder)
        {
            builder.ToTable("runes", "resurrected")
                .HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");
            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();
            builder.Property(e => e.Level)
                .HasColumnName("level");
            builder.Property(e => e.InWeapon)
                .HasColumnName("in_weapon")
                .IsRequired();
            builder.Property(e => e.InHelmet)
                .HasColumnName("in_helmet")
                .IsRequired();
            builder.Property(e => e.InBodyArmor)
                .HasColumnName("in_body_armor")
                .IsRequired();
            builder.Property(e => e.InShield)
                .HasColumnName("in_shield")
                .IsRequired();
        }

        public string void Build(this EntityTypeBuilder<SkillEntity> builder)
        {
            builder.ToTable("skills")
                .HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");
            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();
            builder.Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired();
            builder.Property(e => e.Url)
                .HasColumnName("url")
                .IsRequired();
        }
    }

    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseNpgsql("Host=mihben.work;Username=postgres;Password=AaZ9SGvNyEjsBuzc;Database=rune_glossary-migration");

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
