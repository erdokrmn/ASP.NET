using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeProjesi.Migrations
{
    /// <inheritdoc />
    public partial class mig11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GemiEnvanterleri_Gemiler_GemiAdıId",
                table: "GemiEnvanterleri");

            migrationBuilder.RenameColumn(
                name: "GemiAdıId",
                table: "GemiEnvanterleri",
                newName: "GemiId");

            migrationBuilder.RenameIndex(
                name: "IX_GemiEnvanterleri_GemiAdıId",
                table: "GemiEnvanterleri",
                newName: "IX_GemiEnvanterleri_GemiId");

            migrationBuilder.AddForeignKey(
                name: "FK_GemiEnvanterleri_Gemiler_GemiId",
                table: "GemiEnvanterleri",
                column: "GemiId",
                principalTable: "Gemiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GemiEnvanterleri_Gemiler_GemiId",
                table: "GemiEnvanterleri");

            migrationBuilder.RenameColumn(
                name: "GemiId",
                table: "GemiEnvanterleri",
                newName: "GemiAdıId");

            migrationBuilder.RenameIndex(
                name: "IX_GemiEnvanterleri_GemiId",
                table: "GemiEnvanterleri",
                newName: "IX_GemiEnvanterleri_GemiAdıId");

            migrationBuilder.AddForeignKey(
                name: "FK_GemiEnvanterleri_Gemiler_GemiAdıId",
                table: "GemiEnvanterleri",
                column: "GemiAdıId",
                principalTable: "Gemiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
