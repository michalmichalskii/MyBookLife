using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBookLife.Infrastructure.Migrations
{
    public partial class DiaryOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Diaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Diaries");
        }
    }
}
