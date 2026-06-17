using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PowerliftMeet.Database.Migrations
{
    /// <inheritdoc />
    public partial class seedWeightClassGender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "IsMen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "IsMen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "IsMen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "IsMen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "IsMen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000006"),
                column: "IsMen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000007"),
                column: "IsMen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000001"),
                column: "IsWomen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000002"),
                column: "IsWomen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000003"),
                column: "IsWomen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000004"),
                column: "IsWomen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000005"),
                column: "IsWomen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000006"),
                column: "IsWomen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000007"),
                column: "IsWomen",
                value: true);

            migrationBuilder.InsertData(
                table: "WeightClasses",
                columns: new[] { "Id", "IsMen", "IsOther", "IsWomen", "Weight" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0003-000000000001"), false, true, false, 59 },
                    { new Guid("00000000-0000-0000-0003-000000000002"), false, true, false, 66 },
                    { new Guid("00000000-0000-0000-0003-000000000003"), false, true, false, 74 },
                    { new Guid("00000000-0000-0000-0003-000000000004"), false, true, false, 83 },
                    { new Guid("00000000-0000-0000-0003-000000000005"), false, true, false, 93 },
                    { new Guid("00000000-0000-0000-0003-000000000006"), false, true, false, 105 },
                    { new Guid("00000000-0000-0000-0003-000000000007"), false, true, false, 120 },
                    { new Guid("00000000-0000-0000-0003-000000000008"), false, true, false, 47 },
                    { new Guid("00000000-0000-0000-0003-000000000009"), false, true, false, 52 },
                    { new Guid("00000000-0000-0000-0003-000000000010"), false, true, false, 57 },
                    { new Guid("00000000-0000-0000-0003-000000000011"), false, true, false, 63 },
                    { new Guid("00000000-0000-0000-0003-000000000012"), false, true, false, 69 },
                    { new Guid("00000000-0000-0000-0003-000000000013"), false, true, false, 76 },
                    { new Guid("00000000-0000-0000-0003-000000000014"), false, true, false, 84 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000002"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000003"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000004"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000005"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000006"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000007"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000008"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000009"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000010"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000011"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000012"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000013"));

            migrationBuilder.DeleteData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000014"));

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "IsMen",
                value: false);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "IsMen",
                value: false);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "IsMen",
                value: false);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "IsMen",
                value: false);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "IsMen",
                value: false);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000006"),
                column: "IsMen",
                value: false);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000007"),
                column: "IsMen",
                value: false);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000001"),
                column: "IsWomen",
                value: false);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000002"),
                column: "IsWomen",
                value: false);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000003"),
                column: "IsWomen",
                value: false);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000004"),
                column: "IsWomen",
                value: false);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000005"),
                column: "IsWomen",
                value: false);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000006"),
                column: "IsWomen",
                value: false);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000007"),
                column: "IsWomen",
                value: false);
        }
    }
}
