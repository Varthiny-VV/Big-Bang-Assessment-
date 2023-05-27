using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotels.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Hotel_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hotel_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hotel_Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hotel_Phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hotel_Amenities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalNumberOfRooms = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Hotel_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
