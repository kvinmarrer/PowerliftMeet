using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PowerliftMeet.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedWeightClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WeightClasses",
                columns: new[] { "Id", "Weight" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0001-000000000001"), 59 },
                    { new Guid("00000000-0000-0000-0001-000000000002"), 66 },
                    { new Guid("00000000-0000-0000-0001-000000000003"), 74 },
                    { new Guid("00000000-0000-0000-0001-000000000004"), 83 },
                    { new Guid("00000000-0000-0000-0001-000000000005"), 93 },
                    { new Guid("00000000-0000-0000-0001-000000000006"), 105 },
                    { new Guid("00000000-0000-0000-0001-000000000007"), 120 },
                    { new Guid("00000000-0000-0000-0002-000000000001"), 47 },
                    { new Guid("00000000-0000-0000-0002-000000000002"), 52 },
                    { new Guid("00000000-0000-0000-0002-000000000003"), 57 },
                    { new Guid("00000000-0000-0000-0002-000000000004"), 63 },
                    { new Guid("00000000-0000-0000-0002-000000000005"), 69 },
                    { new Guid("00000000-0000-0000-0002-000000000006"), 76 },
                    { new Guid("00000000-0000-0000-0002-000000000007"), 84 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000006"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000007"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000001"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000002"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000003"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000004"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000005"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000006"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000007"));
        }
    }
}
