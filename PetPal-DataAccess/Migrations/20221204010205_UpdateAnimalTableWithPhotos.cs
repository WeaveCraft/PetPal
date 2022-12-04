using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetPalDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAnimalTableWithPhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Race",
                table: "Animals",
                newName: "Genders");

            migrationBuilder.RenameColumn(
                name: "ColorType",
                table: "Animals",
                newName: "KnownAs");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "AppUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActive",
                table: "AppUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LookingFor",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Animals",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Animals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Animals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Animals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FavoriteToy",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FavoriteTreat",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AppUserId",
                table: "Animals",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AnimalId",
                table: "Photos",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_AppUsers_AppUserId",
                table: "Animals",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_AppUsers_AppUserId",
                table: "Animals");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Animals_AppUserId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "LastActive",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "LookingFor",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "FavoriteToy",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "FavoriteTreat",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Interests",
                table: "Animals");

            migrationBuilder.RenameColumn(
                name: "KnownAs",
                table: "Animals",
                newName: "ColorType");

            migrationBuilder.RenameColumn(
                name: "Genders",
                table: "Animals",
                newName: "Race");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Animals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
