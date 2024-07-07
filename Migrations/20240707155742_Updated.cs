using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Migrations
{
    /// <inheritdoc />
    public partial class Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryBooks",
                table: "LibraryBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryAuthors",
                table: "LibraryAuthors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors");

            migrationBuilder.AddColumn<int>(
                name: "LibraryBookId",
                table: "LibraryBooks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "LibraryAuthorId",
                table: "LibraryAuthors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BookAuthorId",
                table: "BookAuthors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryBooks",
                table: "LibraryBooks",
                column: "LibraryBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryAuthors",
                table: "LibraryAuthors",
                column: "LibraryAuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors",
                column: "BookAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryBooks_LibraryId",
                table: "LibraryBooks",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryAuthors_LibraryId",
                table: "LibraryAuthors",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BookId",
                table: "BookAuthors",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryBooks",
                table: "LibraryBooks");

            migrationBuilder.DropIndex(
                name: "IX_LibraryBooks_LibraryId",
                table: "LibraryBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryAuthors",
                table: "LibraryAuthors");

            migrationBuilder.DropIndex(
                name: "IX_LibraryAuthors_LibraryId",
                table: "LibraryAuthors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthors_BookId",
                table: "BookAuthors");

            migrationBuilder.DropColumn(
                name: "LibraryBookId",
                table: "LibraryBooks");

            migrationBuilder.DropColumn(
                name: "LibraryAuthorId",
                table: "LibraryAuthors");

            migrationBuilder.DropColumn(
                name: "BookAuthorId",
                table: "BookAuthors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryBooks",
                table: "LibraryBooks",
                columns: new[] { "LibraryId", "BookId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryAuthors",
                table: "LibraryAuthors",
                columns: new[] { "LibraryId", "AuthorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors",
                columns: new[] { "BookId", "AuthorId" });
        }
    }
}
