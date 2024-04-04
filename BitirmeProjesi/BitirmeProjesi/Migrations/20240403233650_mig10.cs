using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeProjesi.Migrations
{
    /// <inheritdoc />
    public partial class mig10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zimmetler_Malzemeler_ZimmetEdilenMalzemeId",
                table: "Zimmetler");

            migrationBuilder.DropForeignKey(
                name: "FK_Zimmetler_Personeller_ZimmetEdilenKisiId",
                table: "Zimmetler");

            migrationBuilder.RenameColumn(
                name: "ZimmetEdilenMalzemeId",
                table: "Zimmetler",
                newName: "PersonelId");

            migrationBuilder.RenameColumn(
                name: "ZimmetEdilenKisiId",
                table: "Zimmetler",
                newName: "MalzemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Zimmetler_ZimmetEdilenMalzemeId",
                table: "Zimmetler",
                newName: "IX_Zimmetler_PersonelId");

            migrationBuilder.RenameIndex(
                name: "IX_Zimmetler_ZimmetEdilenKisiId",
                table: "Zimmetler",
                newName: "IX_Zimmetler_MalzemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zimmetler_Malzemeler_MalzemeId",
                table: "Zimmetler",
                column: "MalzemeId",
                principalTable: "Malzemeler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zimmetler_Personeller_PersonelId",
                table: "Zimmetler",
                column: "PersonelId",
                principalTable: "Personeller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zimmetler_Malzemeler_MalzemeId",
                table: "Zimmetler");

            migrationBuilder.DropForeignKey(
                name: "FK_Zimmetler_Personeller_PersonelId",
                table: "Zimmetler");

            migrationBuilder.RenameColumn(
                name: "PersonelId",
                table: "Zimmetler",
                newName: "ZimmetEdilenMalzemeId");

            migrationBuilder.RenameColumn(
                name: "MalzemeId",
                table: "Zimmetler",
                newName: "ZimmetEdilenKisiId");

            migrationBuilder.RenameIndex(
                name: "IX_Zimmetler_PersonelId",
                table: "Zimmetler",
                newName: "IX_Zimmetler_ZimmetEdilenMalzemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Zimmetler_MalzemeId",
                table: "Zimmetler",
                newName: "IX_Zimmetler_ZimmetEdilenKisiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zimmetler_Malzemeler_ZimmetEdilenMalzemeId",
                table: "Zimmetler",
                column: "ZimmetEdilenMalzemeId",
                principalTable: "Malzemeler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zimmetler_Personeller_ZimmetEdilenKisiId",
                table: "Zimmetler",
                column: "ZimmetEdilenKisiId",
                principalTable: "Personeller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
