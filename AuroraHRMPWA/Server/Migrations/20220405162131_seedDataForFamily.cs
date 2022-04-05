using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuroraHRMPWA.Server.Migrations
{
    public partial class seedDataForFamily : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FamilyMembers",
                columns: new[] { "Id", "Age", "Gender", "Name", "Relation", "UserId" },
                values: new object[] { 4, 5, "Male", "jacky", 2, 29 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FamilyMembers",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
