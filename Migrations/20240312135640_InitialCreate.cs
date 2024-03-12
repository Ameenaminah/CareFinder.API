using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CareFinder.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ownership = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HospitalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ad64030-e53d-46bd-9ee1-8859d9f55828", null, "User", "USER" },
                    { "13de9ccc-aede-438d-87bc-b3b206766565", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "About", "Email", "Image", "Name", "Ownership", "PhoneNumber", "Specialization", "Website" },
                values: new object[,]
                {
                    { 1, "FCC Healthcare is a comprehensive cardiovascular and preventative health care hospital that empowers patients in Nigeria with their health care needs. For over 10 years, we have been delivering the highest quality comprehensive care in Nigeria by innovative use of modern technology and a commitment to local capacity building, education, and collaborative research. We put the patient first, and we have built a healthy medical environment to provide patients with comprehensive care, and deliver excellence in healthcare every day, and not just on some days.", "info@firstcardiology.org", null, "First Cardiology Consultants", "Private", "08082114266", "Cardiology", "https://firstcardiology.org/" },
                    { 2, "LECC is a multidisciplinary cardiovascular and cardiac rehabilitation 24/7 facility focused on the treatment and management of cardiovascular diseases and trigger diseases using both invasive and non-invasive procedures, as well as preventive cardiology. Our skilled and experienced cardiologists, vascular and cardiothoraxic surgeons, electrophysiologists, interventional cardiologists and support staff are committed to the treatment and prevention of heart diseases through innovative, state-of-the-art technology. Our support staff include stroke specialists, sleep specialists, endocrinologists (diabetes), nutritionists, physiotherapists, pulmonologists and respiratory physicians.", "admin@thelecc.com", null, "Lagos Executive Cardiovascular Centre", "Private", "08173651737", "Endocrinology", "https://thelecc.com/" },
                    { 3, "Reddington is a 5-star, one-stop facility providing comprehensive solutions to your healthcare needs. The facility was set up as a tertiary centre with multiple specialties, committed to deliver excellent service in the medical field, with all departments supported by the latest technology and state-of-the-art medical equipment.", "info@reddingtonhospital.com", null, "Reddington Hospital", "Private", "09165359769", "General", "https://reddingtonhospital.com/" },
                    { 4, "The Lagos University Teaching Hospital today is a foremost tertiary hospital with a mandate to provide excellent services of international standard in patient care, training & research", "info@luth.gov.ng", null, "Lagos University Teaching Hospital (LUTH)", "Public", "+2348128364824", "General", "https://luth.gov.ng/" },
                    { 5, "St. Nicholas Hospital is a private hospital located in Lagos Island in Lagos, Nigeria. It was founded in 1968 by Moses Majekodunmi. The hospital is in a building of the same name located at 57 Campbell Street near Catholic Mission Street. It has other facilities at different locations in Nigeria. Their other locations are: St. Nicholas Hospital, Maryland, St. Nicholas Clinics, Lekki Free Trade Zone, St. Nicholas Clinics, 7b Etim Inyang Street, Victoria Island.", "info@saintnicholashospital.com", null, "St. Nicholas Hospital", "Private", "+2348035251295", "General", "https://saintnicholashospital.com/" },
                    { 6, "The Premier Specialists’ Medical Centre is the manifestation of a dream to promote the highest possible complete health care service, attainable in the most developed parts of the world, in Nigeria. Premier, as the name implies, means the first among all. We are a specialist hospital whose aim is to serve the healthcare needs of our community by providing quality and  comprehensive health care with the application of modern technology.", "info@thepremiermedical.com", null, "The Premier Specialists' Medical Centre", "Private", "08143914895", "General", "https://thepremiermedical.com/" },
                    { 7, "We are a mother and child friendly, medical and surgical private hospital registered with both Corporate Affairs Commission and Lagos State Private Hospital Registration Authority. We have also been appointed as participating Health Care Service Provider in the National Health Insurance Scheme(CODE LA / 1204 / P) with over Eighteen(18) Health Maintenance Organisation(HMO) registered with us and Nigeria Maritime Administration and Safety Agency(NIMASA).", "info@bestcarehospitalng.com", null, "Best Care Hospital", "Private", " 09013617520", "Gynecology", "https://www.bestcarehospitalng.com/" },
                    { 8, "Lagoon Hospital was founded in 1986 with its flagship situated at Apapa. Joint Commission International is the world’s leader in healthcare accreditation and the author and evaluator of the most rigorous international standards in quality and patient safety. For consecutive periods, Lagoon Hospitals has earned the Gold Seal of Approval from JCI by demonstrating continuous compliance with international best practices.The feat is a symbol of quality and reflects an organization’s commitment to providing safe and effective patient care. The JCI accreditation provides hospitals with the capacity to improve in various areas particularly with regards to staff education and development to core safety standards.", "livemorelife@lagoonhospitals.com", null, "Iwosan Lagoon Hospitals", "Private", " +2347080609000", "General", "https://www.lagoonhospitals.com/" },
                    { 9, "Atlantic Memorial Hospital Etta - Atlantic Memorial Hospital Lekki Lagos was established with the goal of providing an international level of health care for all Nigerians. Etta - Atlantic Memorial Hospital was established by physicians with training in the US, they have teamed up with bright and dedicated Nigerian physicians and other allied health professionals to provide excellent care based on standards set by the World Health Organization(WHO).", "hello@ettaatlantic.com", null, "Etta Atlantic Memorial Hospital", "Private", "+234(0)8083734008", "General", "https://www.ettaatlantic.com/" },
                    { 10, "Atlantic Memorial Hospital Etta - Atlantic Memorial Hospital Lekki Lagos was established with the goal of providing an international level of health care for all Nigerians. Etta - Atlantic Memorial Hospital was established by physicians with training in the US, they have teamed up with bright and dedicated Nigerian physicians and other allied health professionals to provide excellent care based on standards set by the World Health Organization(WHO).", "admin@genesishospitalng.com", null, "Genesis Specialist Hospital", "Private", "+2348027340743", "General", "https://genesishospitalng.com/" },
                    { 11, "We are passionate about the healthcare we provide, which is centred around maternal and fetal wellbeing, Obstetric and gynaecological cases. Our aim is to provide our patients with the best possible healthcare service, also as we continually look to improve on our service delivery. Caring for the whole woman", "info@princessmaryspecialisthospital.com", null, "Princess Mary Specialist Hospital", "Private", "08064063393", "Others", "https://www.google.com/maps/place/Princess+Mary+Specialist+Hospital/@5.1240079,7.3938909,17z/data=!3m1!4b1!4m6!3m5!1s0x1042991e2e740205:0x92fc9395cbb85871!8m2!3d5.1240079!4d7.3938909!16s%2Fg%2F11c2k36p3v?entry=ttu" },
                    { 12, "Living Word Mission Hospital (LWMH) is a mission established health care institution providing excellent services, quality patient â€“ friendly medical treatments to outright patients.", "info@livingwordweachinghospital.com", null, "Living Word Teaching Hospital", "Private", "08062831218", "Others", "https://www.google.com/maps/place/Living+Word+Teaching+Hospital/@5.1376132,7.3499621,17z/data=!3m1!4b1!4m6!3m5!1s0x10429bd5db969fc1:0xe7ca643d4f43fec8!8m2!3d5.1376132!4d7.3499621!16s%2Fg%2F11c5dl6bzv?entry=ttu" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine", "HospitalId", "PostalCode", "State" },
                values: new object[,]
                {
                    { 1, "20A Thompson Ave, Ikoyi", 1, "106104", "Lagos" },
                    { 2, "3/5 Adetola Ayeni St, off Freedom Way, Lekki Phase I", 2, "105102", "Lagos" },
                    { 3, "39 Isaac John str, GRA,Ikeja", 3, "106104", "Lagos" },
                    { 4, "Ishaga Rd,Idi-Araba", 4, "102215", "Lagos" },
                    { 5, "57 Campbell St, Lagos Island", 5, "101001", "Lagos" },
                    { 6, "7 Ogalade Close off Ologun Agbaje Street, Victoria Island", 6, "101001", "Lagos" },
                    { 7, "2A Keffi Street, By Toyan St", 7, "101233", "Lagos" },
                    { 8, "17B Bourdillon Rd, Ikoyi", 8, "106104", "Lagos" },
                    { 9, "22 Abioro St, Ikate, Lekki", 9, "106104", "Lagos" },
                    { 10, "67 Oduduwa Cres, Ikeja GRA, Ikeja", 10, "101233", "Lagos" },
                    { 11, "45 New Umuahia Rd, Umu Okahia, Aba", 11, "453106", "Abia" },
                    { 12, "7 Ogalade Close off Ologun Agbaje Street, Victoria Island", 12, "101001", "Lagos" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_HospitalId",
                table: "Addresses",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
