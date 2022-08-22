using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Data.Migrations
{
    public partial class Student_M : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student_Details",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Date_of_Birth = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Subjects = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Details", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student_Details");
        }
    }
}
