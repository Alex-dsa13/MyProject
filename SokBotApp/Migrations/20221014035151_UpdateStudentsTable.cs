using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SokBotApp.Migrations
{
    public partial class UpdateStudentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Descipline",
                table: "Students",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descipline",
                table: "Students");
        }
    }
}
