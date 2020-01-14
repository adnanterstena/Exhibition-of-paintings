using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EkspozitaPikturave.Data.Migrations
{
    public partial class PikturatEKSMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ekspozitat",
                columns: table => new
                {
                    Id_Ekspozites = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulli = table.Column<string>(maxLength: 500, nullable: false),
                    Pershkrimi = table.Column<string>(nullable: true),
                    FotojaURL = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ekspozitat", x => x.Id_Ekspozites);
                });

            migrationBuilder.CreateTable(
                name: "Kritikat",
                columns: table => new
                {
                    Id_Kritika = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Useri = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id_Piktura = table.Column<int>(nullable: false),
                    TekstiKritikes = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kritikat", x => x.Id_Kritika);
                });

            migrationBuilder.CreateTable(
                name: "Pikturat",
                columns: table => new
                {
                    IdPiktura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlPath = table.Column<string>(nullable: false),
                    TitulliPiktures = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ID_Useri = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pershkrimi = table.Column<string>(nullable: true),
                    Karakteristikat = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    DataPostimit = table.Column<DateTime>(nullable: false),
                    Ekspozitat = table.Column<int>(nullable: false),
                    LLojiPiktures = table.Column<string>(nullable: true),
                    CmimiPiktures = table.Column<decimal>(nullable: false),
                    Disponueshmeria = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Shporta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pikturat", x => x.IdPiktura);
                });

            migrationBuilder.CreateTable(
                name: "Shporta",
                columns: table => new
                {
                    Id_Shporta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_UseriKlient = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id_Piktura = table.Column<int>(nullable: false),
                    Cmimi = table.Column<decimal>(nullable: false),
                    Blerja = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shporta", x => x.Id_Shporta);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ekspozitat");

            migrationBuilder.DropTable(
                name: "Kritikat");

            migrationBuilder.DropTable(
                name: "Pikturat");

            migrationBuilder.DropTable(
                name: "Shporta");
        }
    }
}
