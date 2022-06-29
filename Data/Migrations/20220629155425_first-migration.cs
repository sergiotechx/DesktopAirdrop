using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    User = table.Column<string>(type: "char", maxLength: 255, nullable: false),
                    Id = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "char", maxLength: 255, nullable: false),
                    MachineId = table.Column<string>(type: "char", maxLength: 255, nullable: false),
                    License = table.Column<string>(type: "char", maxLength: 255, nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.User);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Address = table.Column<string>(type: "char", maxLength: 255, nullable: false),
                    PrivateKey = table.Column<string>(type: "char", maxLength: 255, nullable: false),
                    Contract = table.Column<string>(type: "char", maxLength: 255, nullable: false),
                    ChainId = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    ConnectionString = table.Column<string>(type: "char", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Address);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Address = table.Column<string>(type: "char", maxLength: 255, nullable: false),
                    Qty = table.Column<decimal>(type: "integer", precision: 50, scale: 18, nullable: false),
                    HashId = table.Column<string>(type: "char", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Address);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_HashId",
                table: "Transaction",
                column: "HashId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Transaction");
        }
    }
}
