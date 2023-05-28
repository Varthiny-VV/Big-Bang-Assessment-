using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Booking_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hotel_Id = table.Column<int>(type: "int", nullable: false),
                    Hotel_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Room_Number = table.Column<int>(type: "int", nullable: false),
                    Room_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Room_Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckIn_DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut_DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Booking_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
