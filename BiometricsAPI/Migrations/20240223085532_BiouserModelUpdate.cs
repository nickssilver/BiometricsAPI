using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiometricsAPI.Migrations
{
    /// <inheritdoc />
    public partial class BiouserModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Permissions",
                table: "Biousers");

            migrationBuilder.AddColumn<bool>(
                name: "AnalyticsPermission",
                table: "Biousers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ManagementPermission",
                table: "Biousers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RefactorPermission",
                table: "Biousers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RegisterPermission",
                table: "Biousers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VerifyPermission",
                table: "Biousers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnalyticsPermission",
                table: "Biousers");

            migrationBuilder.DropColumn(
                name: "ManagementPermission",
                table: "Biousers");

            migrationBuilder.DropColumn(
                name: "RefactorPermission",
                table: "Biousers");

            migrationBuilder.DropColumn(
                name: "RegisterPermission",
                table: "Biousers");

            migrationBuilder.DropColumn(
                name: "VerifyPermission",
                table: "Biousers");

            migrationBuilder.AddColumn<int>(
                name: "Permissions",
                table: "Biousers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
