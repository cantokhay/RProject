using Microsoft.EntityFrameworkCore.Migrations;
using Project.DataAccess.Concrete;
using Project.DataAccess.SeedData;

#nullable disable

namespace Project.DataAccess.Migrations
{
    public partial class twentysixthonPC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var context = new SignalRContext())
            {
                var seedData = new SeedDataGenerator();
                seedData.SeedAsync(context).Wait();
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
