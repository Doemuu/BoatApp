using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace boatappapi.Migrations
{
    public partial class DbDoemuuv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Colour = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Boats",
                columns: new[] { "Id", "Colour", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("3a9a9d3c-742d-4971-9a97-42ab50220fbe"), 2, "This is the Boat 0. It's colour is: WHITE", "Boat0" },
                    { new Guid("47ccc806-4adb-439e-8fd9-63df12a58a23"), 0, "This is the Boat 1. It's colour is: BLACK", "Boat1" },
                    { new Guid("f8203b18-d8c1-4db1-b557-df4e2c0cd85f"), 5, "This is the Boat 2. It's colour is: BLUE", "Boat2" },
                    { new Guid("c4133925-4b6e-49b3-b5e3-9393d5ae9e78"), 2, "This is the Boat 3. It's colour is: WHITE", "Boat3" },
                    { new Guid("85d57863-9835-4895-80bb-ee2f6d8b8f61"), 3, "This is the Boat 4. It's colour is: YELLOW", "Boat4" },
                    { new Guid("1dc05b8a-9936-49cb-a1e7-c24e3a4712b6"), 0, "This is the Boat 5.", "Boat5" },
                    { new Guid("02c70bb0-f9fb-427c-a787-9a0ac225a892"), 0, "This is the Boat 6.", "Boat6" },
                    { new Guid("a241b40a-4bdb-4f03-9261-40de857f80ee"), 5, "This is the Boat 7. It's colour is: BLUE", "Boat7" },
                    { new Guid("b4790857-8309-4e27-b16e-602deba3b1bb"), 0, "This is the Boat 8.", "Boat8" },
                    { new Guid("5e006c55-e39d-4204-af40-b215cf79ad28"), 0, "This is the Boat 9. It's colour is: BLACK", "Boat9" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("24e7189f-68f3-4588-91ea-62f023b566a1"), "$2a$11$04oPUn7yWtie4qQ8IWiGnug7HWBmW6sT9uCC2hGUh.gNzAsvcJfSa", "Doemuu" },
                    { new Guid("1b7372f6-7f0f-4d35-ac72-3a6bbc33f1b3"), "$2a$11$K1keFfN0EXlThGFlGw7MueEM8xdD3mNPwV4RsPc2VkB1S74TkR8hu", "Admin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boats");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
