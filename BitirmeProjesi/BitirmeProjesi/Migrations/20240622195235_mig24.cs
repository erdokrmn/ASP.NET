﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeProjesi.Migrations
{
    /// <inheritdoc />
    public partial class mig24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GemiSurecleri");

            migrationBuilder.AddColumn<string>(
                name: "Durum",
                table: "GemiEnvanterleri",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonelId",
                table: "GemiEnvanterleri",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Tarih",
                table: "GemiEnvanterleri",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "GemiEnvanteriPersonel",
                columns: table => new
                {
                    GemiEnvanterleriId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GemiEnvanteriPersonel", x => new { x.GemiEnvanterleriId, x.PersonelId });
                    table.ForeignKey(
                        name: "FK_GemiEnvanteriPersonel_GemiEnvanterleri_GemiEnvanterleriId",
                        column: x => x.GemiEnvanterleriId,
                        principalTable: "GemiEnvanterleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GemiEnvanteriPersonel_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GemiEnvanteriPersonel_PersonelId",
                table: "GemiEnvanteriPersonel",
                column: "PersonelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GemiEnvanteriPersonel");

            migrationBuilder.DropColumn(
                name: "Durum",
                table: "GemiEnvanterleri");

            migrationBuilder.DropColumn(
                name: "PersonelId",
                table: "GemiEnvanterleri");

            migrationBuilder.DropColumn(
                name: "Tarih",
                table: "GemiEnvanterleri");

            migrationBuilder.CreateTable(
                name: "GemiSurecleri",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CalısanPersonellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParcaAdıId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SürecTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "IX_GemiSurecleri_CalısanPersonellerId",
                table: "GemiSurecleri",
                column: "CalısanPersonellerId");

            migrationBuilder.CreateIndex(
                name: "IX_GemiSurecleri_ParcaAdıId",
                table: "GemiSurecleri",
                column: "ParcaAdıId");
        }
    }
}
