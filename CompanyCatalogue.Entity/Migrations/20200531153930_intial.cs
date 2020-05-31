using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyCatalogue.Entity.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Catalogues",
                schema: "dbo",
                columns: table => new
                {
                    CatalogueId = table.Column<string>(nullable: false),
                    FileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogues", x => x.CatalogueId);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDetails",
                schema: "dbo",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogueId = table.Column<string>(nullable: true),
                    SlNo = table.Column<int>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    Sector = table.Column<string>(nullable: true),
                    SubSector = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    NumberOfEmployees = table.Column<int>(nullable: false),
                    TotalRevenues = table.Column<double>(nullable: false),
                    WebSite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDetails", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Catalogue_CatalogueId",
                        column: x => x.CatalogueId,
                        principalSchema: "dbo",
                        principalTable: "Catalogues",
                        principalColumn: "CatalogueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDetails_CatalogueId",
                schema: "dbo",
                table: "CompanyDetails",
                column: "CatalogueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyDetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Catalogues",
                schema: "dbo");
        }
    }
}
