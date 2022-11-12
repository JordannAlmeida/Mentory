using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    public partial class CreateTableBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BOOK",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    AUTHOR = table.Column<string>(type: "text", nullable: false),
                    TITLE = table.Column<string>(type: "text", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PAGE_NUMBER = table.Column<int>(type: "integer", nullable: false),
                    PRICE = table.Column<float>(type: "real", precision: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOK", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BOOK");
        }
    }
}
