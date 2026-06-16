using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PowerliftMeet.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedClubs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0003-000000000001"), "GE", "C.H. Châtelaine Section haltérophilie" },
                    { new Guid("00000000-0000-0000-0003-000000000002"), "GE", "Geneva Powerlifting" },
                    { new Guid("00000000-0000-0000-0003-000000000003"), "GL", "Powerlifting Verein Cross Arena Glarnerland" },
                    { new Guid("00000000-0000-0000-0003-000000000004"), "GR", "Barbell Club Landquart" },
                    { new Guid("00000000-0000-0000-0003-000000000005"), "LU", "Elemental Athletes" },
                    { new Guid("00000000-0000-0000-0003-000000000006"), "SO", "Schwerathletik Nordwest" },
                    { new Guid("00000000-0000-0000-0003-000000000007"), "VD", "CLHM Club lausannois d'haltérophilie et de musculation" },
                    { new Guid("00000000-0000-0000-0003-000000000008"), "ZG", "Powerlifting Zug" },
                    { new Guid("00000000-0000-0000-0003-000000000009"), "ZH", "Crossfort Kraftsport" },
                    { new Guid("00000000-0000-0000-0003-000000000010"), "ZH", "Kraftdreikampf Klub der Sportfreunde" },
                    { new Guid("00000000-0000-0000-0003-000000000011"), "ZH", "Outcast Strength System" },
                    { new Guid("00000000-0000-0000-0003-000000000012"), "TG", "Powerlifting Nordostschweiz" },
                    { new Guid("00000000-0000-0000-0003-000000000013"), "VD", "Barbarian Barbell Club" },
                    { new Guid("00000000-0000-0000-0003-000000000014"), "BE", "Bienna Powerlifting" },
                    { new Guid("00000000-0000-0000-0003-000000000015"), "ZH", "One Rep Strength" },
                    { new Guid("00000000-0000-0000-0003-000000000016"), "NE", "Neuchâtel Force" },
                    { new Guid("00000000-0000-0000-0003-000000000017"), "BE", "Beo Barbell Club" },
                    { new Guid("00000000-0000-0000-0003-000000000018"), "VD", "Powerlifting Lausanne" },
                    { new Guid("00000000-0000-0000-0003-000000000019"), "VD", "Atlas Gym" },
                    { new Guid("00000000-0000-0000-0003-000000000020"), "ZH", "Powerlifting Winti" },
                    { new Guid("00000000-0000-0000-0003-000000000021"), "FR", "Nordic Barbell Club" },
                    { new Guid("00000000-0000-0000-0003-000000000022"), "VD", "Ultima Club" },
                    { new Guid("00000000-0000-0000-0003-000000000023"), "BL", "Kraftdreikampfverein Basilea" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000002"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000003"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000004"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000005"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000006"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000007"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000008"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000009"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000010"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000011"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000012"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000013"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000014"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000015"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000016"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000017"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000018"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000019"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000020"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000021"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000022"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000023"));
        }
    }
}
