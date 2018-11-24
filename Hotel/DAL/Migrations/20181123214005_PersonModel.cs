using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class PersonModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var guid = Guid.NewGuid();

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "Orders",
                nullable: false,
                defaultValue: guid);

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    PassportData = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.Sql($"Insert into \"Persons\" values ('{guid}', 'Иванов Иван Иванович', '7809 123456')");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PersonId",
                table: "Orders",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Persons_PersonId",
                table: "Orders",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Persons_PersonId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PersonId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Orders");
        }
    }
}
