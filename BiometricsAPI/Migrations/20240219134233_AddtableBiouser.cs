using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiometricsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddtableBiouser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Biometrics",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrears = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Fingerprint1 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Fingerprint2 = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biometrics", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Biousers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permissions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biousers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Register",
                columns: table => new
                {
                    AdmnNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    names = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrears = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biousers_Pin",
                table: "Biousers",
                column: "Pin",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Biousers_UserId",
                table: "Biousers",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Biometrics");

            migrationBuilder.DropTable(
                name: "Biousers");

            migrationBuilder.DropTable(
                name: "Register");
        }
    }
}
