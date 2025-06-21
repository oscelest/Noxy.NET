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
                name: "TableSchemaDynamicValueStyleParameter",
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
                    table.PrimaryKey("PK_TableSchemaDynamicValueStyleParameter", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TableSchemaDynamicValueStyleParameter_TableSchema_SchemaID",
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
                    { new Guid("01978309-3029-74e9-931c-436de21f95b0"), "LinkNavigationSchema", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Schemas" },
                    { new Guid("019789f9-2601-72ac-ad27-ea4b8f4855d6"), "LabelFormSchemaIdentifier", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Schema identifier" },
                    { new Guid("019789f9-2601-72ac-ad27-ed762c6df40e"), "LabelFormInputID", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Input type" },
                    { new Guid("019789f9-2601-72ac-ad27-f1f7ad078b01"), "LabelFormName", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Name" },
                    { new Guid("019789f9-2601-72ac-ad27-f7c76f0002d4"), "LabelFormNote", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Note" },
                    { new Guid("019789f9-2601-72ac-ad27-f9ef87027fec"), "LabelFormTitle", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Title" },
                    { new Guid("019789f9-2601-72ac-ad27-fceadc8f7eda"), "LabelFormDescription", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Description" },
                    { new Guid("019789f9-2601-72ac-ad28-0204b7c6d497"), "LabelFormOrder", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Order" },
                    { new Guid("019789fc-18dc-73ee-94b6-1564b2f72eb7"), "HelpFormSchemaIdentifier", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The unique, humanly readable identifier for this entity type." },
                    { new Guid("019789fc-18dc-73ee-94b6-18a6e3314ccd"), "HelpFormInputID", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The type of input this entity is related with." },
                    { new Guid("019789fc-18dc-73ee-94b6-1c60e96f26a9"), "HelpFormName", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The internal name of this entity type. Should only be visible in the configuration." },
                    { new Guid("019789fc-18dc-73ee-94b6-21b290f8401d"), "HelpFormNote", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "A short note detailing how this entity type is used. Should only be visible in the configuration." },
                    { new Guid("019789fc-18dc-73ee-94b6-26ead5f18d4d"), "HelpFormTitle", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The title used when displaying an entity of this type." },
                    { new Guid("019789fc-18dc-73ee-94b6-28dc0edf9b69"), "HelpFormDescription", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The description used when displaying an entity of this type." },
                    { new Guid("019789fc-18dc-73ee-94b6-2ee0b27366dc"), "HelpFormOrder", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The order in which this entity type is sorted." },
                    { new Guid("019789fc-3929-75a9-99e9-142d13f18fb0"), "DefaultEmptyValue", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "-" },
                    { new Guid("01978a17-7901-7131-8b49-0a2832bb83bd"), "LabelFormValue", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Value" },
                    { new Guid("01978a17-7901-7131-8b49-0cb8c0a70a25"), "LabelFormDefaultValue", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Default value" },
                    { new Guid("01978a17-7901-7131-8b49-1200bad01c81"), "LabelFormIsApprovalRequired", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Is approval required?" },
                    { new Guid("01978a17-7901-7131-8b49-179f268688f2"), "LabelFormIsAsynchronous", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Is asynchronous?" },
                    { new Guid("01978a17-b7b1-772f-a129-5fe41a2f1676"), "HelpFormValue", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The code snippet to be run. Must return a value." },
                    { new Guid("01978a17-b7b1-772f-a129-6253fc96820a"), "HelpFormDefaultValue", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The default value that will be used for this entity type." },
                    { new Guid("01978a17-b7b1-772f-a129-66dba634b0b5"), "HelpFormIsApprovalRequired", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Determines if another user must approve a text parameter value before it becomes active." },
                    { new Guid("01978a17-b7b1-772f-a129-68c0836a0759"), "HelpFormIsAsynchronous", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Determines if the method will be run as asynchronous code." },
                    { new Guid("01978a1f-f0a2-731f-b17d-1981b375a5db"), "LabelFormIsRepeatable", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Is repeatable?" },
                    { new Guid("01978a1f-f0a2-731f-b17d-1e57e7540e08"), "LabelFormAttributeType", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Attribute type" },
                    { new Guid("01978a1f-f0a2-731f-b17d-2174a6ecd4fe"), "LabelFormTextParameterType", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Text parameter type" },
                    { new Guid("01978a1f-f0a2-731f-b17d-2553ac69936f"), "LabelFormIsList", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Is value list?" },
                    { new Guid("01978a20-9692-72ff-be7d-ac500344bf4b"), "HelpFormIsRepeatable", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Determines if this step can be completed with multiple results." },
                    { new Guid("01978a20-9692-72ff-be7d-b08279f62f4a"), "HelpFormAttributeType", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The type of attribute." },
                    { new Guid("01978a20-9692-72ff-be7d-b59a17facafb"), "HelpFormTextParameterType", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The type of text parameter." },
                    { new Guid("01978a20-9692-72ff-be7d-ba24274b04c3"), "HelpFormIsList", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Determines if this input attribute can be configured with a list of values." }
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
                    { new Guid("019764ca-25c4-7785-bd02-daa168ae477d"), false, "ButtonActivate", "", 2, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "ButtonActivate", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019764ca-25c4-7785-bd02-de67a804e592"), false, "ButtonCreate", "", 3, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "ButtonCreate", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019764ca-25c4-7785-bd02-e26550fa3aa9"), false, "ButtonUpdate", "", 4, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "ButtonUpdate", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019764ca-25c4-7785-bd02-e5902e766443"), false, "ButtonSubmit", "", 5, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "ButtonSubmit", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01977fb8-8d9e-7179-b098-d8800c456351"), false, "ButtonSignIn", "", 6, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "ButtonSignIn", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01977fb8-8d9e-7179-b098-dde7fae42dc4"), false, "ButtonSignUp", "", 7, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "ButtonSignUp", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01978309-3029-74e9-931c-3cf1322948fd"), false, "LinkNavigationSchema", "", 8, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "LinkNavigationSchema", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019789de-e449-71aa-ab1d-0992c66a9dae"), false, "LabelFormSchemaIdentifier", "", 9, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "LabelFormSchemaIdentifier", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019789de-e449-71aa-ab1d-0e7af6463e30"), false, "LabelFormInputID", "", 15, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "LabelFormInputID", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019789de-e449-71aa-ab1d-12e8b546b239"), false, "LabelFormName", "", 10, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "LabelFormName", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019789de-e449-71aa-ab1d-17209b94ded6"), false, "LabelFormNote", "", 11, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "LabelFormNote", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019789de-e449-71aa-ab1d-192c4a3c0eb6"), false, "LabelFormTitle", "", 12, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "LabelFormTitle", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019789de-e449-71aa-ab1d-1c1707f61f89"), false, "LabelFormDescription", "", 13, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "LabelFormDescription", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019789de-e449-71aa-ab1d-205e04219122"), false, "LabelFormOrder", "", 14, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "LabelFormOrder", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019789fc-3929-75a9-99e8-f7a6abf0c139"), false, "HelpFormSchemaIdentifier", "", 24, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "HelpFormSchemaIdentifier", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019789fc-3929-75a9-99e8-f819edf63934"), false, "HelpFormName", "", 25, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "HelpFormName", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019789fc-3929-75a9-99e8-ffd616e87b30"), false, "HelpFormNote", "", 26, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "HelpFormNote", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019789fc-3929-75a9-99e9-0229499f0ddd"), false, "HelpFormTitle", "", 27, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "HelpFormTitle", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019789fc-3929-75a9-99e9-046632ba51b7"), false, "HelpFormDescription", "", 28, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "HelpFormDescription", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019789fc-3929-75a9-99e9-0a5f8ca00604"), false, "HelpFormOrder", "", 29, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "HelpFormOrder", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019789fc-3929-75a9-99e9-0c9241c61162"), false, "HelpFormInputID", "", 30, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "HelpFormInputID", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("019789fc-3929-75a9-99e9-11f9d8b81e8a"), false, "DefaultEmptyValue", "", 1, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "DefaultEmptyValue", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01978a17-7901-7131-8b48-f882aa64e37a"), false, "LabelFormValue", "", 16, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "LabelFormValue", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01978a17-7901-7131-8b48-ff6a41005bb3"), false, "LabelFormDefaultValue", "", 17, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "LabelFormDefaultValue", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01978a17-7901-7131-8b49-005b042a1608"), false, "LabelFormIsApprovalRequired", "", 18, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "LabelFormIsApprovalRequired", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01978a17-7901-7131-8b49-07a43e807dfd"), false, "LabelFormIsAsynchronous", "", 19, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "LabelFormIsAsynchronous", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01978a17-b7b1-772f-a129-4ce642008489"), false, "HelpFormValue", "", 31, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "HelpFormValue", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01978a17-b7b1-772f-a129-52ee6b9269cd"), false, "HelpFormDefaultValue", "", 32, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "HelpFormDefaultValue", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01978a17-b7b1-772f-a129-543b087e1606"), false, "HelpFormIsApprovalRequired", "", 33, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "HelpFormIsApprovalRequired", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01978a17-b7b1-772f-a129-5bbae750bee1"), false, "HelpFormIsAsynchronous", "", 34, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "HelpFormIsAsynchronous", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01978a1f-f0a2-731f-b17d-0991eba49899"), false, "LabelFormIsRepeatable", "", 20, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "LabelFormIsRepeatable", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01978a1f-f0a2-731f-b17d-0e2bbf4c0700"), false, "LabelFormAttributeType", "", 21, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "LabelFormAttributeType", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01978a1f-f0a2-731f-b17d-12579bcc7198"), false, "LabelFormTextParameterType", "", 22, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "LabelFormTextParameterType", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01978a1f-f0a2-731f-b17d-14f803055489"), false, "LabelFormIsList", "", 23, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "LabelFormIsList", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01978a20-9692-72ff-be7d-9cb3d3d46359"), false, "HelpFormIsRepeatable", "", 35, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "HelpFormIsRepeatable", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01978a20-9692-72ff-be7d-a3b72d338572"), false, "HelpFormAttributeType", "", 36, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "HelpFormAttributeType", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01978a20-9692-72ff-be7d-a62334e7d3c4"), false, "HelpFormTextParameterType", "", 37, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "HelpFormTextParameterType", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("01978a20-9692-72ff-be7d-a9bb3d99565a"), false, "HelpFormIsList", "", 38, new Guid("01974e8c-ecb8-75ab-9070-ef902ff370a7"), "HelpFormIsList", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 }
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
                name: "IX_TableSchemaDynamicValueStyleParameter_SchemaID",
                table: "TableSchemaDynamicValueStyleParameter",
                column: "SchemaID");

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaDynamicValueStyleParameter_SchemaID_SchemaIdentifier",
                table: "TableSchemaDynamicValueStyleParameter",
                columns: new[] { "SchemaID", "SchemaIdentifier" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableSchemaDynamicValueStyleParameter_TimeCreated",
                table: "TableSchemaDynamicValueStyleParameter",
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
                name: "TableSchemaDynamicValueStyleParameter");

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
