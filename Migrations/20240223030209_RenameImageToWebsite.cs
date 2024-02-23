using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CareFinder.API.Migrations
{
    /// <inheritdoc />
    public partial class RenameImageToWebsite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "049b95e3-d4e6-4126-b3bc-940219ff2ca2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d90c62b-5b65-4036-b4a3-8312cdc7fec4");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Hospitals",
                newName: "Website");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddressLine", "HospitalId", "PostalCode" },
                values: new object[] { "20A Thompson Ave, Ikoyi", 1, "106104" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddressLine", "HospitalId", "PostalCode", "State" },
                values: new object[] { "3/5 Adetola Ayeni St, off Freedom Way, Lekki Phase I", 2, "105102", "Lagos" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddressLine", "HospitalId", "PostalCode" },
                values: new object[] { "39 Isaac John str, GRA,Ikeja", 3, "106104" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5d2b820c-771d-4a36-8a49-b33be0589289", null, "Administrator", "ADMINISTRATOR" },
                    { "6156b272-e60b-4778-af48-2146df1f339c", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "About", "Email", "Name", "Ownership", "PhoneNumber", "Specialization", "Website" },
                values: new object[] { "FCC Healthcare is a comprehensive cardiovascular and preventative health care hospital that empowers patients in Nigeria with their health care needs. For over 10 years, we have been delivering the highest quality comprehensive care in Nigeria by innovative use of modern technology and a commitment to local capacity building, education, and collaborative research. We put the patient first, and we have built a healthy medical environment to provide patients with comprehensive care, and deliver excellence in healthcare every day, and not just on some days.", "info@firstcardiology.org", "First Cardiology Consultants", "Private", "08082114266", "Cardiology", "https://firstcardiology.org/" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "About", "Email", "Name", "Ownership", "PhoneNumber", "Specialization", "Website" },
                values: new object[] { "LECC is a multidisciplinary cardiovascular and cardiac rehabilitation 24/7 facility focused on the treatment and management of cardiovascular diseases and trigger diseases using both invasive and non-invasive procedures, as well as preventive cardiology. Our skilled and experienced cardiologists, vascular and cardiothoraxic surgeons, electrophysiologists, interventional cardiologists and support staff are committed to the treatment and prevention of heart diseases through innovative, state-of-the-art technology. Our support staff include stroke specialists, sleep specialists, endocrinologists (diabetes), nutritionists, physiotherapists, pulmonologists and respiratory physicians.", "admin@thelecc.com", "Lagos Executive Cardiovascular Centre", "Private", "08173651737", "Endocrinology & Diabetes", "https://thelecc.com/" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "About", "Email", "Name", "Ownership", "PhoneNumber", "Website" },
                values: new object[] { "Reddington is a 5-star, one-stop facility providing comprehensive solutions to your healthcare needs. The facility was set up as a tertiary centre with multiple specialties, committed to deliver excellent service in the medical field, with all departments supported by the latest technology and state-of-the-art medical equipment.", "info@reddingtonhospital.com", "Reddington Hospital", "Private", "09165359769", "https://reddingtonhospital.com/" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d2b820c-771d-4a36-8a49-b33be0589289");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6156b272-e60b-4778-af48-2146df1f339c");

            migrationBuilder.RenameColumn(
                name: "Website",
                table: "Hospitals",
                newName: "Image");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddressLine", "HospitalId", "PostalCode" },
                values: new object[] { "22, saliu street", 3, "1111" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddressLine", "HospitalId", "PostalCode", "State" },
                values: new object[] { "24, saliu street", 1, "1121", "Ogun" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddressLine", "HospitalId", "PostalCode" },
                values: new object[] { "26, saliu street", 2, "1111" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "049b95e3-d4e6-4126-b3bc-940219ff2ca2", null, "Administrator", "ADMINISTRATOR" },
                    { "4d90c62b-5b65-4036-b4a3-8312cdc7fec4", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "About", "Email", "Image", "Name", "Ownership", "PhoneNumber", "Specialization" },
                values: new object[] { "asw dd ee eee fff vvv", "aaa@kk.com", "ffff", "Unilorin Teaching Hospital", null, "12345", "General" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "About", "Email", "Image", "Name", "Ownership", "PhoneNumber", "Specialization" },
                values: new object[] { "asw dd ee eee fff vvv", "aaa@kk.com", "sssssss", "UniLag Teaching Hospital", null, "12345", "General" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "About", "Email", "Image", "Name", "Ownership", "PhoneNumber" },
                values: new object[] { "asw dd ee eee fff vvv", "aaa@kk.com", "sssssss", "UniAbuja Teaching Hospital", null, "12345" });
        }
    }
}
