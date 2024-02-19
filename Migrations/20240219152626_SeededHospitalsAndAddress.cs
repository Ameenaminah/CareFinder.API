using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CareFinder.API.Migrations
{
    /// <inheritdoc />
    public partial class SeededHospitalsAndAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "About", "Email", "Image", "Name", "Ownership", "PhoneNumber", "Specialization" },
                values: new object[,]
                {
                    { 1, "asw dd ee eee fff vvv", "aaa@kk.com", "ffff", "Unilorin Teaching Hospital", null, "12345", "General" },
                    { 2, "asw dd ee eee fff vvv", "aaa@kk.com", "sssssss", "UniLag Teaching Hospital", null, "12345", "General" },
                    { 3, "asw dd ee eee fff vvv", "aaa@kk.com", "sssssss", "UniAbuja Teaching Hospital", null, "12345", "General" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine", "HospitalId", "PostalCode", "State" },
                values: new object[,]
                {
                    { 1, "22, saliu street", 3, "1111", "Lagos" },
                    { 2, "24, saliu street", 1, "1121", "Ogun" },
                    { 3, "26, saliu street", 2, "1111", "Lagos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
