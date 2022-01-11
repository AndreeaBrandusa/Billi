using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BilliWebApp.Data.Migrations
{
    public partial class AddMotorcycleImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MotorcycleImages",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorcycleImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MotorcycleImages_Motorcycles_ID",
                        column: x => x.ID,
                        principalTable: "Motorcycles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotorcycleImages");
        }
    }
}
