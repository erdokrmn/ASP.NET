using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeProjesi.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gemiler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GemiAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GemiTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TahminiBitirmeSuresi = table.Column<int>(type: "int", nullable: true),
                    GemiyeBaslamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gemiler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Malzemeler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MalzemeAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MalzemeTürü = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MalzemeSkt = table.Column<int>(type: "int", nullable: true),
                    MalzemeAdet = table.Column<int>(type: "int", nullable: false),
                    MalzemeFiyatı = table.Column<int>(type: "int", nullable: false),
                    MalzemeKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MalzemeAlınısTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ÜrünDurumu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malzemeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Masraflar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MasrafAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasrafTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasrafTutarı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasrafTarihi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masraflar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personeller",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TcNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KanGrubu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoğumYeri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Il = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ilce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    DoğumYılı = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EDevletŞifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcilDurumdaUlaşılacakKişiNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IseBaslamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IstenAyrılmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CalısmaDurumu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personeller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GemiEnvanterleri",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sfı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParcaAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParcaMiktarı = table.Column<int>(type: "int", nullable: false),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GemiAdıId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GemiEnvanterleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GemiEnvanterleri_Gemiler_GemiAdıId",
                        column: x => x.GemiAdıId,
                        principalTable: "Gemiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tevziler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TevziTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CalısmaSaati = table.Column<int>(type: "int", nullable: false),
                    MesaiSaati = table.Column<int>(type: "int", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    PersonelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tevziler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tevziler_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zimmetler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VerilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MalzemeSkt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZimmetEdilenKisiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZimmetEdilenMalzemeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zimmetler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zimmetler_Malzemeler_ZimmetEdilenMalzemeId",
                        column: x => x.ZimmetEdilenMalzemeId,
                        principalTable: "Malzemeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zimmetler_Personeller_ZimmetEdilenKisiId",
                        column: x => x.ZimmetEdilenKisiId,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GemiSurecleri",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SürecTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CalısanPersonellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParcaAdıId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GemiSurecleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GemiSurecleri_GemiEnvanterleri_ParcaAdıId",
                        column: x => x.ParcaAdıId,
                        principalTable: "GemiEnvanterleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GemiSurecleri_Personeller_CalısanPersonellerId",
                        column: x => x.CalısanPersonellerId,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GemiEnvanterleri_GemiAdıId",
                table: "GemiEnvanterleri",
                column: "GemiAdıId");

            migrationBuilder.CreateIndex(
                name: "IX_GemiSurecleri_CalısanPersonellerId",
                table: "GemiSurecleri",
                column: "CalısanPersonellerId");

            migrationBuilder.CreateIndex(
                name: "IX_GemiSurecleri_ParcaAdıId",
                table: "GemiSurecleri",
                column: "ParcaAdıId");

            migrationBuilder.CreateIndex(
                name: "IX_Tevziler_PersonelId",
                table: "Tevziler",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Zimmetler_ZimmetEdilenKisiId",
                table: "Zimmetler",
                column: "ZimmetEdilenKisiId");

            migrationBuilder.CreateIndex(
                name: "IX_Zimmetler_ZimmetEdilenMalzemeId",
                table: "Zimmetler",
                column: "ZimmetEdilenMalzemeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GemiSurecleri");

            migrationBuilder.DropTable(
                name: "Masraflar");

            migrationBuilder.DropTable(
                name: "Tevziler");

            migrationBuilder.DropTable(
                name: "Zimmetler");

            migrationBuilder.DropTable(
                name: "GemiEnvanterleri");

            migrationBuilder.DropTable(
                name: "Malzemeler");

            migrationBuilder.DropTable(
                name: "Personeller");

            migrationBuilder.DropTable(
                name: "Gemiler");
        }
    }
}
