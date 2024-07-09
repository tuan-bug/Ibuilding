using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBUIDING.Migrations
{
    /// <inheritdoc />
    public partial class CreateProjectsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodeProject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameProject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PeopleContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneContact = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AddressProject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
