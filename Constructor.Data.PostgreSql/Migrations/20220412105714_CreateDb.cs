using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Constructor.Data.PostgreSql.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ComponentId = table.Column<Guid>(type: "uuid", nullable: true),
                    ParentId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Domains_Domains_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityTypeGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DomainId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityTypeGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityTypeGroups_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PluralName = table.Column<string>(type: "varchar", maxLength: 100, nullable: true),
                    DomainId = table.Column<int>(type: "integer", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<byte>(type: "smallint", nullable: false),
                    IsAbstract = table.Column<bool>(type: "boolean", nullable: false),
                    IsMasterData = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityTypes_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityTypes_EntityTypeGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "EntityTypeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityTypes_EntityTypes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "EntityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DomainId = table.Column<int>(type: "integer", nullable: false),
                    EntityTypeId = table.Column<int>(type: "integer", nullable: false),
                    ScalarValues = table.Column<string>(type: "jsonb", nullable: true),
                    Name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entites_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entites_EntityTypes_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalTable: "EntityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EntityTypeId = table.Column<int>(type: "integer", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    IsPartOfName = table.Column<bool>(type: "boolean", nullable: false),
                    Sequence = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    ValueTypeId = table.Column<int>(type: "integer", nullable: true),
                    IsSet = table.Column<bool>(type: "boolean", nullable: true),
                    ReferenceKind = table.Column<byte>(type: "smallint", nullable: true),
                    DeleteMode = table.Column<byte>(type: "smallint", nullable: true),
                    Name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityProperties_EntityTypes_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalTable: "EntityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityProperties_EntityTypes_ValueTypeId",
                        column: x => x.ValueTypeId,
                        principalTable: "EntityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityTypeImports",
                columns: table => new
                {
                    ImportedTypesId = table.Column<int>(type: "integer", nullable: false),
                    ImportingDomainsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityTypeImports", x => new { x.ImportedTypesId, x.ImportingDomainsId });
                    table.ForeignKey(
                        name: "FK_EntityTypeImports_Domains_ImportingDomainsId",
                        column: x => x.ImportingDomainsId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityTypeImports_EntityTypes_ImportedTypesId",
                        column: x => x.ImportedTypesId,
                        principalTable: "EntityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DomainId = table.Column<int>(type: "integer", nullable: false),
                    EntityTypeId = table.Column<int>(type: "integer", nullable: false),
                    RootEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Models_Entites_RootEntityId",
                        column: x => x.RootEntityId,
                        principalTable: "Entites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Models_EntityTypes_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalTable: "EntityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityLinks",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "integer", nullable: false),
                    EntitySourceId = table.Column<int>(type: "integer", nullable: false),
                    EntityTargetId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityLinks", x => new { x.PropertyId, x.EntitySourceId });
                    table.ForeignKey(
                        name: "FK_EntityLinks_Entites_EntitySourceId",
                        column: x => x.EntitySourceId,
                        principalTable: "Entites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityLinks_Entites_EntityTargetId",
                        column: x => x.EntityTargetId,
                        principalTable: "Entites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityLinks_EntityProperties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "EntityProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    PropertyId = table.Column<int>(type: "integer", nullable: false),
                    EntityId = table.Column<int>(type: "integer", nullable: false),
                    Sequence = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelItems_Entites_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelItems_EntityProperties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "EntityProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelItems_ModelItems_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ModelItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModelItems_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Domains_ParentId",
                table: "Domains",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Entites_DomainId",
                table: "Entites",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Entites_EntityTypeId",
                table: "Entites",
                column: "EntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityLinks_EntitySourceId",
                table: "EntityLinks",
                column: "EntitySourceId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityLinks_EntityTargetId",
                table: "EntityLinks",
                column: "EntityTargetId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityProperties_EntityTypeId",
                table: "EntityProperties",
                column: "EntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityProperties_ValueTypeId",
                table: "EntityProperties",
                column: "ValueTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityTypeGroups_DomainId",
                table: "EntityTypeGroups",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityTypeImports_ImportingDomainsId",
                table: "EntityTypeImports",
                column: "ImportingDomainsId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityTypes_DomainId",
                table: "EntityTypes",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityTypes_GroupId",
                table: "EntityTypes",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityTypes_ParentId",
                table: "EntityTypes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelItems_EntityId",
                table: "ModelItems",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelItems_ModelId",
                table: "ModelItems",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelItems_ParentId",
                table: "ModelItems",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelItems_PropertyId",
                table: "ModelItems",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_DomainId",
                table: "Models",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_EntityTypeId",
                table: "Models",
                column: "EntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_RootEntityId",
                table: "Models",
                column: "RootEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityLinks");

            migrationBuilder.DropTable(
                name: "EntityTypeImports");

            migrationBuilder.DropTable(
                name: "ModelItems");

            migrationBuilder.DropTable(
                name: "EntityProperties");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Entites");

            migrationBuilder.DropTable(
                name: "EntityTypes");

            migrationBuilder.DropTable(
                name: "EntityTypeGroups");

            migrationBuilder.DropTable(
                name: "Domains");
        }
    }
}
