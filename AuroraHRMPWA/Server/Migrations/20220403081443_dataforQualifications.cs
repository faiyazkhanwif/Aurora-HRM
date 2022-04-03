using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuroraHRMPWA.Server.Migrations
{
    public partial class dataforQualifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 4, 3, 16, 14, 42, 784, DateTimeKind.Local).AddTicks(638), new DateTime(2022, 4, 3, 16, 14, 42, 784, DateTimeKind.Local).AddTicks(628) });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "CompletionStatus", "EndDate", "InstitutionName", "Major", "QualificationName", "Result", "StartDate", "UserId" },
                values: new object[] { 2, 0, new DateTime(2022, 4, 3, 16, 14, 42, 784, DateTimeKind.Local).AddTicks(640), "University of Malaya", "Computer Science", 0, "3.82", new DateTime(2022, 4, 3, 16, 14, 42, 784, DateTimeKind.Local).AddTicks(640), 31 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 4, 3, 16, 3, 10, 827, DateTimeKind.Local).AddTicks(9680), new DateTime(2022, 4, 3, 16, 3, 10, 827, DateTimeKind.Local).AddTicks(9672) });
        }
    }
}
