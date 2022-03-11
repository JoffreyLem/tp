using Microsoft.EntityFrameworkCore.Migrations;

namespace Tournaments.Migrations
{
    public partial class initialmigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipes_Tournaments_TournamentId",
                table: "Equipes");

            migrationBuilder.RenameColumn(
                name: "TournamentId",
                table: "Equipes",
                newName: "TournamentId1");

            migrationBuilder.RenameIndex(
                name: "IX_Equipes_TournamentId",
                table: "Equipes",
                newName: "IX_Equipes_TournamentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipes_Tournaments_TournamentId1",
                table: "Equipes",
                column: "TournamentId1",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipes_Tournaments_TournamentId1",
                table: "Equipes");

            migrationBuilder.RenameColumn(
                name: "TournamentId1",
                table: "Equipes",
                newName: "TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipes_TournamentId1",
                table: "Equipes",
                newName: "IX_Equipes_TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipes_Tournaments_TournamentId",
                table: "Equipes",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
