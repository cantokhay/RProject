using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DataAccess.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title3",
                table: "Features",
                newName: "FeatureTitle3");

            migrationBuilder.RenameColumn(
                name: "Title2",
                table: "Features",
                newName: "FeatureTitle2");

            migrationBuilder.RenameColumn(
                name: "Title1",
                table: "Features",
                newName: "FeatureTitle1");

            migrationBuilder.RenameColumn(
                name: "Description3",
                table: "Features",
                newName: "FeatureDescription3");

            migrationBuilder.RenameColumn(
                name: "Description2",
                table: "Features",
                newName: "FeatureDescription2");

            migrationBuilder.RenameColumn(
                name: "Description1",
                table: "Features",
                newName: "FeatureDescription1");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Abouts",
                newName: "AboutTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeatureTitle3",
                table: "Features",
                newName: "Title3");

            migrationBuilder.RenameColumn(
                name: "FeatureTitle2",
                table: "Features",
                newName: "Title2");

            migrationBuilder.RenameColumn(
                name: "FeatureTitle1",
                table: "Features",
                newName: "Title1");

            migrationBuilder.RenameColumn(
                name: "FeatureDescription3",
                table: "Features",
                newName: "Description3");

            migrationBuilder.RenameColumn(
                name: "FeatureDescription2",
                table: "Features",
                newName: "Description2");

            migrationBuilder.RenameColumn(
                name: "FeatureDescription1",
                table: "Features",
                newName: "Description1");

            migrationBuilder.RenameColumn(
                name: "AboutTitle",
                table: "Abouts",
                newName: "Title");
        }
    }
}
