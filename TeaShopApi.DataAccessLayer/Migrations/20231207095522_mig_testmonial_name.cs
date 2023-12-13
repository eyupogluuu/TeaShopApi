using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeaShopApi.DataAccessLayer.Migrations
{
    public partial class mig_testmonial_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "testimonilName",
                table: "testimonials",
                newName: "testimonialName");

            migrationBuilder.RenameColumn(
                name: "testimonilImageUrl",
                table: "testimonials",
                newName: "testimonialImageUrl");

            migrationBuilder.RenameColumn(
                name: "testimonilComment",
                table: "testimonials",
                newName: "testimonialComment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "testimonialName",
                table: "testimonials",
                newName: "testimonilName");

            migrationBuilder.RenameColumn(
                name: "testimonialImageUrl",
                table: "testimonials",
                newName: "testimonilImageUrl");

            migrationBuilder.RenameColumn(
                name: "testimonialComment",
                table: "testimonials",
                newName: "testimonilComment");
        }
    }
}
