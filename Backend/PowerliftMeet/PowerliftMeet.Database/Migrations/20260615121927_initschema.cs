using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowerliftMeet.Database.Migrations
{
    /// <inheritdoc />
    public partial class initschema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Athletes_WeightClasses_WeightClassId",
                table: "Athletes");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Athletes");

            migrationBuilder.RenameColumn(
                name: "WeightClassId",
                table: "Athletes",
                newName: "GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Athletes_WeightClassId",
                table: "Athletes",
                newName: "IX_Athletes_GenderId");

            migrationBuilder.AddColumn<Guid>(
                name: "GenderId",
                table: "WeightClasses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MeetId = table.Column<Guid>(type: "uuid", nullable: false),
                    FlightNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Meets_MeetId",
                        column: x => x.MeetId,
                        principalTable: "Meets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeetAthletes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WeightClassId = table.Column<Guid>(type: "uuid", nullable: false),
                    MeetId = table.Column<Guid>(type: "uuid", nullable: false),
                    AthleteId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetAthletes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetAthletes_Athletes_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "Athletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetAthletes_Meets_MeetId",
                        column: x => x.MeetId,
                        principalTable: "Meets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetAthletes_WeightClasses_WeightClassId",
                        column: x => x.WeightClassId,
                        principalTable: "WeightClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LiftCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MeetAthleteId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiftCards_MeetAthletes_MeetAthleteId",
                        column: x => x.MeetAthleteId,
                        principalTable: "MeetAthletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attempts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LiftCardId = table.Column<Guid>(type: "uuid", nullable: false),
                    LiftType = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    Result = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attempts_LiftCards_LiftCardId",
                        column: x => x.LiftCardId,
                        principalTable: "LiftCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeightClasses_GenderId",
                table: "WeightClasses",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Attempts_LiftCardId",
                table: "Attempts",
                column: "LiftCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_MeetId",
                table: "Flights",
                column: "MeetId");

            migrationBuilder.CreateIndex(
                name: "IX_LiftCards_MeetAthleteId",
                table: "LiftCards",
                column: "MeetAthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetAthletes_AthleteId",
                table: "MeetAthletes",
                column: "AthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetAthletes_MeetId",
                table: "MeetAthletes",
                column: "MeetId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetAthletes_WeightClassId",
                table: "MeetAthletes",
                column: "WeightClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Athletes_Genders_GenderId",
                table: "Athletes",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeightClasses_Genders_GenderId",
                table: "WeightClasses",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Athletes_Genders_GenderId",
                table: "Athletes");

            migrationBuilder.DropForeignKey(
                name: "FK_WeightClasses_Genders_GenderId",
                table: "WeightClasses");

            migrationBuilder.DropTable(
                name: "Attempts");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "LiftCards");

            migrationBuilder.DropTable(
                name: "MeetAthletes");

            migrationBuilder.DropIndex(
                name: "IX_WeightClasses_GenderId",
                table: "WeightClasses");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "WeightClasses");

            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "Athletes",
                newName: "WeightClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Athletes_GenderId",
                table: "Athletes",
                newName: "IX_Athletes_WeightClassId");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Athletes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Athletes_WeightClasses_WeightClassId",
                table: "Athletes",
                column: "WeightClassId",
                principalTable: "WeightClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
