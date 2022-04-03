using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuroraHRMPWA.Server.Migrations
{
    public partial class DataFamilyMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FamilyMembers",
                columns: new[] { "Id", "Age", "Gender", "Name", "Relation", "UserId" },
                values: new object[] { 2, 12, "Male", "Kareeem", 2, 29 });

            migrationBuilder.InsertData(
                table: "FamilyMembers",
                columns: new[] { "Id", "Age", "Gender", "Name", "Relation", "UserId" },
                values: new object[] { 3, 10, "Female", "Kareeem", 2, 31 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FamilyMembers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FamilyMembers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
