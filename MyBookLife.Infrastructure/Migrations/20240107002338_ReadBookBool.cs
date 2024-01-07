using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBookLife.Infrastructure.Migrations
{
    public partial class ReadBookBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Read",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Read",
                table: "Books");
        }
    }
}
