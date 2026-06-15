using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowerliftMeet.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFederationToClub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Athletes_Federations_FederationId",
                table: "Athletes");

            migrationBuilder.DropTable(
                name: "Federations");

            migrationBuilder.RenameColumn(
                name: "FederationId",
                table: "Athletes",
                newName: "ClubId");

            migrationBuilder.RenameIndex(
                name: "IX_Athletes_FederationId",
                table: "Athletes",
                newName: "IX_Athletes_ClubId");

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Athletes_Clubs_ClubId",
                table: "Athletes",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Athletes_Clubs_ClubId",
                table: "Athletes");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.RenameColumn(
                name: "ClubId",
                table: "Athletes",
                newName: "FederationId");

            migrationBuilder.RenameIndex(
                name: "IX_Athletes_ClubId",
                table: "Athletes",
                newName: "IX_Athletes_FederationId");

            migrationBuilder.CreateTable(
                name: "Federations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Federations", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Athletes_Federations_FederationId",
                table: "Athletes",
                column: "FederationId",
                principalTable: "Federations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
