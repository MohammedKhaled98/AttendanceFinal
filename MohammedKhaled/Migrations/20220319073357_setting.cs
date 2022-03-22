using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MohammedKhaled.Migrations
{
    public partial class setting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attend",
                columns: table => new
                {
                    AId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tnow = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Tout = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckIn = table.Column<bool>(type: "bit", nullable: true),
                    CheckOut = table.Column<bool>(type: "bit", nullable: true),
                    InState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    outState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                     WHours = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attend", x => x.AId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<int>(type: "int", nullable: true),
                    atID = table.Column<int>(type: "int", nullable: true)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attend");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
