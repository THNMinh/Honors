using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VietKoiShow.Migrations
{
    /// <inheritdoc />
    public partial class V0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBLCategory",
                columns: table => new
                {
                    CategoryID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CategoryName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Species = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Size = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Category_Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBLCateg__19093A2B870AE3D6", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "TBLNewsType",
                columns: table => new
                {
                    NewsTypeID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBLNewsT__9013FE2A5CA3A75C", x => x.NewsTypeID);
                });

            migrationBuilder.CreateTable(
                name: "TBLRole",
                columns: table => new
                {
                    RoleID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RoleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Role_Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Experience = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBLRole__8AFACE3AE8126C23", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "TBLVariety",
                columns: table => new
                {
                    VarietyID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    VarietyName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Origin = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Variety_Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBLVarie__08E3A048C6F34A8B", x => x.VarietyID);
                });

            migrationBuilder.CreateTable(
                name: "TBLCompetition",
                columns: table => new
                {
                    CompID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CategoryID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompDescription = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Location = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBLCompe__AD362A76AD2BEC90", x => x.CompID);
                    table.ForeignKey(
                        name: "FK_TBLCompetition_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "TBLCategory",
                        principalColumn: "CategoryID");
                });

            migrationBuilder.CreateTable(
                name: "TBLUser",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    RoleID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FullName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBLUser__1788CCACE01F8A26", x => x.UserID);
                    table.ForeignKey(
                        name: "FK__TBLUser__RoleID__3B75D760",
                        column: x => x.RoleID,
                        principalTable: "TBLRole",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "TBLNews",
                columns: table => new
                {
                    NewsID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NewsTypeID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UserID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBLNews__954EBDD323D8C63D", x => x.NewsID);
                    table.ForeignKey(
                        name: "FK__TBLNews__NewsTyp__3E52440B",
                        column: x => x.NewsTypeID,
                        principalTable: "TBLNewsType",
                        principalColumn: "NewsTypeID");
                    table.ForeignKey(
                        name: "FK__TBLNews__UserID__3F466844",
                        column: x => x.UserID,
                        principalTable: "TBLUser",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "TBLKoiFish",
                columns: table => new
                {
                    KoiID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    VarietyID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UserID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ResultID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    KoiName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Size = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBLKoiFi__E03435B85376C1B9", x => x.KoiID);
                    table.ForeignKey(
                        name: "FK__TBLKoiFis__UserI__44FF419A",
                        column: x => x.UserID,
                        principalTable: "TBLUser",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK__TBLKoiFis__Varie__440B1D61",
                        column: x => x.VarietyID,
                        principalTable: "TBLVariety",
                        principalColumn: "VarietyID");
                });

            migrationBuilder.CreateTable(
                name: "TBLPrediction",
                columns: table => new
                {
                    PredictionID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    KoiID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PredictedScore = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBLPredi__BAE4C140C86C7AA4", x => x.PredictionID);
                    table.ForeignKey(
                        name: "FK__TBLPredic__CompI__5535A963",
                        column: x => x.CompID,
                        principalTable: "TBLCompetition",
                        principalColumn: "CompID");
                    table.ForeignKey(
                        name: "FK__TBLPredic__KoiID__5441852A",
                        column: x => x.KoiID,
                        principalTable: "TBLKoiFish",
                        principalColumn: "KoiID");
                });

            migrationBuilder.CreateTable(
                name: "TBLRegistration",
                columns: table => new
                {
                    RegistrationID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    KoiID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBLRegis__6EF58830FFE247A1", x => x.RegistrationID);
                    table.ForeignKey(
                        name: "FK__TBLRegist__CompI__4E88ABD4",
                        column: x => x.CompID,
                        principalTable: "TBLCompetition",
                        principalColumn: "CompID");
                    table.ForeignKey(
                        name: "FK__TBLRegist__KoiID__4D94879B",
                        column: x => x.KoiID,
                        principalTable: "TBLKoiFish",
                        principalColumn: "KoiID");
                });

            migrationBuilder.CreateTable(
                name: "TBLResult",
                columns: table => new
                {
                    ResultID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    KoiID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ResultScore = table.Column<double>(type: "float", nullable: true),
                    Prize = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBLResul__97690228895F78EA", x => x.ResultID);
                    table.ForeignKey(
                        name: "FK__TBLResult__KoiID__47DBAE45",
                        column: x => x.KoiID,
                        principalTable: "TBLKoiFish",
                        principalColumn: "KoiID");
                });

            migrationBuilder.CreateTable(
                name: "TBLScore",
                columns: table => new
                {
                    ScoreID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    KoiID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UserID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ScoreShape = table.Column<double>(type: "float", nullable: true),
                    ScoreColor = table.Column<double>(type: "float", nullable: true),
                    ScorePattern = table.Column<double>(type: "float", nullable: true),
                    TotalScore = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBLScore__7DD229F13E5E5D99", x => x.ScoreID);
                    table.ForeignKey(
                        name: "FK__TBLScore__CompID__59063A47",
                        column: x => x.CompID,
                        principalTable: "TBLCompetition",
                        principalColumn: "CompID");
                    table.ForeignKey(
                        name: "FK__TBLScore__KoiID__5812160E",
                        column: x => x.KoiID,
                        principalTable: "TBLKoiFish",
                        principalColumn: "KoiID");
                    table.ForeignKey(
                        name: "FK__TBLScore__UserID__59FA5E80",
                        column: x => x.UserID,
                        principalTable: "TBLUser",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBLCompetition_CategoryID",
                table: "TBLCompetition",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLKoiFish_ResultID",
                table: "TBLKoiFish",
                column: "ResultID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLKoiFish_UserID",
                table: "TBLKoiFish",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLKoiFish_VarietyID",
                table: "TBLKoiFish",
                column: "VarietyID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLNews_NewsTypeID",
                table: "TBLNews",
                column: "NewsTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLNews_UserID",
                table: "TBLNews",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLPrediction_CompID",
                table: "TBLPrediction",
                column: "CompID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLPrediction_KoiID",
                table: "TBLPrediction",
                column: "KoiID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLRegistration_CompID",
                table: "TBLRegistration",
                column: "CompID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLRegistration_KoiID",
                table: "TBLRegistration",
                column: "KoiID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLResult_KoiID",
                table: "TBLResult",
                column: "KoiID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLScore_CompID",
                table: "TBLScore",
                column: "CompID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLScore_KoiID",
                table: "TBLScore",
                column: "KoiID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLScore_UserID",
                table: "TBLScore",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLUser_RoleID",
                table: "TBLUser",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_TBLKoiFish_ResultID",
                table: "TBLKoiFish",
                column: "ResultID",
                principalTable: "TBLResult",
                principalColumn: "ResultID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBLKoiFish_ResultID",
                table: "TBLKoiFish");

            migrationBuilder.DropTable(
                name: "TBLNews");

            migrationBuilder.DropTable(
                name: "TBLPrediction");

            migrationBuilder.DropTable(
                name: "TBLRegistration");

            migrationBuilder.DropTable(
                name: "TBLScore");

            migrationBuilder.DropTable(
                name: "TBLNewsType");

            migrationBuilder.DropTable(
                name: "TBLCompetition");

            migrationBuilder.DropTable(
                name: "TBLCategory");

            migrationBuilder.DropTable(
                name: "TBLResult");

            migrationBuilder.DropTable(
                name: "TBLKoiFish");

            migrationBuilder.DropTable(
                name: "TBLUser");

            migrationBuilder.DropTable(
                name: "TBLVariety");

            migrationBuilder.DropTable(
                name: "TBLRole");
        }
    }
}
