using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBookLife.Infrastructure.Migrations
{
    public partial class ManyToOneEntryWithBookRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Entries_EntryId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_EntryId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "EntryId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_BookId",
                table: "Entries",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Books_BookId",
                table: "Entries",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Books_BookId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_BookId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Entries");

            migrationBuilder.AddColumn<int>(
                name: "EntryId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_EntryId",
                table: "Books",
                column: "EntryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Entries_EntryId",
                table: "Books",
                column: "EntryId",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
