using Microsoft.EntityFrameworkCore.Migrations;

namespace APIBook.Migrations
{
    public partial class AddRolesToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b1082f3d-a018-476e-84ea-327d10f5715d", "10ec0929-5c20-4e84-bb1b-c0351db70a3b", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "682585ad-6608-4616-beab-ffe773ea746f", "f60e7cef-8c0d-45a2-8251-20089be41451", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "682585ad-6608-4616-beab-ffe773ea746f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1082f3d-a018-476e-84ea-327d10f5715d");
        }
    }
}
