using Microsoft.EntityFrameworkCore;
using Noxy.NET.Test.Persistence.Tables.Authentication;
using Noxy.NET.Test.Persistence.Tables.Data;
using Noxy.NET.Test.Persistence.Tables.Data.Discriminators;
using Noxy.NET.Test.Persistence.Tables.Schemas;
using Noxy.NET.Test.Persistence.Tables.Schemas.Associations;
using Noxy.NET.Test.Persistence.Tables.Schemas.Discriminators;
using Noxy.NET.Test.Persistence.Tables.Schemas.Junctions;

namespace Noxy.NET.Test.Persistence;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    private static List<Func<ModelBuilder, TableSchema?, TableSchema?>> MigrationSeedList { get; } = [];

    public DbSet<TableAuthentication> Authentication { get; set; } = null!;
    public DbSet<TableIdentity> Identity { get; set; } = null!;
    public DbSet<TableUser> User { get; set; } = null!;

    public DbSet<TableDataElement> DataElement { get; set; } = null!;
    public DbSet<TableDataProperty> DataProperty { get; set; } = null!;
    public DbSet<TableDataPropertyBoolean> DataPropertyBoolean { get; set; } = null!;
    public DbSet<TableDataPropertyDateTime> DataPropertyDateTime { get; set; } = null!;
    public DbSet<TableDataPropertyString> DataPropertyString { get; set; } = null!;

    public DbSet<TableDataSystemParameter> DataSystemParameter { get; set; } = null!;
    public DbSet<TableDataTextParameter> DataTextParameter { get; set; } = null!;

    public DbSet<TableSchema> Schema { get; set; } = null!;
    public DbSet<TableSchemaAction> SchemaAction { get; set; } = null!;
    public DbSet<TableSchemaActionInput> SchemaActionInput { get; set; } = null!;
    public DbSet<TableSchemaActionStep> SchemaActionStep { get; set; } = null!;
    public DbSet<TableSchemaAttribute> SchemaAttribute { get; set; } = null!;
    public DbSet<TableSchemaContext> SchemaContext { get; set; } = null!;
    public DbSet<TableSchemaDynamicValue> SchemaDynamicValue { get; set; } = null!;
    public DbSet<TableSchemaDynamicValueCode> SchemaDynamicValueCode { get; set; } = null!;
    public DbSet<TableSchemaDynamicValueSystemParameter> SchemaDynamicValueSystemParameter { get; set; } = null!;
    public DbSet<TableSchemaDynamicValueStyleParameter> SchemaDynamicValueStyleParameter { get; set; } = null!;
    public DbSet<TableSchemaDynamicValueTextParameter> SchemaDynamicValueTextParameter { get; set; } = null!;
    public DbSet<TableSchemaElement> SchemaElement { get; set; } = null!;
    public DbSet<TableSchemaGroupElement> SchemaGroupElement { get; set; } = null!;
    public DbSet<TableSchemaInput> SchemaInput { get; set; } = null!;
    public DbSet<TableSchemaProperty> SchemaProperty { get; set; } = null!;
    public DbSet<TableSchemaPropertyBoolean> SchemaPropertyBoolean { get; set; } = null!;
    public DbSet<TableSchemaPropertyDateTime> SchemaPropertyDateTime { get; set; } = null!;
    public DbSet<TableSchemaPropertyString> SchemaPropertyString { get; set; } = null!;

    public DbSet<TableJunctionSchemaActionHasActionStep> SchemaActionHasActionStep { get; set; } = null!;
    public DbSet<TableJunctionSchemaActionHasDynamicValueCode> SchemaActionHasDynamicValueCode { get; set; } = null!;
    public DbSet<TableJunctionSchemaActionStepHasActionInput> SchemaActionStepHasActionInput { get; set; } = null!;
    public DbSet<TableAssociationSchemaActionInputHasAttribute> SchemaActionInputHasAttribute { get; set; } = null!;
    public DbSet<TableAssociationSchemaActionInputHasAttributeDynamicValue> SchemaActionInputHasAttributeDynamicValue { get; set; } = null!;
    public DbSet<TableAssociationSchemaActionInputHasAttributeInteger> SchemaActionInputHasAttributeInteger { get; set; } = null!;
    public DbSet<TableAssociationSchemaActionInputHasAttributeString> SchemaActionInputHasAttributeString { get; set; } = null!;
    public DbSet<TableJunctionSchemaContextHasAction> SchemaContextHasAction { get; set; } = null!;
    public DbSet<TableJunctionSchemaContextHasElement> SchemaContextHasElement { get; set; } = null!;
    public DbSet<TableJunctionSchemaElementHasProperty> SchemaElementHasProperty { get; set; } = null!;
    public DbSet<TableJunctionSchemaInputHasAttribute> SchemaInputHasAttribute { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TableDataProperty>().UseTpcMappingStrategy();
        modelBuilder.Entity<TableDataProperty>().Property(e => e.ID).ValueGeneratedNever();

        modelBuilder.Entity<TableSchemaProperty>().UseTpcMappingStrategy();
        modelBuilder.Entity<TableSchemaProperty>().Property(e => e.ID).ValueGeneratedNever();

        modelBuilder.Entity<TableSchemaDynamicValue>().UseTpcMappingStrategy();
        modelBuilder.Entity<TableSchemaDynamicValue>().Property(e => e.ID).ValueGeneratedNever();

        modelBuilder.Entity<TableAssociationSchemaActionInputHasAttribute>().UseTpcMappingStrategy();
        modelBuilder.Entity<TableAssociationSchemaActionInputHasAttribute>().Property(e => e.ID).ValueGeneratedNever();

        modelBuilder.Entity<TableUser>()
            .HasOne(e => e.Authentication)
            .WithOne(e => e.User)
            .HasForeignKey<TableUser>(x => x.AuthenticationID);

        #region -- Schema --

        modelBuilder.Entity<TableSchema>()
            .HasMany(e => e.ActionList)
            .WithOne(e => e.Schema)
            .HasForeignKey(x => x.SchemaID);

        modelBuilder.Entity<TableSchema>()
            .HasMany(e => e.ActionInputList)
            .WithOne(e => e.Schema)
            .HasForeignKey(x => x.SchemaID);

        modelBuilder.Entity<TableSchema>()
            .HasMany(e => e.ActionStepList)
            .WithOne(e => e.Schema)
            .HasForeignKey(x => x.SchemaID);

        modelBuilder.Entity<TableSchema>()
            .HasMany(e => e.ContextList)
            .WithOne(e => e.Schema)
            .HasForeignKey(x => x.SchemaID);

        modelBuilder.Entity<TableSchema>()
            .HasMany(e => e.ElementList)
            .WithOne(e => e.Schema)
            .HasForeignKey(x => x.SchemaID);

        modelBuilder.Entity<TableSchema>()
            .HasMany(e => e.GroupElementList)
            .WithOne(e => e.Schema)
            .HasForeignKey(x => x.SchemaID);

        modelBuilder.Entity<TableSchema>()
            .HasMany(e => e.PropertyList)
            .WithOne(e => e.Schema)
            .HasForeignKey(x => x.SchemaID);

        #endregion -- Schema --

        #region -- Action --

        modelBuilder.Entity<TableSchemaAction>()
            .HasOne(e => e.TitleDynamic)
            .WithMany(e => e.ActionList)
            .HasForeignKey(x => x.TitleDynamicID);

        #endregion -- Action --

        #region -- Junctions --

        // modelBuilder.Entity<JunctionSchemaActionStepHasActionInput>()
        //     .HasOne(e => e.ActionInput)
        //     .WithMany(e => e.ActionStepList)
        //     .HasForeignKey(x => x.ActionInputID);
        //
        // modelBuilder.Entity<JunctionSchemaActionStepHasActionInput>()
        //     .HasOne(e => e.ActionStep)
        //     .WithMany(e => e.ActionInputList)
        //     .HasForeignKey(x => x.ActionStepID);
        //
        // modelBuilder.Entity<JunctionSchemaContextHasAction>()
        //     .HasOne(e => e.Action)
        //     .WithMany(e => e.ContextList)
        //     .HasForeignKey(x => x.ActionID);
        //
        // modelBuilder.Entity<JunctionSchemaContextHasAction>()
        //     .HasOne(e => e.Context)
        //     .WithMany(e => e.ActionList)
        //     .HasForeignKey(x => x.ContextID);
        //
        // modelBuilder.Entity<JunctionSchemaContextHasElement>()
        //     .HasOne(e => e.Element)
        //     .WithMany(e => e.ContextList)
        //     .HasForeignKey(x => x.ElementID);
        //
        // modelBuilder.Entity<JunctionSchemaContextHasElement>()
        //     .HasOne(e => e.Context)
        //     .WithMany(e => e.ElementList)
        //     .HasForeignKey(x => x.ContextID);
        //
        // modelBuilder.Entity<JunctionSchemaElementHasProperty>()
        //     .HasOne(e => e.Element)
        //     .WithMany(e => e.PropertyList)
        //     .HasForeignKey(x => x.ElementID);
        //
        // modelBuilder.Entity<JunctionSchemaElementHasProperty>()
        //     .HasOne(e => e.Relation)
        //     .WithMany(e => e.ElementList)
        //     .HasForeignKey(x => x.RelationID);

        #endregion -- Junctions --

        // modelBuilder.Entity<TableSchemaContext>()
        //     .HasMany(e => e.ActionList)
        //     .WithOne(e => e.Entity)
        //     .HasForeignKey(x => x.EntityID);
        //
        // modelBuilder.Entity<TableSchemaContext>()
        //     .HasMany(e => e.ElementList)
        //     .WithOne(e => e.Entity)
        //     .HasForeignKey(x => x.EntityID);

        TableSchema? tableSchema = null;
        foreach (TableSchema result in MigrationSeedList.Select(action => action(modelBuilder, tableSchema)).OfType<TableSchema>())
        {
            tableSchema = result;
        }
    }

    public static void AddMigrationSeed(Func<ModelBuilder, TableSchema?, TableSchema?> action)
    {
        MigrationSeedList.Add(action);
    }
}
