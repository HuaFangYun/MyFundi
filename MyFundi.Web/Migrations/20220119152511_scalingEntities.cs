using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFundi.Web.Migrations
{
    public partial class scalingEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    CertificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificationName = table.Column<string>(nullable: true),
                    CertificationDescription = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.CertificationId);
                });

            migrationBuilder.CreateTable(
                name: "ClientFundiContracts",
                columns: table => new
                {
                    ClientFundiContractId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientUserId = table.Column<Guid>(nullable: false),
                    FundiUserId = table.Column<Guid>(nullable: false),
                    ContractualDescription = table.Column<string>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false),
                    IsSignedOffByClient = table.Column<bool>(nullable: false),
                    NotesForNotice = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFundiContracts", x => x.ClientFundiContractId);
                    table.ForeignKey(
                        name: "FK_ClientFundiContracts_Users_ClientUserId",
                        column: x => x.ClientUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientFundiContracts_Users_FundiUserId",
                        column: x => x.FundiUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(nullable: true),
                    CourseDescription = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "FundiProfiles",
                columns: table => new
                {
                    FundiProfileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ProfileSummary = table.Column<string>(nullable: true),
                    ProfileImageUrl = table.Column<string>(nullable: true),
                    Skills = table.Column<string>(nullable: true),
                    UsedPowerTools = table.Column<string>(nullable: true),
                    FundiProfileCvUrl = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundiProfiles", x => x.FundiProfileId);
                });

            migrationBuilder.CreateTable(
                name: "FundiRatings",
                columns: table => new
                {
                    FundiRatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundiRatingDescription = table.Column<string>(nullable: true),
                    FundiRatingSummary = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundiRatings", x => x.FundiRatingId);
                });

            migrationBuilder.CreateTable(
                name: "WorkCategories",
                columns: table => new
                {
                    WorkCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkCategoryType = table.Column<string>(nullable: true),
                    WorkCategoryDescription = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkCategories", x => x.WorkCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "FundiProfileCertifications",
                columns: table => new
                {
                    FundiProfileCertificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundiProfileId = table.Column<int>(nullable: false),
                    CertificationId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundiProfileCertifications", x => x.FundiProfileCertificationId);
                    table.ForeignKey(
                        name: "FK_FundiProfileCertifications_Certifications_CertificationId",
                        column: x => x.CertificationId,
                        principalTable: "Certifications",
                        principalColumn: "CertificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundiProfileCertifications_FundiProfiles_FundiProfileId",
                        column: x => x.FundiProfileId,
                        principalTable: "FundiProfiles",
                        principalColumn: "FundiProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundiProfileCourses",
                columns: table => new
                {
                    FundiProfileCourseTakenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(nullable: false),
                    FundiProfileId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundiProfileCourses", x => x.FundiProfileCourseTakenId);
                    table.ForeignKey(
                        name: "FK_FundiProfileCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundiProfileCourses_FundiProfiles_FundiProfileId",
                        column: x => x.FundiProfileId,
                        principalTable: "FundiProfiles",
                        principalColumn: "FundiProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundiProfileFundiRatings",
                columns: table => new
                {
                    FundiProfileFundiRatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundiProfileiId = table.Column<int>(nullable: false),
                    FundiRatingId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "FundiWorkCategories",
                columns: table => new
                {
                    FundiWorkCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundiProfileId = table.Column<int>(nullable: false),
                    WorkCategoryId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundiWorkCategories", x => x.FundiWorkCategoryId);
                    table.ForeignKey(
                        name: "FK_FundiWorkCategories_FundiProfiles_FundiProfileId",
                        column: x => x.FundiProfileId,
                        principalTable: "FundiProfiles",
                        principalColumn: "FundiProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundiWorkCategories_WorkCategories_WorkCategoryId",
                        column: x => x.WorkCategoryId,
                        principalTable: "WorkCategories",
                        principalColumn: "WorkCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFundiContracts_ClientUserId",
                table: "ClientFundiContracts",
                column: "ClientUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFundiContracts_FundiUserId",
                table: "ClientFundiContracts",
                column: "FundiUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundiProfileCertifications_CertificationId",
                table: "FundiProfileCertifications",
                column: "CertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_FundiProfileCertifications_FundiProfileId",
                table: "FundiProfileCertifications",
                column: "FundiProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_FundiProfileCourses_CourseId",
                table: "FundiProfileCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_FundiProfileCourses_FundiProfileId",
                table: "FundiProfileCourses",
                column: "FundiProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_FundiProfileFundiRatings_FundiProfileiId",
                table: "FundiProfileFundiRatings",
                column: "FundiProfileiId");

            migrationBuilder.CreateIndex(
                name: "IX_FundiProfileFundiRatings_FundiRatingId",
                table: "FundiProfileFundiRatings",
                column: "FundiRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_FundiProfiles_UserId",
                table: "FundiProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundiWorkCategories_FundiProfileId",
                table: "FundiWorkCategories",
                column: "FundiProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_FundiWorkCategories_WorkCategoryId",
                table: "FundiWorkCategories",
                column: "WorkCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientFundiContracts");

            migrationBuilder.DropTable(
                name: "FundiProfileCertifications");

            migrationBuilder.DropTable(
                name: "FundiProfileCourses");

            migrationBuilder.DropTable(
                name: "FundiProfileFundiRatings");

            migrationBuilder.DropTable(
                name: "FundiWorkCategories");

            migrationBuilder.DropTable(
                name: "Certifications");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "FundiRatings");

            migrationBuilder.DropTable(
                name: "FundiProfiles");

            migrationBuilder.DropTable(
                name: "WorkCategories");
        }
    }
}
