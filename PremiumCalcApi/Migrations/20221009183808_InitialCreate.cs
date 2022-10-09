using Microsoft.EntityFrameworkCore.Migrations;

namespace PremiumCalcApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rating = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Occupations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RatingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Occupations_Factors_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Factors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Factors",
                columns: new[] { "Id", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, "Light Manual", 1.50m },
                    { 2, "Heavy Manual", 1.75m },
                    { 3, "White Collar", 1.25m },
                    { 4, "Professional", 1m }
                });

            migrationBuilder.InsertData(
                table: "Occupations",
                columns: new[] { "id", "Name", "RatingId" },
                values: new object[,]
                {
                    { 1, "Cleaner", 1 },
                    { 6, "Florist", 1 },
                    { 4, "Farmer", 2 },
                    { 5, "Mechanic", 2 },
                    { 3, "Author", 3 },
                    { 2, "Doctor", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Occupations_RatingId",
                table: "Occupations",
                column: "RatingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Occupations");

            migrationBuilder.DropTable(
                name: "Factors");
        }
    }
}
