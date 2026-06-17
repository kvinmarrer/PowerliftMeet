using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowerliftMeet.Database.Migrations
{
    /// <inheritdoc />
    public partial class weightClassGender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMen",
                table: "WeightClasses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOther",
                table: "WeightClasses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWomen",
                table: "WeightClasses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                columns: new[] { "IsMen", "IsOther", "IsWomen" },
                values: new object[] { false, false, false });

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                columns: new[] { "IsMen", "IsOther", "IsWomen" },
                values: new object[] { false, false, false });

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                columns: new[] { "IsMen", "IsOther", "IsWomen" },
                values: new object[] { false, false, false });

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                columns: new[] { "IsMen", "IsOther", "IsWomen" },
                values: new object[] { false, false, false });

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                columns: new[] { "IsMen", "IsOther", "IsWomen" },
                values: new object[] { false, false, false });

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000006"),
                columns: new[] { "IsMen", "IsOther", "IsWomen" },
                values: new object[] { false, false, false });

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000007"),
                columns: new[] { "IsMen", "IsOther", "IsWomen" },
                values: new object[] { false, false, false });

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000001"),
                columns: new[] { "IsMen", "IsOther", "IsWomen" },
                values: new object[] { false, false, false });

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000002"),
                columns: new[] { "IsMen", "IsOther", "IsWomen" },
                values: new object[] { false, false, false });

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000003"),
                columns: new[] { "IsMen", "IsOther", "IsWomen" },
                values: new object[] { false, false, false });

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000004"),
                columns: new[] { "IsMen", "IsOther", "IsWomen" },
                values: new object[] { false, false, false });

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000005"),
                columns: new[] { "IsMen", "IsOther", "IsWomen" },
                values: new object[] { false, false, false });

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000006"),
                columns: new[] { "IsMen", "IsOther", "IsWomen" },
                values: new object[] { false, false, false });

            migrationBuilder.UpdateData(
                table: "WeightClasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000007"),
                columns: new[] { "IsMen", "IsOther", "IsWomen" },
                values: new object[] { false, false, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMen",
                table: "WeightClasses");

            migrationBuilder.DropColumn(
                name: "IsOther",
                table: "WeightClasses");

            migrationBuilder.DropColumn(
                name: "IsWomen",
                table: "WeightClasses");
        }
    }
}
