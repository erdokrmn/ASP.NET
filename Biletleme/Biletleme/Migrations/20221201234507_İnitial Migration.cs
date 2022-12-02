using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biletleme.Migrations
{
    /// <inheritdoc />
    public partial class İnitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoğumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TelNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayıtTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musteriler");
        }
    }
}
