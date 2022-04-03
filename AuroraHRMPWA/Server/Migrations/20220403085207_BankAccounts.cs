using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuroraHRMPWA.Server.Migrations
{
    public partial class BankAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "Id", "AccountNumber", "AccountType", "BankName", "Currency", "UserId" },
                values: new object[] { 1, "6863298442", 0, "CIMB", 0, 29 });

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "Id", "AccountNumber", "AccountType", "BankName", "Currency", "UserId" },
                values: new object[] { 2, "2867318763", 1, "Maybank", 0, 31 });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_UserId",
                table: "BankAccounts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "CompletionStatus", "EndDate", "InstitutionName", "Major", "QualificationName", "Result", "StartDate", "UserId" },
                values: new object[] { 1, 0, new DateTime(2022, 4, 3, 16, 14, 42, 784, DateTimeKind.Local).AddTicks(638), "University of Malaya", "Computer Science", 1, "3.62", new DateTime(2022, 4, 3, 16, 14, 42, 784, DateTimeKind.Local).AddTicks(628), 29 });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "CompletionStatus", "EndDate", "InstitutionName", "Major", "QualificationName", "Result", "StartDate", "UserId" },
                values: new object[] { 2, 0, new DateTime(2022, 4, 3, 16, 14, 42, 784, DateTimeKind.Local).AddTicks(640), "University of Malaya", "Computer Science", 0, "3.82", new DateTime(2022, 4, 3, 16, 14, 42, 784, DateTimeKind.Local).AddTicks(640), 31 });
        }
    }
}
