using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MotoGP.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficialWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Riders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Riders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Riders_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Riders_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamSponsors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    SponsorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSponsors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamSponsors_Sponsors_SponsorId",
                        column: x => x.SponsorId,
                        principalTable: "Sponsors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamSponsors_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Albania" },
                    { 2, "Algeria" },
                    { 3, "Andorra" },
                    { 4, "Angola" },
                    { 5, "Antigua" },
                    { 6, "Argentina" },
                    { 7, "Armenia" },
                    { 8, "Australia" },
                    { 9, "Austria" },
                    { 10, "Azerbaijan" },
                    { 11, "Bahamas" },
                    { 12, "Bahrain" },
                    { 13, "Bangladesh" },
                    { 14, "Barbados" },
                    { 15, "Belgium" },
                    { 16, "Belize" },
                    { 17, "Benin" },
                    { 18, "Bhutan" },
                    { 19, "Bolivia" },
                    { 21, "Botswana" },
                    { 22, "Brazil" },
                    { 23, "Brunei" },
                    { 24, "Bulgaria" },
                    { 25, "Burkina" },
                    { 26, "Burma" },
                    { 27, "Burundi" },
                    { 28, "Cambodia" },
                    { 29, "Cameroon" },
                    { 30, "Canada" },
                    { 33, "Chad" },
                    { 34, "Chile" },
                    { 35, "China" },
                    { 36, "Colombia" },
                    { 37, "Comoros" },
                    { 38, "Congo" },
                    { 39, "Costa Rica" },
                    { 40, "Cote d'Ivoire" },
                    { 41, "Croatia" },
                    { 42, "Cuba" },
                    { 43, "Cyprus" },
                    { 44, "Czech Republic" },
                    { 45, "Denmark" },
                    { 46, "Djibouti" },
                    { 47, "Dominica" },
                    { 49, "Ecuador" },
                    { 50, "Egypt" },
                    { 51, "El Salvador" },
                    { 53, "Eritrea" },
                    { 54, "Estonia" },
                    { 55, "Ethiopia" },
                    { 56, "Fiji" },
                    { 57, "Finland" },
                    { 58, "France" },
                    { 59, "Gabon" },
                    { 60, "Gambia" },
                    { 61, "Georgia" },
                    { 62, "Germany" },
                    { 63, "Ghana" },
                    { 64, "Gibraltar" },
                    { 65, "Greece" },
                    { 66, "Grenada" },
                    { 67, "Guadeloupe" },
                    { 68, "Guatemala" },
                    { 69, "Guinea" },
                    { 70, "Guinea-Bissau" },
                    { 71, "Guyana" },
                    { 72, "Haiti" },
                    { 73, "Honduras" },
                    { 74, "Hong Kong" },
                    { 75, "Hungary" },
                    { 76, "Iceland" },
                    { 77, "India" },
                    { 78, "Indonesia" },
                    { 79, "Iran" },
                    { 80, "Iraq" },
                    { 81, "Irish Republic" },
                    { 82, "Israel" },
                    { 83, "Italy" },
                    { 84, "Jamaica" },
                    { 85, "Japan" },
                    { 86, "Jordan" },
                    { 87, "Kazakhstan" },
                    { 88, "Kenya" },
                    { 89, "Kirgizstan" },
                    { 90, "Kiribati" },
                    { 91, "Korea (North)" },
                    { 92, "Korea (South)" },
                    { 93, "Kuwait" },
                    { 94, "Laos" },
                    { 95, "Latvia" },
                    { 96, "Lebanon" },
                    { 97, "Lesotho" },
                    { 98, "Liberia" },
                    { 99, "Libya" },
                    { 100, "Liechtenstein" },
                    { 101, "Lithuania" },
                    { 102, "Luxembourg" },
                    { 103, "Macedonia" },
                    { 104, "Madagascar" },
                    { 105, "Malawi" },
                    { 106, "Malaysia" },
                    { 107, "Maldives" },
                    { 108, "Mali" },
                    { 109, "Malta" },
                    { 111, "Mauritania" },
                    { 112, "Mauritius" },
                    { 113, "Mexico" },
                    { 114, "Micronesia" },
                    { 115, "Moldova" },
                    { 116, "Monaco" },
                    { 117, "Mongolia" },
                    { 118, "Morocco" },
                    { 119, "Mozambique" },
                    { 120, "Namibia" },
                    { 121, "Nauru" },
                    { 122, "Nepal" },
                    { 123, "Netherlands" },
                    { 124, "New Zealand" },
                    { 125, "Nicaragua" },
                    { 126, "Niger" },
                    { 127, "Nigeria" },
                    { 128, "Norway" },
                    { 129, "Oman" },
                    { 130, "Pakistan" },
                    { 131, "Panama" },
                    { 132, "Papua New Guinea" },
                    { 133, "Paraguay" },
                    { 134, "Peru" },
                    { 135, "Philippines" },
                    { 136, "Poland" },
                    { 137, "Portugal" },
                    { 138, "Puerto Rico" },
                    { 139, "Qatar" },
                    { 140, "Romania" },
                    { 141, "Russia" },
                    { 142, "Rwanda" },
                    { 143, "Saint Kitts" },
                    { 144, "Saint Lucia" },
                    { 145, "Saint Vincent" },
                    { 146, "Samoa" },
                    { 147, "San Marino" },
                    { 149, "Saudi Arabia" },
                    { 150, "Senegal" },
                    { 151, "Seychelles" },
                    { 152, "Sierra Leone" },
                    { 153, "Singapore" },
                    { 154, "Slovakia" },
                    { 155, "Slovenia" },
                    { 156, "Solomon Islands" },
                    { 157, "Somalia" },
                    { 158, "South Africa" },
                    { 159, "Spain" },
                    { 160, "Sri Lanka" },
                    { 161, "Sudan" },
                    { 162, "Suriname" },
                    { 163, "Swaziland" },
                    { 164, "Sweden" },
                    { 165, "Switzerland" },
                    { 166, "Syria" },
                    { 167, "Tahiti" },
                    { 168, "Taiwan" },
                    { 169, "Tajikistan" },
                    { 170, "Tanzania" },
                    { 171, "Thailand" },
                    { 172, "Togo" },
                    { 173, "Tonga" },
                    { 175, "Tunisia" },
                    { 176, "Turkey" },
                    { 177, "Turkmenistan" },
                    { 178, "Tuvalu" },
                    { 179, "Uganda" },
                    { 180, "Ukraine" },
                    { 182, "United Kingdom" },
                    { 183, "United States" },
                    { 184, "Uruguay" },
                    { 185, "Uzbekistan" },
                    { 186, "Vanuatu" },
                    { 187, "Venezuela" },
                    { 188, "Vietnam" },
                    { 189, "White Russia" },
                    { 190, "Yemen" },
                    { 191, "Zaire" },
                    { 192, "Zambia" },
                    { 193, "Zimbabwe" }
                });

            migrationBuilder.InsertData(
                table: "Sponsors",
                columns: new[] { "Id", "Logo", "Name", "OfficialWebsite" },
                values: new object[,]
                {
                    { 1, "qatar.png", "Qatar Airways", "https://www.qatarairways.com/es-es/homepage.html" },
                    { 2, "bmw.png", "BMW", "https://www.bmw-m.com/en/fastlane/motogp.html" },
                    { 3, "tissot.png", "Tissot", "https://www.tissotwatches.com/" },
                    { 4, "estrella.png", "Estrella Galicia", "https://estrellagalicia00.es/" },
                    { 5, "michelin.png", "Michelin", "https://www.michelinmotorsport.com/en/motorsport/" },
                    { 6, "dhl.png", "DHL", "https://www.dhl.com/global-en/home/about-us/partnerships.html" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Logo", "Name" },
                values: new object[,]
                {
                    { 1, "Avintia.png", "Avintia Racing" },
                    { 2, "AB.png", "Cardion AB Motoracing" },
                    { 3, "Ducati.png", "Ducati Team" },
                    { 4, "LCR.png", "LCR Honda MotoGP" },
                    { 5, "Repsol.png", "Repsol Honda Team" },
                    { 6, "M7.png", "Drive M7 Aspar" },
                    { 7, "ioda.png", "IodaRacing Project" }
                });

            migrationBuilder.InsertData(
                table: "Riders",
                columns: new[] { "Id", "CountryId", "FirstName", "LastName", "Number", "TeamId" },
                values: new object[,]
                {
                    { 1, 159, "Hector", "Barbera", 8, 1 },
                    { 2, 58, "Mike", "Di Meglio", 63, 1 },
                    { 3, 44, "Karel", "Abraham", 17, 2 },
                    { 4, 85, "Hiroshi", "Aoyama", 7, 6 },
                    { 5, 183, "Niki", "Hayden", 69, 6 },
                    { 6, 83, "Andrea", "Dovizioso", 4, 3 },
                    { 7, 182, "Cal", "Crutchlow", 35, 3 },
                    { 8, 182, "Leon", "Camier", 2, 7 },
                    { 9, 83, "Danilo", "Petrucci", 9, 7 },
                    { 10, 62, "Stefan", "Bradl", 6, 4 },
                    { 11, 159, "Dani", "Pedrosa", 26, 5 },
                    { 12, 159, "Marc", "Marquez", 93, 5 }
                });

            migrationBuilder.InsertData(
                table: "TeamSponsors",
                columns: new[] { "Id", "SponsorId", "TeamId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 3, 1 },
                    { 3, 4, 1 },
                    { 4, 5, 1 },
                    { 5, 6, 5 },
                    { 6, 1, 2 },
                    { 7, 3, 2 },
                    { 8, 4, 2 },
                    { 9, 5, 2 },
                    { 10, 6, 6 },
                    { 11, 1, 3 },
                    { 12, 2, 3 },
                    { 13, 4, 3 },
                    { 14, 5, 3 },
                    { 15, 6, 7 },
                    { 16, 1, 4 },
                    { 17, 2, 4 },
                    { 18, 3, 4 },
                    { 19, 5, 7 },
                    { 20, 6, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Riders_CountryId",
                table: "Riders",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Riders_TeamId",
                table: "Riders",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSponsors_SponsorId",
                table: "TeamSponsors",
                column: "SponsorId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSponsors_TeamId",
                table: "TeamSponsors",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Riders");

            migrationBuilder.DropTable(
                name: "TeamSponsors");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Sponsors");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
