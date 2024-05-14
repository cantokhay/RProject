﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DataAccess.Migrations
{
    public partial class twelveth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    SliderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SliderTitle1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderDescription1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderDescription2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderTitle3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderDescription3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.SliderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sliders");
        }
    }
}
