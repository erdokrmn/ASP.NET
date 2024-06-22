using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeProjesi.Migrations
{
    /// <inheritdoc />
    public partial class mig23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DegerMaasi",
                table: "Maaslar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MesaiMaasi",
                table: "Maaslar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NormalMaas",
                table: "Maaslar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OzelGunMaasi",
                table: "Maaslar",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DegerMaasi",
                table: "Maaslar");

            migrationBuilder.DropColumn(
                name: "MesaiMaasi",
                table: "Maaslar");

            migrationBuilder.DropColumn(
                name: "NormalMaas",
                table: "Maaslar");

            migrationBuilder.DropColumn(
                name: "OzelGunMaasi",
                table: "Maaslar");
        }
    }
}
