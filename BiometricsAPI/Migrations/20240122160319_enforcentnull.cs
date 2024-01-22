using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiometricsAPI.Migrations
{
    /// <inheritdoc />
    public partial class enforcentnull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biodata");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AuditLogs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AuditLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Biodata",
                columns: table => new
                {
                    Arrears = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClassId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fingerprint1 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Fingerprint2 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
