using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Noxy.NET.Test.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TableAuthentication",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Salt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Hash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    UserID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableAuthentication", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TableDataElement",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableDataElement", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TableDataSystemParameter",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    TimeApproved = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TimeEffective = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableDataSystemParameter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TableDataTextParameter",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    TimeApproved = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TimeEffective = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableDataTextParameter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TableSchema",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    TimeActivated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSchema", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TableUser",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", nullable: false),
                    TimeSignIn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TimeVerified = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AuthenticationID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableUser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableUser_TableAuthentication_AuthenticationID",
                        column: x => x.AuthenticationID,
                        principalTable: "TableAuthentication",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableDataPropertyBoolean",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ElementID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<bool>(type: "INTEGER", nullable: true),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableDataPropertyBoolean", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableDataPropertyBoolean_TableDataElement_ElementID",
                        column: x => x.ElementID,
                        principalTable: "TableDataElement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableDataPropertyDateTime",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ElementID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableDataPropertyDateTime", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableDataPropertyDateTime_TableDataElement_ElementID",
                        column: x => x.ElementID,
                        principalTable: "TableDataElement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableDataPropertyString",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ElementID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableDataPropertyString", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableDataPropertyString_TableDataElement_ElementID",
                        column: x => x.ElementID,
                        principalTable: "TableDataElement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableSchemaAction",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TitleDynamicID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    SchemaID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSchemaAction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableSchemaAction_TableSchema_SchemaID",
                        column: x => x.SchemaID,
                        principalTable: "TableSchema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableSchemaActionStep",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsRepeatable = table.Column<bool>(type: "INTEGER", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    SchemaID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSchemaActionStep", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableSchemaActionStep_TableSchema_SchemaID",
                        column: x => x.SchemaID,
                        principalTable: "TableSchema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableSchemaAttribute",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    IsList = table.Column<bool>(type: "INTEGER", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    SchemaID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSchemaAttribute", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableSchemaAttribute_TableSchema_SchemaID",
                        column: x => x.SchemaID,
                        principalTable: "TableSchema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableSchemaContext",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    SchemaID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSchemaContext", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableSchemaContext_TableSchema_SchemaID",
                        column: x => x.SchemaID,
                        principalTable: "TableSchema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableSchemaDynamicValueCode",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    IsAsynchronous = table.Column<bool>(type: "INTEGER", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    SchemaID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSchemaDynamicValueCode", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableSchemaDynamicValueCode_TableSchema_SchemaID",
                        column: x => x.SchemaID,
                        principalTable: "TableSchema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableSchemaDynamicValueSystemParameter",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsApprovalRequired = table.Column<bool>(type: "INTEGER", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    SchemaID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSchemaDynamicValueSystemParameter", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableSchemaDynamicValueSystemParameter_TableSchema_SchemaID",
                        column: x => x.SchemaID,
                        principalTable: "TableSchema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableSchemaDynamicValueTextParameter",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    IsApprovalRequired = table.Column<bool>(type: "INTEGER", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    SchemaID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSchemaDynamicValueTextParameter", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableSchemaDynamicValueTextParameter_TableSchema_SchemaID",
                        column: x => x.SchemaID,
                        principalTable: "TableSchema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableSchemaElement",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    SchemaID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSchemaElement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableSchemaElement_TableSchema_SchemaID",
                        column: x => x.SchemaID,
                        principalTable: "TableSchema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableSchemaGroupElement",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    SchemaID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSchemaGroupElement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableSchemaGroupElement_TableSchema_SchemaID",
                        column: x => x.SchemaID,
                        principalTable: "TableSchema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableSchemaInput",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    SchemaID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSchemaInput", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableSchemaInput_TableSchema_SchemaID",
                        column: x => x.SchemaID,
                        principalTable: "TableSchema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableSchemaPropertyBoolean",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    DefaultValue = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    SchemaID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSchemaPropertyBoolean", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableSchemaPropertyBoolean_TableSchema_SchemaID",
                        column: x => x.SchemaID,
                        principalTable: "TableSchema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableSchemaPropertyDateTime",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    DefaultValue = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    SchemaID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSchemaPropertyDateTime", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableSchemaPropertyDateTime_TableSchema_SchemaID",
                        column: x => x.SchemaID,
                        principalTable: "TableSchema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableSchemaPropertyString",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    DefaultValue = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    SchemaID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSchemaPropertyString", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableSchemaPropertyString_TableSchema_SchemaID",
                        column: x => x.SchemaID,
                        principalTable: "TableSchema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableIdentity",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Handle = table.Column<string>(type: "varchar(32)", nullable: false),
                    Username = table.Column<string>(type: "varchar(32)", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeSignIn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableIdentity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableIdentity_TableUser_UserID",
                        column: x => x.UserID,
                        principalTable: "TableUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableJunctionSchemaActionHasActionStep",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EntityID = table.Column<Guid>(type: "TEXT", nullable: false),
                    RelationID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableJunctionSchemaActionHasActionStep", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableJunctionSchemaActionHasActionStep_TableSchemaActionStep_RelationID",
                        column: x => x.RelationID,
                        principalTable: "TableSchemaActionStep",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableJunctionSchemaActionHasActionStep_TableSchemaAction_EntityID",
                        column: x => x.EntityID,
                        principalTable: "TableSchemaAction",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableJunctionSchemaContextHasAction",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EntityID = table.Column<Guid>(type: "TEXT", nullable: false),
                    RelationID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableJunctionSchemaContextHasAction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableJunctionSchemaContextHasAction_TableSchemaAction_RelationID",
                        column: x => x.RelationID,
                        principalTable: "TableSchemaAction",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableJunctionSchemaContextHasAction_TableSchemaContext_EntityID",
                        column: x => x.EntityID,
                        principalTable: "TableSchemaContext",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableJunctionSchemaActionHasDynamicValueCode",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EntityID = table.Column<Guid>(type: "TEXT", nullable: false),
                    RelationID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableJunctionSchemaActionHasDynamicValueCode", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableJunctionSchemaActionHasDynamicValueCode_TableSchemaAction_EntityID",
                        column: x => x.EntityID,
                        principalTable: "TableSchemaAction",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableJunctionSchemaActionHasDynamicValueCode_TableSchemaDynamicValueCode_RelationID",
                        column: x => x.RelationID,
                        principalTable: "TableSchemaDynamicValueCode",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableJunctionSchemaContextHasElement",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EntityID = table.Column<Guid>(type: "TEXT", nullable: false),
                    RelationID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableJunctionSchemaContextHasElement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableJunctionSchemaContextHasElement_TableSchemaContext_EntityID",
                        column: x => x.EntityID,
                        principalTable: "TableSchemaContext",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableJunctionSchemaContextHasElement_TableSchemaElement_RelationID",
                        column: x => x.RelationID,
                        principalTable: "TableSchemaElement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableJunctionSchemaElementHasProperty",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EntityID = table.Column<Guid>(type: "TEXT", nullable: false),
                    RelationID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableJunctionSchemaElementHasProperty", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableJunctionSchemaElementHasProperty_TableSchemaElement_EntityID",
                        column: x => x.EntityID,
                        principalTable: "TableSchemaElement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableSchemaElementTableSchemaGroupElement",
                columns: table => new
                {
                    ElementListID = table.Column<Guid>(type: "TEXT", nullable: false),
                    GroupElementListID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSchemaElementTableSchemaGroupElement", x => new { x.ElementListID, x.GroupElementListID });
                    table.ForeignKey(
                        name: "FK_TableSchemaElementTableSchemaGroupElement_TableSchemaElement_ElementListID",
                        column: x => x.ElementListID,
                        principalTable: "TableSchemaElement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableSchemaElementTableSchemaGroupElement_TableSchemaGroupElement_GroupElementListID",
                        column: x => x.GroupElementListID,
                        principalTable: "TableSchemaGroupElement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableJunctionSchemaInputHasAttribute",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EntityID = table.Column<Guid>(type: "TEXT", nullable: false),
                    RelationID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableJunctionSchemaInputHasAttribute", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableJunctionSchemaInputHasAttribute_TableSchemaAttribute_RelationID",
                        column: x => x.RelationID,
                        principalTable: "TableSchemaAttribute",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableJunctionSchemaInputHasAttribute_TableSchemaInput_EntityID",
                        column: x => x.EntityID,
                        principalTable: "TableSchemaInput",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableSchemaActionInput",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    InputID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    SchemaIdentifier = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    SchemaID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSchemaActionInput", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableSchemaActionInput_TableSchemaInput_InputID",
                        column: x => x.InputID,
                        principalTable: "TableSchemaInput",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableSchemaActionInput_TableSchema_SchemaID",
                        column: x => x.SchemaID,
                        principalTable: "TableSchema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableAssociationSchemaActionInputHasAttributeDynamicValue",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ValueID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EntityID = table.Column<Guid>(type: "TEXT", nullable: false),
                    RelationID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableAssociationSchemaActionInputHasAttributeDynamicValue", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableAssociationSchemaActionInputHasAttributeDynamicValue_TableSchemaActionInput_EntityID",
                        column: x => x.EntityID,
                        principalTable: "TableSchemaActionInput",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableAssociationSchemaActionInputHasAttributeDynamicValue_TableSchemaAttribute_RelationID",
                        column: x => x.RelationID,
                        principalTable: "TableSchemaAttribute",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableAssociationSchemaActionInputHasAttributeInteger",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EntityID = table.Column<Guid>(type: "TEXT", nullable: false),
                    RelationID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableAssociationSchemaActionInputHasAttributeInteger", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableAssociationSchemaActionInputHasAttributeInteger_TableSchemaActionInput_EntityID",
                        column: x => x.EntityID,
                        principalTable: "TableSchemaActionInput",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableAssociationSchemaActionInputHasAttributeInteger_TableSchemaAttribute_RelationID",
                        column: x => x.RelationID,
                        principalTable: "TableSchemaAttribute",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableAssociationSchemaActionInputHasAttributeString",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EntityID = table.Column<Guid>(type: "TEXT", nullable: false),
                    RelationID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableAssociationSchemaActionInputHasAttributeString", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableAssociationSchemaActionInputHasAttributeString_TableSchemaActionInput_EntityID",
                        column: x => x.EntityID,
                        principalTable: "TableSchemaActionInput",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableAssociationSchemaActionInputHasAttributeString_TableSchemaAttribute_RelationID",
                        column: x => x.RelationID,
                        principalTable: "TableSchemaAttribute",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableJunctionSchemaActionStepHasActionInput",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EntityID = table.Column<Guid>(type: "TEXT", nullable: false),
                    RelationID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableJunctionSchemaActionStepHasActionInput", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableJunctionSchemaActionStepHasActionInput_TableSchemaActionInput_RelationID",
                        column: x => x.RelationID,
                        principalTable: "TableSchemaActionInput",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableJunctionSchemaActionStepHasActionInput_TableSchemaActionStep_EntityID",
                        column: x => x.EntityID,
                        principalTable: "TableSchemaActionStep",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TableDataTextParameter",
                columns: new[] { "ID", "SchemaIdentifier", "TimeApproved", "TimeCreated", "TimeEffective", "Value" },
                values: new object[,]
                {
                    { new Guid("019764ca-25c4-7785-bd02-ebdc5a27fb39"), "ButtonActivate", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Activate" },
                    { new Guid("019764ca-25c4-7785-bd02-efa276b57b62"), "ButtonCreate", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Create" },
                    { new Guid("019764ca-25c4-7785-bd02-f1e439a3bb07"), "ButtonUpdate", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Update" },
                    { new Guid("019764ca-25c4-7785-bd02-f7c5260cb82d"), "ButtonSubmit", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Submit" },
                    { new Guid("01977fb8-8d9e-7179-b098-d37940c4d817"), "ButtonSignIn", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Sign in" },
                    { new Guid("01977fb8-8d9e-7179-b098-d431e095ba95"), "ButtonSignUp", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Sign up" },
                    { new Guid("01978309-3029-74e9-931c-436de21f95b0"), "LinkNavigationSchema", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Schemas" }
                });

            migrationBuilder.InsertData(
                table: "TableSchema",
                columns: new[] { "ID", "IsActive", "Name", "Note", "Order", "TimeActivated", "TimeCreated" },
                values: new object[] { new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), true, "Base schema", "This is a base schema intended to be cloned and extended.", 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "TableSchemaDynamicValueTextParameter",
                columns: new[] { "ID", "IsApprovalRequired", "Name", "Note", "Order", "SchemaID", "SchemaIdentifier", "TimeCreated", "Type" },
                values: new object[,]
                {
                    { new Guid("019764ca-25c4-7785-bd02-daa168ae477d"), false, "ButtonActivate", "", 1, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "ButtonActivate", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019764ca-25c4-7785-bd02-de67a804e592"), false, "ButtonCreate", "", 2, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "ButtonCreate", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019764ca-25c4-7785-bd02-e26550fa3aa9"), false, "ButtonUpdate", "", 3, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "ButtonUpdate", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019764ca-25c4-7785-bd02-e5902e766443"), false, "ButtonSubmit", "", 4, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "ButtonSubmit", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01977fb8-8d9e-7179-b098-d8800c456351"), false, "ButtonSignIn", "", 5, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "ButtonSignIn", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01977fb8-8d9e-7179-b098-dde7fae42dc4"), false, "ButtonSignUp", "", 6, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "ButtonSignUp", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01978309-3029-74e9-931c-3cf1322948fd"), false, "LinkNavigationSchema", "", 7, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "LinkNavigationSchema", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 }
                });

            migrationBuilder.InsertData(
                table: "TableSchemaInput",
                columns: new[] { "ID", "Name", "Note", "Order", "SchemaID", "SchemaIdentifier", "TimeCreated" },
                values: new object[,]
                {
                    { new Guid("01974e8c-ecb8-75ab-9070-f0fed39b9c54"), "Checkbox", "The base checkbox input type.", 1, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "ActionInputCheckbox", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("01974e8c-ecb8-75ab-9070-f625218aed76"), "Date input", "The base date input type.", 2, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "ActionInputDate", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("01974e8c-ecb8-75ab-9070-f8a855e17dda"), "Text input", "The base text input type.", 7, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "ActionInputText", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("019765f7-2847-757d-8d6f-e48dbec5bbeb"), "Decimal input", "The base decimal input type.", 3, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "ActionInputDecimal", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("019765f7-2847-757d-8d6f-ea72d6453f86"), "Integer input", "The base integer input type.", 4, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "ActionInputInteger", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("019765f7-2847-757d-8d6f-ec49fff67113"), "Password input", "The base password input type.", 5, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "ActionInputPassword", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("019765f7-2847-757d-8d6f-ec49fff67fa1"), "Single choice input", "The base single choice input type.", 6, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "ActionInputSingleChoice", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TableAssociationSchemaActionInputHasAttributeDynamicValue_EntityID",
                table: "TableAssociationSchemaActionInputHasAttributeDynamicValue",
                column: "EntityID");

            migrationBuilder.CreateIndex(
                name: "IX_TableAssociationSchemaActionInputHasAttributeDynamicValue_RelationID",
                table: "TableAssociationSchemaActionInputHasAttributeDynamicValue",
                column: "RelationID");

            migrationBuilder.CreateIndex(
                name: "IX_TableAssociationSchemaActionInputHasAttributeDynamicValue_TimeCreated",
                table: "TableAssociationSchemaActionInputHasAttributeDynamicValue",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableAssociationSchemaActionInputHasAttributeDynamicValue_ValueID",
                table: "TableAssociationSchemaActionInputHasAttributeDynamicValue",
                column: "ValueID");

            migrationBuilder.CreateIndex(
                name: "IX_TableAssociationSchemaActionInputHasAttributeInteger_EntityID",
                table: "TableAssociationSchemaActionInputHasAttributeInteger",
                column: "EntityID");

            migrationBuilder.CreateIndex(
                name: "IX_TableAssociationSchemaActionInputHasAttributeInteger_RelationID",
                table: "TableAssociationSchemaActionInputHasAttributeInteger",
                column: "RelationID");

            migrationBuilder.CreateIndex(
                name: "IX_TableAssociationSchemaActionInputHasAttributeInteger_TimeCreated",
                table: "TableAssociationSchemaActionInputHasAttributeInteger",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableAssociationSchemaActionInputHasAttributeString_EntityID",
                table: "TableAssociationSchemaActionInputHasAttributeString",
                column: "EntityID");

            migrationBuilder.CreateIndex(
                name: "IX_TableAssociationSchemaActionInputHasAttributeString_RelationID",
                table: "TableAssociationSchemaActionInputHasAttributeString",
                column: "RelationID");

            migrationBuilder.CreateIndex(
                name: "IX_TableAssociationSchemaActionInputHasAttributeString_TimeCreated",
                table: "TableAssociationSchemaActionInputHasAttributeString",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableAuthentication_TimeCreated",
                table: "TableAuthentication",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableDataElement_TimeCreated",
                table: "TableDataElement",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableDataPropertyBoolean_ElementID",
                table: "TableDataPropertyBoolean",
                column: "ElementID");

            migrationBuilder.CreateIndex(
                name: "IX_TableDataPropertyBoolean_TimeCreated",
                table: "TableDataPropertyBoolean",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableDataPropertyDateTime_ElementID",
                table: "TableDataPropertyDateTime",
                column: "ElementID");

            migrationBuilder.CreateIndex(
                name: "IX_TableDataPropertyDateTime_TimeCreated",
                table: "TableDataPropertyDateTime",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableDataPropertyString_ElementID",
                table: "TableDataPropertyString",
                column: "ElementID");

            migrationBuilder.CreateIndex(
                name: "IX_TableDataPropertyString_TimeCreated",
                table: "TableDataPropertyString",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableDataSystemParameter_TimeCreated",
                table: "TableDataSystemParameter",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableDataTextParameter_TimeCreated",
                table: "TableDataTextParameter",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableIdentity_TimeCreated",
                table: "TableIdentity",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableIdentity_UserID",
                table: "TableIdentity",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaActionHasActionStep_EntityID_RelationID",
                table: "TableJunctionSchemaActionHasActionStep",
                columns: new[] { "EntityID", "RelationID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaActionHasActionStep_RelationID",
                table: "TableJunctionSchemaActionHasActionStep",
                column: "RelationID");

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaActionHasActionStep_TimeCreated",
                table: "TableJunctionSchemaActionHasActionStep",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaActionHasDynamicValueCode_EntityID_RelationID",
                table: "TableJunctionSchemaActionHasDynamicValueCode",
                columns: new[] { "EntityID", "RelationID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaActionHasDynamicValueCode_RelationID",
                table: "TableJunctionSchemaActionHasDynamicValueCode",
                column: "RelationID");

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaActionHasDynamicValueCode_TimeCreated",
                table: "TableJunctionSchemaActionHasDynamicValueCode",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaActionStepHasActionInput_EntityID_RelationID",
                table: "TableJunctionSchemaActionStepHasActionInput",
                columns: new[] { "EntityID", "RelationID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaActionStepHasActionInput_RelationID",
                table: "TableJunctionSchemaActionStepHasActionInput",
                column: "RelationID");

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaActionStepHasActionInput_TimeCreated",
                table: "TableJunctionSchemaActionStepHasActionInput",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaContextHasAction_EntityID_RelationID",
                table: "TableJunctionSchemaContextHasAction",
                columns: new[] { "EntityID", "RelationID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaContextHasAction_RelationID",
                table: "TableJunctionSchemaContextHasAction",
                column: "RelationID");

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaContextHasAction_TimeCreated",
                table: "TableJunctionSchemaContextHasAction",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaContextHasElement_EntityID_RelationID",
                table: "TableJunctionSchemaContextHasElement",
                columns: new[] { "EntityID", "RelationID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaContextHasElement_RelationID",
                table: "TableJunctionSchemaContextHasElement",
                column: "RelationID");

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaContextHasElement_TimeCreated",
                table: "TableJunctionSchemaContextHasElement",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaElementHasProperty_EntityID_RelationID",
                table: "TableJunctionSchemaElementHasProperty",
                columns: new[] { "EntityID", "RelationID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaElementHasProperty_RelationID",
                table: "TableJunctionSchemaElementHasProperty",
                column: "RelationID");

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaElementHasProperty_TimeCreated",
                table: "TableJunctionSchemaElementHasProperty",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaInputHasAttribute_EntityID_RelationID",
                table: "TableJunctionSchemaInputHasAttribute",
                columns: new[] { "EntityID", "RelationID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaInputHasAttribute_RelationID",
                table: "TableJunctionSchemaInputHasAttribute",
                column: "RelationID");

            migrationBuilder.CreateIndex(
                name: "IX_TableJunctionSchemaInputHasAttribute_TimeCreated",
                table: "TableJunctionSchemaInputHasAttribute",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchema_TimeCreated",
                table: "TableSchema",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaAction_SchemaID_SchemaIdentifier",
                table: "TableSchemaAction",
                columns: new[] { "SchemaID", "SchemaIdentifier" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaAction_TimeCreated",
                table: "TableSchemaAction",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaAction_TitleDynamicID",
                table: "TableSchemaAction",
                column: "TitleDynamicID");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaActionInput_InputID",
                table: "TableSchemaActionInput",
                column: "InputID");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaActionInput_SchemaID_SchemaIdentifier",
                table: "TableSchemaActionInput",
                columns: new[] { "SchemaID", "SchemaIdentifier" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaActionInput_TimeCreated",
                table: "TableSchemaActionInput",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaActionStep_SchemaID_SchemaIdentifier",
                table: "TableSchemaActionStep",
                columns: new[] { "SchemaID", "SchemaIdentifier" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaActionStep_TimeCreated",
                table: "TableSchemaActionStep",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaAttribute_SchemaID_SchemaIdentifier",
                table: "TableSchemaAttribute",
                columns: new[] { "SchemaID", "SchemaIdentifier" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaAttribute_TimeCreated",
                table: "TableSchemaAttribute",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaContext_SchemaID_SchemaIdentifier",
                table: "TableSchemaContext",
                columns: new[] { "SchemaID", "SchemaIdentifier" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaContext_TimeCreated",
                table: "TableSchemaContext",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaDynamicValueCode_SchemaID",
                table: "TableSchemaDynamicValueCode",
                column: "SchemaID");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaDynamicValueCode_SchemaID_SchemaIdentifier",
                table: "TableSchemaDynamicValueCode",
                columns: new[] { "SchemaID", "SchemaIdentifier" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaDynamicValueCode_TimeCreated",
                table: "TableSchemaDynamicValueCode",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaDynamicValueSystemParameter_SchemaID",
                table: "TableSchemaDynamicValueSystemParameter",
                column: "SchemaID");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaDynamicValueSystemParameter_SchemaID_SchemaIdentifier",
                table: "TableSchemaDynamicValueSystemParameter",
                columns: new[] { "SchemaID", "SchemaIdentifier" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaDynamicValueSystemParameter_TimeCreated",
                table: "TableSchemaDynamicValueSystemParameter",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaDynamicValueTextParameter_SchemaID",
                table: "TableSchemaDynamicValueTextParameter",
                column: "SchemaID");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaDynamicValueTextParameter_SchemaID_SchemaIdentifier",
                table: "TableSchemaDynamicValueTextParameter",
                columns: new[] { "SchemaID", "SchemaIdentifier" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaDynamicValueTextParameter_TimeCreated",
                table: "TableSchemaDynamicValueTextParameter",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaElement_SchemaID_SchemaIdentifier",
                table: "TableSchemaElement",
                columns: new[] { "SchemaID", "SchemaIdentifier" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaElement_TimeCreated",
                table: "TableSchemaElement",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaElementTableSchemaGroupElement_GroupElementListID",
                table: "TableSchemaElementTableSchemaGroupElement",
                column: "GroupElementListID");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaGroupElement_SchemaID_SchemaIdentifier",
                table: "TableSchemaGroupElement",
                columns: new[] { "SchemaID", "SchemaIdentifier" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaGroupElement_TimeCreated",
                table: "TableSchemaGroupElement",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaInput_SchemaID_SchemaIdentifier",
                table: "TableSchemaInput",
                columns: new[] { "SchemaID", "SchemaIdentifier" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaInput_TimeCreated",
                table: "TableSchemaInput",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaPropertyBoolean_SchemaID",
                table: "TableSchemaPropertyBoolean",
                column: "SchemaID");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaPropertyBoolean_SchemaID_SchemaIdentifier",
                table: "TableSchemaPropertyBoolean",
                columns: new[] { "SchemaID", "SchemaIdentifier" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaPropertyBoolean_TimeCreated",
                table: "TableSchemaPropertyBoolean",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaPropertyDateTime_SchemaID",
                table: "TableSchemaPropertyDateTime",
                column: "SchemaID");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaPropertyDateTime_SchemaID_SchemaIdentifier",
                table: "TableSchemaPropertyDateTime",
                columns: new[] { "SchemaID", "SchemaIdentifier" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaPropertyDateTime_TimeCreated",
                table: "TableSchemaPropertyDateTime",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaPropertyString_SchemaID",
                table: "TableSchemaPropertyString",
                column: "SchemaID");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaPropertyString_SchemaID_SchemaIdentifier",
                table: "TableSchemaPropertyString",
                columns: new[] { "SchemaID", "SchemaIdentifier" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaPropertyString_TimeCreated",
                table: "TableSchemaPropertyString",
                column: "TimeCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TableUser_AuthenticationID",
                table: "TableUser",
                column: "AuthenticationID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableUser_Email",
                table: "TableUser",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableUser_TimeCreated",
                table: "TableUser",
                column: "TimeCreated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableAssociationSchemaActionInputHasAttributeDynamicValue");

            migrationBuilder.DropTable(
                name: "TableAssociationSchemaActionInputHasAttributeInteger");

            migrationBuilder.DropTable(
                name: "TableAssociationSchemaActionInputHasAttributeString");

            migrationBuilder.DropTable(
                name: "TableDataPropertyBoolean");

            migrationBuilder.DropTable(
                name: "TableDataPropertyDateTime");

            migrationBuilder.DropTable(
                name: "TableDataPropertyString");

            migrationBuilder.DropTable(
                name: "TableDataSystemParameter");

            migrationBuilder.DropTable(
                name: "TableDataTextParameter");

            migrationBuilder.DropTable(
                name: "TableIdentity");

            migrationBuilder.DropTable(
                name: "TableJunctionSchemaActionHasActionStep");

            migrationBuilder.DropTable(
                name: "TableJunctionSchemaActionHasDynamicValueCode");

            migrationBuilder.DropTable(
                name: "TableJunctionSchemaActionStepHasActionInput");

            migrationBuilder.DropTable(
                name: "TableJunctionSchemaContextHasAction");

            migrationBuilder.DropTable(
                name: "TableJunctionSchemaContextHasElement");

            migrationBuilder.DropTable(
                name: "TableJunctionSchemaElementHasProperty");

            migrationBuilder.DropTable(
                name: "TableJunctionSchemaInputHasAttribute");

            migrationBuilder.DropTable(
                name: "TableSchemaDynamicValueSystemParameter");

            migrationBuilder.DropTable(
                name: "TableSchemaDynamicValueTextParameter");

            migrationBuilder.DropTable(
                name: "TableSchemaElementTableSchemaGroupElement");

            migrationBuilder.DropTable(
                name: "TableSchemaPropertyBoolean");

            migrationBuilder.DropTable(
                name: "TableSchemaPropertyDateTime");

            migrationBuilder.DropTable(
                name: "TableSchemaPropertyString");

            migrationBuilder.DropTable(
                name: "TableDataElement");

            migrationBuilder.DropTable(
                name: "TableUser");

            migrationBuilder.DropTable(
                name: "TableSchemaDynamicValueCode");

            migrationBuilder.DropTable(
                name: "TableSchemaActionInput");

            migrationBuilder.DropTable(
                name: "TableSchemaActionStep");

            migrationBuilder.DropTable(
                name: "TableSchemaAction");

            migrationBuilder.DropTable(
                name: "TableSchemaContext");

            migrationBuilder.DropTable(
                name: "TableSchemaAttribute");

            migrationBuilder.DropTable(
                name: "TableSchemaElement");

            migrationBuilder.DropTable(
                name: "TableSchemaGroupElement");

            migrationBuilder.DropTable(
                name: "TableAuthentication");

            migrationBuilder.DropTable(
                name: "TableSchemaInput");

            migrationBuilder.DropTable(
                name: "TableSchema");
        }
    }
}
