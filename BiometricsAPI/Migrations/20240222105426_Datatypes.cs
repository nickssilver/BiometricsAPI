using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiometricsAPI.Migrations
{
    /// <inheritdoc />
    public partial class Datatypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Biousers_UserId",
                table: "Biousers");

            migrationBuilder.AlterColumn<string>(
                name: "Pin",
                table: "Biousers",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "Biousers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Pin",
                table: "Biousers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "Biousers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.CreateIndex(
                name: "IX_Biousers_UserId",
                table: "Biousers",
                column: "UserId",
                unique: true);
        }
    }
}
