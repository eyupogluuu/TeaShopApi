using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeaShopApi.DataAccessLayer.Migrations
{
    public partial class mig_first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    contactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    messageSenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    messageSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    messageMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    messageDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    messageSendDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.contactID);
                });

            migrationBuilder.CreateTable(
                name: "drinks",
                columns: table => new
                {
                    drinkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    drinkName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    drinkPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    drinkImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drinks", x => x.drinkID);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    questionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    questionDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    answerDetail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.questionID);
                });

            migrationBuilder.CreateTable(
                name: "testimonials",
                columns: table => new
                {
                    testimonialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    testimonilName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    testimonilComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    testimonilImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testimonials", x => x.testimonialID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "drinks");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "testimonials");
        }
    }
}
