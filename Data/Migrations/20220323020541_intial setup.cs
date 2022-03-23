using Microsoft.EntityFrameworkCore.Migrations;

namespace TwoSentenceHorrorStory.Data.Migrations
{
    public partial class intialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sentence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntroSentence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostSentence = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentence", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sentence");
        }
    }
}
