using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace KYC.Web.Migrations.KYC
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CIPDetailId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: true),
                    GeographicRiskRatingId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "RiskCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: false),
                    Ordinal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskCategory", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "RiskClass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Classification = table.Column<string>(nullable: false),
                    Ordinal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskClass", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "RiskReport",
                columns: table => new
                {
                    RiskReportId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SemVer = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskReport", x => x.RiskReportId);
                });
            migrationBuilder.CreateTable(
                name: "CustomerRiskAssessment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssessedCount = table.Column<int>(nullable: false),
                    AssessmentDate = table.Column<DateTime>(nullable: false),
                    Classification = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    CustomerRiskScore = table.Column<int>(nullable: false),
                    RiskReportId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRiskAssessment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerRiskAssessment_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerRiskAssessment_RiskReport_RiskReportId",
                        column: x => x.RiskReportId,
                        principalTable: "RiskReport",
                        principalColumn: "RiskReportId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "RiskItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerRiskAssessmentId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    RiskCategoryId = table.Column<int>(nullable: false),
                    RiskClassId = table.Column<int>(nullable: false),
                    RiskReportRiskReportId = table.Column<int>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskItem_CustomerRiskAssessment_CustomerRiskAssessmentId",
                        column: x => x.CustomerRiskAssessmentId,
                        principalTable: "CustomerRiskAssessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskItem_RiskCategory_RiskCategoryId",
                        column: x => x.RiskCategoryId,
                        principalTable: "RiskCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RiskItem_RiskClass_RiskClassId",
                        column: x => x.RiskClassId,
                        principalTable: "RiskClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RiskItem_RiskReport_RiskReportRiskReportId",
                        column: x => x.RiskReportRiskReportId,
                        principalTable: "RiskReport",
                        principalColumn: "RiskReportId",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "RiskReportItem",
                columns: table => new
                {
                    RiskReportId = table.Column<int>(nullable: false),
                    RiskItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskReportItem", x => new { x.RiskReportId, x.RiskItemId });
                    table.ForeignKey(
                        name: "FK_RiskReportItem_RiskItem_RiskItemId",
                        column: x => x.RiskItemId,
                        principalTable: "RiskItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RiskReportItem_RiskReport_RiskReportId",
                        column: x => x.RiskReportId,
                        principalTable: "RiskReport",
                        principalColumn: "RiskReportId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("RiskReportItem");
            migrationBuilder.DropTable("RiskItem");
            migrationBuilder.DropTable("CustomerRiskAssessment");
            migrationBuilder.DropTable("RiskCategory");
            migrationBuilder.DropTable("RiskClass");
            migrationBuilder.DropTable("Customer");
            migrationBuilder.DropTable("RiskReport");
        }
    }
}
