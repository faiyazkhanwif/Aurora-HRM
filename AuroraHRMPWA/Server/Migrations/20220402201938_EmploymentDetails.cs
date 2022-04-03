using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuroraHRMPWA.Server.Migrations
{
    public partial class EmploymentDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmploymentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfHiring = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoticePeriod = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmploymentDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EmploymentDetails",
                columns: new[] { "Id", "BaseSalary", "DateOfHiring", "Department", "NoticePeriod", "Position", "UserId" },
                values: new object[,]
                {
                    { 1, 6500m, new DateTime(2022, 4, 3, 4, 19, 38, 482, DateTimeKind.Local).AddTicks(4029), "Engineering", 6, "Engineering lead", 29 },
                    { 2, 3500m, new DateTime(2022, 4, 3, 4, 19, 38, 482, DateTimeKind.Local).AddTicks(4043), "Engineering", 6, "Software Engineer", 31 },
                    { 3, 3100m, new DateTime(2022, 4, 3, 4, 19, 38, 482, DateTimeKind.Local).AddTicks(4044), "Human Resource", 6, "HR Executive", 37 },
                    { 4, 5100m, new DateTime(2022, 4, 3, 4, 19, 38, 482, DateTimeKind.Local).AddTicks(4046), "Human Resource", 6, "HR Manager", 43 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentDetails_UserId",
                table: "EmploymentDetails",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmploymentDetails");
        }
    }
}
