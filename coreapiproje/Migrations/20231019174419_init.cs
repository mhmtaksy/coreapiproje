using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace coreapiproje.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "magazalars",
                columns: table => new
                {
                    magazaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    magazaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    magazaAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    magazaCalisanSayisi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_magazalars", x => x.magazaID);
                });

            migrationBuilder.CreateTable(
                name: "kiyafetlers",
                columns: table => new
                {
                    kiyafetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kiyafetAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uretimYeri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uretimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    magazaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kiyafetlers", x => x.kiyafetID);
                    table.ForeignKey(
                        name: "FK_kiyafetlers_magazalars_magazaID",
                        column: x => x.magazaID,
                        principalTable: "magazalars",
                        principalColumn: "magazaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "elemanlars",
                columns: table => new
                {
                    elemanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    elemanAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    elemanSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    elemanCinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    kiyafetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_elemanlars", x => x.elemanID);
                    table.ForeignKey(
                        name: "FK_elemanlars_kiyafetlers_kiyafetID",
                        column: x => x.kiyafetID,
                        principalTable: "kiyafetlers",
                        principalColumn: "kiyafetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "müsterilers",
                columns: table => new
                {
                    müsteriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    müsteriAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    müsteriSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    müsteriDogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    müsteriCinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    elemanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_müsterilers", x => x.müsteriID);
                    table.ForeignKey(
                        name: "FK_müsterilers_elemanlars_elemanID",
                        column: x => x.elemanID,
                        principalTable: "elemanlars",
                        principalColumn: "elemanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_elemanlars_kiyafetID",
                table: "elemanlars",
                column: "kiyafetID");

            migrationBuilder.CreateIndex(
                name: "IX_kiyafetlers_magazaID",
                table: "kiyafetlers",
                column: "magazaID");

            migrationBuilder.CreateIndex(
                name: "IX_müsterilers_elemanID",
                table: "müsterilers",
                column: "elemanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "müsterilers");

            migrationBuilder.DropTable(
                name: "elemanlars");

            migrationBuilder.DropTable(
                name: "kiyafetlers");

            migrationBuilder.DropTable(
                name: "magazalars");
        }
    }
}
