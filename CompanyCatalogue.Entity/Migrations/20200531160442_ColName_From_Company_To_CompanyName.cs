using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyCatalogue.Entity.Migrations
{
    public partial class ColName_From_Company_To_CompanyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                schema: "dbo",
                table: "CompanyDetails");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                schema: "dbo",
                table: "CompanyDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                schema: "dbo",
                table: "CompanyDetails");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                schema: "dbo",
                table: "CompanyDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
