using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBookLife.Infrastructure.Migrations
{
    public partial class PagesRead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalBooksRead",
                table: "Entries");

            migrationBuilder.RenameColumn(
                name: "TotalPagesRead",
                table: "Entries",
                newName: "PagesRead");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PagesRead",
                table: "Entries",
                newName: "TotalPagesRead");

            migrationBuilder.AddColumn<int>(
                name: "TotalBooksRead",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
