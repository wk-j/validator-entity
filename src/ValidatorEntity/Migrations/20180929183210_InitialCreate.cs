using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ValidatorEntity.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AlfrescoUuid = table.Column<string>(type: "text", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "text", nullable: true),
                    DescriptionFormat = table.Column<string>(type: "text", nullable: true),
                    FinalName = table.Column<string>(type: "text", nullable: true),
                    FinalPath = table.Column<string>(type: "text", nullable: true),
                    LocalFileName = table.Column<string>(type: "text", nullable: true),
                    NameFormat = table.Column<string>(type: "text", nullable: true),
                    OriginalFileName = table.Column<string>(type: "text", nullable: true),
                    PathFormat = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "int4", nullable: false),
                    Template = table.Column<string>(type: "text", nullable: true),
                    TitleFormat = table.Column<string>(type: "text", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Uuid = table.Column<string>(type: "text", nullable: true),
                    ValidateDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Validator = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QReconciles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Category = table.Column<string>(type: "text", nullable: true),
                    Creator = table.Column<string>(type: "text", nullable: true),
                    DocumentDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    ObjectType = table.Column<string>(type: "text", nullable: true),
                    Reference = table.Column<string>(type: "text", nullable: true),
                    Reference1 = table.Column<string>(type: "text", nullable: true),
                    Reference2 = table.Column<string>(type: "text", nullable: true),
                    Site = table.Column<string>(type: "text", nullable: true),
                    TCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QReconciles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Template = table.Column<string>(type: "text", nullable: true),
                    ValidationChecklistsText = table.Column<string>(type: "text", nullable: true),
                    ValidationKey = table.Column<string>(type: "text", nullable: true),
                    ValidationRequire = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateTimeValue = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NumberValue = table.Column<float>(type: "float4", nullable: false),
                    PropertyType = table.Column<int>(type: "int4", nullable: false),
                    QFileId = table.Column<int>(type: "int4", nullable: false),
                    StringValue = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QProperties_QFiles_QFileId",
                        column: x => x.QFileId,
                        principalTable: "QFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QRejectReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    QFileId = table.Column<int>(type: "int4", nullable: false),
                    ReasonId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRejectReasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QRejectReasons_QFiles_QFileId",
                        column: x => x.QFileId,
                        principalTable: "QFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QFiles_Status",
                table: "QFiles",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_QFiles_Uuid",
                table: "QFiles",
                column: "Uuid");

            migrationBuilder.CreateIndex(
                name: "IX_QProperties_QFileId",
                table: "QProperties",
                column: "QFileId");

            migrationBuilder.CreateIndex(
                name: "IX_QRejectReasons_QFileId",
                table: "QRejectReasons",
                column: "QFileId");

            migrationBuilder.CreateIndex(
                name: "IX_QTemplates_Template",
                table: "QTemplates",
                column: "Template");

            migrationBuilder.CreateIndex(
                name: "IX_QTemplates_ValidationRequire",
                table: "QTemplates",
                column: "ValidationRequire");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QProperties");

            migrationBuilder.DropTable(
                name: "QReconciles");

            migrationBuilder.DropTable(
                name: "QRejectReasons");

            migrationBuilder.DropTable(
                name: "QTemplates");

            migrationBuilder.DropTable(
                name: "QFiles");
        }
    }
}
