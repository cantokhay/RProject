using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DataAccess.Migrations
{
    public partial class twentyfirstonPC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    FeatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureDescription1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureDescription2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureDescription3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureTitle1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureTitle3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.FeatureId);
                });
        }
    }
}
