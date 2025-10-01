using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoGP.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRaceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvgSpeed", "LapCount", "LapTime" },
                values: new object[] { 162.34, 27, 98.56 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvgSpeed", "LapCount", "LapTime" },
                values: new object[] { 158.12, 30, 102.74 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvgSpeed", "LapCount", "LapTime" },
                values: new object[] { 166.45, 25, 94.31 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvgSpeed", "LapCount", "LapTime" },
                values: new object[] { 154.76, 30, 105.22 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvgSpeed", "LapCount", "LapTime" },
                values: new object[] { 161.23, 27, 99.85 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AvgSpeed", "LapCount", "LapTime" },
                values: new object[] { 159.88, 27, 101.12 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AvgSpeed", "LapCount", "LapTime" },
                values: new object[] { 163.57, 25, 97.45 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AvgSpeed", "LapCount", "LapTime" },
                values: new object[] { 157.99, 31, 103.67 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AvgSpeed", "LapCount", "LapTime" },
                values: new object[] { 164.21, 26, 96.78 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AvgSpeed", "LapCount", "LapTime" },
                values: new object[] { 160.45, 28, 100.54 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AvgSpeed", "LapCount", "LapTime" },
                values: new object[] { 167.89, 22, 92.34 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AvgSpeed", "LapCount", "LapTime" },
                values: new object[] { 155.34, 32, 104.88 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AvgSpeed", "LapCount", "LapTime" },
                values: new object[] { 162.11, 27, 99.98 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AvgSpeed", "LapCount", "LapTime" },
                values: new object[] { 158.67, 30, 101.90 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AvgSpeed", "LapCount", "LapTime" },
                values: new object[] { 165.78, 24, 95.67 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AvgSpeed", "LapCount", "LapTime" },
                values: new object[] { 156.45, 31, 103.34 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AvgSpeed", "LapCount", "LapTime" },
                values: new object[] { 161.89, 26, 100.21 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AvgSpeed", "LapCount", "LapTime" },
                values: new object[] { 159.34, 27, 101.76 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AvgSpeed", "LapCount", "LapTime" },
                values: new object[] { 163.99, 23, 97.12 });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE Races SET AvgSpeed = 0.0, LapTime = 0.0, LapCount = 0;");
        }
    }
}
