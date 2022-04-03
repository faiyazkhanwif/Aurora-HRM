using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuroraHRMPWA.Server.Migrations
{
    public partial class Qualifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualificationName = table.Column<int>(type: "int", nullable: false),
                    InstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionStatus = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Qualifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "CompletionStatus", "EndDate", "InstitutionName", "Major", "QualificationName", "Result", "StartDate", "UserId" },
                values: new object[] { 1, 0, new DateTime(2022, 4, 3, 16, 3, 10, 827, DateTimeKind.Local).AddTicks(9680), "University of Malaya", "Computer Science", 1, "3.62", new DateTime(2022, 4, 3, 16, 3, 10, 827, DateTimeKind.Local).AddTicks(9672), 29 });

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_UserId",
                table: "Qualifications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.InsertData(
                table: "EmployeeExperiences",
                columns: new[] { "Id", "CompanyName", "Position", "Salary", "UserId", "YearsServed" },
                values: new object[,]
                {
                    { 1, "Edwards", "Senior Software Engineer", 5000m, 29, 4 },
                    { 2, "Seesharp Solutions", "Junior Engineer", 3000m, 31, 2 },
                    { 3, "Averis", "HR Executive", 2800m, 37, 3 },
                    { 4, "TNG", "HR Executive", 4200m, 43, 3 }
                });
        }
    }
}
