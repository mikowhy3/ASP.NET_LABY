using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LAB3_SIWON.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    First_Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Last_Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    phone = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "BirthDate", "Category", "Created", "Email", "First_Name", "Last_Name", "phone" },
                values: new object[,]
                {
                    { 1, new DateOnly(2000, 10, 23), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "adam@wsei.edu.pl", "Adam", "Kowal", "123456789" },
                    { 2, new DateOnly(2001, 10, 23), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ada@wsei.edu.pl", "Ada", "Wal", "123457789" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");
        }
    }
}
