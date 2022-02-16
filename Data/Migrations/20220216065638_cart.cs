using Microsoft.EntityFrameworkCore.Migrations;

namespace BilliWebApp.Data.Migrations
{
    public partial class cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => new { x.CartID, x.UserID });
                });

            migrationBuilder.CreateTable(
                name: "CartContents",
                columns: table => new
                {
                    CartID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MotorcycleID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CartID1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CartUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartContents", x => new { x.CartID, x.MotorcycleID });
                    table.ForeignKey(
                        name: "FK_CartContents_Carts_CartID1_CartUserID",
                        columns: x => new { x.CartID1, x.CartUserID },
                        principalTable: "Carts",
                        principalColumns: new[] { "CartID", "UserID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartContents_CartID1_CartUserID",
                table: "CartContents",
                columns: new[] { "CartID1", "CartUserID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartContents");

            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
