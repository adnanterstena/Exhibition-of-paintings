using Microsoft.EntityFrameworkCore.Migrations;

namespace EkspozitaPikturave.Data.Migrations
{
    public partial class PikturatEKSMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Shporta",
                table: "Pikturat",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Ekspozitat",
                table: "Pikturat",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Ekspozita",
                table: "Ekspozitat",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ekspozita",
                table: "Ekspozitat");

            migrationBuilder.AlterColumn<int>(
                name: "Shporta",
                table: "Pikturat",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Ekspozitat",
                table: "Pikturat",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
