using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeProjesi.Migrations
{
    /// <inheritdoc />
    public partial class mig13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MasrafTarihi",
                table: "Masraflar",
                newName: "ÖdenenTarih");

            migrationBuilder.AddColumn<int>(
                name: "Maas",
                table: "Personeller",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Yetki",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "FirmaId",
                table: "Masraflar",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ÖdemeTarihi",
                table: "Masraflar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Firmalar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirmaAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelofonNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    İlgiliKisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iban = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firmalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gelirler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FaturaKesilenAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    Kesinti = table.Column<int>(type: "int", nullable: false),
                    FaturaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ÖdenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gelirler", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Masraflar_FirmaId",
                table: "Masraflar",
                column: "FirmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Masraflar_Firmalar_FirmaId",
                table: "Masraflar",
                column: "FirmaId",
                principalTable: "Firmalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masraflar_Firmalar_FirmaId",
                table: "Masraflar");

            migrationBuilder.DropTable(
                name: "Firmalar");

            migrationBuilder.DropTable(
                name: "Gelirler");

            migrationBuilder.DropIndex(
                name: "IX_Masraflar_FirmaId",
                table: "Masraflar");

            migrationBuilder.DropColumn(
                name: "Maas",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "Yetki",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "FirmaId",
                table: "Masraflar");

            migrationBuilder.DropColumn(
                name: "ÖdemeTarihi",
                table: "Masraflar");

            migrationBuilder.RenameColumn(
                name: "ÖdenenTarih",
                table: "Masraflar",
                newName: "MasrafTarihi");
        }
    }
}
