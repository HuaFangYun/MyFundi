using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFundi.Web.Migrations
{
    public partial class ratingsReviewsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundiProfileFundiRatings");

            migrationBuilder.DropTable(
                name: "FundiRatings");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "TransportLogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "TransportLogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "FundiProfileAndReviewRatings",
                columns: table => new
                {
                    FundiRatingAndReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Review = table.Column<string>(nullable: true),
                    FundiProfileId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundiProfileAndReviewRatings", x => x.FundiRatingAndReviewId);
                    table.ForeignKey(
                        name: "FK_FundiProfileAndReviewRatings_FundiProfiles_FundiProfileId",
                        column: x => x.FundiProfileId,
                        principalTable: "FundiProfiles",
                        principalColumn: "FundiProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundiProfileAndReviewRatings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundiProfileAndReviewRatings_FundiProfileId",
                table: "FundiProfileAndReviewRatings",
                column: "FundiProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_FundiProfileAndReviewRatings_UserId",
                table: "FundiProfileAndReviewRatings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundiProfileAndReviewRatings");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "TransportLogs");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "TransportLogs");

            migrationBuilder.CreateTable(
                name: "FundiRatings",
                columns: table => new
                {
                    FundiRatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FundiRatingDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FundiRatingSummary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundiRatings", x => x.FundiRatingId);
                });

            migrationBuilder.CreateTable(
                name: "FundiProfileFundiRatings",
                columns: table => new
                {
                    FundiProfileFundiRatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FundiProfileiId = table.Column<int>(type: "int", nullable: false),
                    FundiRatingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundiProfileFundiRatings", x => x.FundiProfileFundiRatingId);
                    table.ForeignKey(
                        name: "FK_FundiProfileFundiRatings_FundiProfiles_FundiProfileiId",
                        column: x => x.FundiProfileiId,
                        principalTable: "FundiProfiles",
                        principalColumn: "FundiProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundiProfileFundiRatings_FundiRatings_FundiRatingId",
                        column: x => x.FundiRatingId,
                        principalTable: "FundiRatings",
                        principalColumn: "FundiRatingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundiProfileFundiRatings_FundiProfileiId",
                table: "FundiProfileFundiRatings",
                column: "FundiProfileiId");

            migrationBuilder.CreateIndex(
                name: "IX_FundiProfileFundiRatings_FundiRatingId",
                table: "FundiProfileFundiRatings",
                column: "FundiRatingId");
        }
    }
}
