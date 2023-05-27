using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rooms.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Room_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Room_Number = table.Column<int>(type: "int", nullable: false),
                    Room_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Room_Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Room_Price = table.Column<float>(type: "real", nullable: false),
                    Room_Availability = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Room_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
