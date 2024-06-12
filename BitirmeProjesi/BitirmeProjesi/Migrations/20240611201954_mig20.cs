using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeProjesi.Migrations
{
    /// <inheritdoc />
    public partial class mig20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EMail",
                table: "Personeller",
                newName: "CalıstıgıTershane");

            migrationBuilder.CreateTable(
                name: "GCs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GS = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CS = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GCs_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GCs_PersonelId",
                table: "GCs",
                column: "PersonelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GCs");

            migrationBuilder.RenameColumn(
                name: "CalıstıgıTershane",
                table: "Personeller",
                newName: "EMail");
        }
    }
}
