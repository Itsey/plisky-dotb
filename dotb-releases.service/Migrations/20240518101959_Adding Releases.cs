using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotbreleases.service.Migrations
{
    /// <inheritdoc />
    public partial class AddingReleases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExternalIdentifier",
                table: "Systems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "Key",
                table: "Systems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Meta1",
                table: "Systems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Meta2",
                table: "Systems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "Releases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Environment",
                table: "Releases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "Key",
                table: "Releases",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Meta1",
                table: "Releases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Meta2",
                table: "Releases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Releases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "Releases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemsStoreId = table.Column<int>(type: "int", nullable: false),
                    ReleaseStoreId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meta1 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Components_Releases_ReleaseStoreId",
                        column: x => x.ReleaseStoreId,
                        principalTable: "Releases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Components_Systems_SystemsStoreId",
                        column: x => x.SystemsStoreId,
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Components_ReleaseStoreId",
                table: "Components",
                column: "ReleaseStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_SystemsStoreId",
                table: "Components",
                column: "SystemsStoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropColumn(
                name: "ExternalIdentifier",
                table: "Systems");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Systems");

            migrationBuilder.DropColumn(
                name: "Meta1",
                table: "Systems");

            migrationBuilder.DropColumn(
                name: "Meta2",
                table: "Systems");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "Releases");

            migrationBuilder.DropColumn(
                name: "Environment",
                table: "Releases");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Releases");

            migrationBuilder.DropColumn(
                name: "Meta1",
                table: "Releases");

            migrationBuilder.DropColumn(
                name: "Meta2",
                table: "Releases");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Releases");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Releases");
        }
    }
}
