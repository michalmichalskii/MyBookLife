using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBookLife.Infrastructure.Migrations
{
    public partial class OneToOneEntryWithBookRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_EntryId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Entries");

            migrationBuilder.CreateIndex(
                name: "IX_Books_EntryId",
                table: "Books",
                column: "EntryId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_EntryId",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Entries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Books_EntryId",
                table: "Books",
                column: "EntryId");
        }
    }
}
