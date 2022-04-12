using Microsoft.EntityFrameworkCore;
using Constructor.Data.Data;
using Constructor.Data.Metadata;

namespace Constructor.Data;

public class ConstructorDbContext : DbContext
{
    public ConstructorDbContext(DbContextOptions<ConstructorDbContext> options) : base(options) { }

    #region Metadata
    public DbSet<Domain> Domains { get; set; }
    public DbSet<EntityTypeGroup> EntityTypeGroups { get; }
    public DbSet<EntityType> EntityTypes { get; set; }
    public DbSet<EntityProperty> EntityProperties { get; set; }
    #endregion

    #region Data
    public DbSet<Entity> Entites { get; set; }
    public DbSet<EntityLink> EntityLinks { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<ModelItem> ModelItems { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Metadata
        modelBuilder.Entity<Domain>().ToTable(nameof(Domains));
        modelBuilder.Entity<Domain>()
            .HasMany(t => t.ImportedTypes)
            .WithMany(t => t.ImportingDomains)
            .UsingEntity(t => t.ToTable("EntityTypeImports"));
        modelBuilder.Entity<Domain>()
            .HasOne(t => t.Parent)
            .WithMany(t => t.Children)
            .HasForeignKey(t => t.ParentId);

        modelBuilder.Entity<EntityTypeGroup>().ToTable(nameof(EntityTypeGroups));
        modelBuilder.Entity<EntityTypeGroup>()
            .HasOne(t => t.Domain)
            .WithMany(t => t.EntityTypeGroups)
            .HasForeignKey(t => t.DomainId);

        modelBuilder.Entity<EntityType>().ToTable(nameof(EntityTypes));
        modelBuilder.Entity<EntityType>()
            .HasOne(t => t.Domain)
            .WithMany(t => t.EntityTypes)
            .HasForeignKey(t => t.DomainId);
        modelBuilder.Entity<EntityType>()
            .HasOne(t => t.Group)
            .WithMany(t => t.EntityTypes)
            .HasForeignKey(t => t.GroupId);
        modelBuilder.Entity<EntityType>()
            .HasOne(t => t.Parent)
            .WithMany(t => t.Children)
            .HasForeignKey(t => t.ParentId);

        modelBuilder.Entity<EntityProperty>().ToTable(nameof(EntityProperties));
        modelBuilder.Entity<EntityProperty>()
            .HasOne(t => t.EntityType)
            .WithMany(t => t.Properties)
            .HasForeignKey(t => t.EntityTypeId);
        modelBuilder.Entity<ReferenceEntityProperty>()
            .HasOne(t => t.ValueType)
            .WithMany(t => t.ReferenceProperties)
            .HasForeignKey(t => t.ValueTypeId);
        #endregion

        #region Data
        modelBuilder.Entity<Entity>().ToTable(nameof(Entites));        
        
        modelBuilder.Entity<Entity>()
            .HasOne(t => t.Domain)
            .WithMany(t => t.Entities)
            .HasForeignKey(t => t.DomainId);
        modelBuilder.Entity<Entity>().HasIndex(t => t.DomainId);

        modelBuilder.Entity<Entity>()
            .HasOne(t => t.EntityType)
            .WithMany(t => t.Entities)
            .HasForeignKey(t => t.EntityTypeId);
        modelBuilder.Entity<Entity>().HasIndex(t => t.EntityTypeId);

        modelBuilder.Entity<EntityLink>().ToTable(nameof(EntityLinks));
        modelBuilder.Entity<EntityLink>().HasKey(t => new { t.PropertyId, t.EntitySourceId });
        modelBuilder.Entity<EntityLink>()
            .HasOne(t => t.Property)
            .WithMany(t => t.EntityLinks)
            .HasForeignKey(t => t.PropertyId);
        modelBuilder.Entity<EntityLink>()
            .HasOne(t => t.Source)
            .WithMany(t => t.SourceLinks)
            .HasForeignKey(t => t.EntitySourceId);
        modelBuilder.Entity<EntityLink>()
            .HasOne(t => t.Target)
            .WithMany(t => t.TargetLinks)
            .HasForeignKey(t => t.EntityTargetId);

        modelBuilder.Entity<Model>().ToTable(nameof(Models));
        modelBuilder.Entity<Model>()
            .HasOne(t => t.Domain)
            .WithMany(t => t.Models)
            .HasForeignKey(t => t.DomainId);
        modelBuilder.Entity<Model>()
            .HasOne(t => t.EntityType)
            .WithMany(t => t.Models)
            .HasForeignKey(t => t.EntityTypeId);

        modelBuilder.Entity<ModelItem>().ToTable(nameof(ModelItems));
        modelBuilder.Entity<ModelItem>()
            .HasOne(t => t.Property)
            .WithMany(t => t.ModelItems)
            .HasForeignKey(t => t.PropertyId);
        modelBuilder.Entity<ModelItem>()
            .HasOne(t => t.Model)
            .WithMany(t => t.Items)
            .HasForeignKey(t => t.ModelId);
        modelBuilder.Entity<ModelItem>().HasIndex(t => t.ModelId);
        #endregion
    }
}