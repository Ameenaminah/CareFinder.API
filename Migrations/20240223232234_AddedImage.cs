using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CareFinder.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41e1e3e5-82cd-4934-9ddf-a706592cb3a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a0ab47d-cf94-4842-bbfe-0bf7abe2a4bb");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Hospitals",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11103725-0c3a-4aad-8718-a6766b21ac18", null, "Administrator", "ADMINISTRATOR" },
                    { "a0a5f676-c770-4ef3-8225-e2b83e60aed6", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11103725-0c3a-4aad-8718-a6766b21ac18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0a5f676-c770-4ef3-8225-e2b83e60aed6");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Hospitals");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41e1e3e5-82cd-4934-9ddf-a706592cb3a0", null, "User", "USER" },
                    { "9a0ab47d-cf94-4842-bbfe-0bf7abe2a4bb", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
