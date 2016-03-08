using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using KYC.Web.Models.KYC;

namespace KYC.Web.Migrations.KYC
{
    [DbContext(typeof(KYCContext))]
    [Migration("20160308171509_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("KYC.Web.Models.KYC.Customer", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("CIPDetailId");

                    b.Property<int?>("DepartmentId");

                    b.Property<int?>("GeographicRiskRatingId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Customer");
                });

            modelBuilder.Entity("KYC.Web.Models.KYC.CustomerRiskAssessment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssessedCount");

                    b.Property<DateTime>("AssessmentDate");

                    b.Property<string>("Classification");

                    b.Property<int>("CustomerId");

                    b.Property<int>("CustomerRiskScore");

                    b.Property<int>("RiskReportId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "CustomerRiskAssessment");
                });

            modelBuilder.Entity("KYC.Web.Models.KYC.RiskCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .IsRequired();

                    b.Property<int>("Ordinal");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "RiskCategory");
                });

            modelBuilder.Entity("KYC.Web.Models.KYC.RiskClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Classification")
                        .IsRequired();

                    b.Property<int>("Ordinal");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "RiskClass");
                });

            modelBuilder.Entity("KYC.Web.Models.KYC.RiskItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerRiskAssessmentId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("RiskCategoryId");

                    b.Property<int>("RiskClassId");

                    b.Property<int?>("RiskReportRiskReportId");

                    b.Property<int>("Score");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "RiskItem");
                });

            modelBuilder.Entity("KYC.Web.Models.KYC.RiskReport", b =>
                {
                    b.Property<int>("RiskReportId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SemVer")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("RiskReportId");

                    b.HasAnnotation("Relational:TableName", "RiskReport");
                });

            modelBuilder.Entity("KYC.Web.Models.KYC.RiskReportItem", b =>
                {
                    b.Property<int>("RiskReportId");

                    b.Property<int>("RiskItemId");

                    b.HasKey("RiskReportId", "RiskItemId");
                });

            modelBuilder.Entity("KYC.Web.Models.KYC.CustomerRiskAssessment", b =>
                {
                    b.HasOne("KYC.Web.Models.KYC.Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("KYC.Web.Models.KYC.RiskReport")
                        .WithMany()
                        .HasForeignKey("RiskReportId");
                });

            modelBuilder.Entity("KYC.Web.Models.KYC.RiskItem", b =>
                {
                    b.HasOne("KYC.Web.Models.KYC.CustomerRiskAssessment")
                        .WithMany()
                        .HasForeignKey("CustomerRiskAssessmentId");

                    b.HasOne("KYC.Web.Models.KYC.RiskCategory")
                        .WithMany()
                        .HasForeignKey("RiskCategoryId");

                    b.HasOne("KYC.Web.Models.KYC.RiskClass")
                        .WithMany()
                        .HasForeignKey("RiskClassId");

                    b.HasOne("KYC.Web.Models.KYC.RiskReport")
                        .WithMany()
                        .HasForeignKey("RiskReportRiskReportId");
                });

            modelBuilder.Entity("KYC.Web.Models.KYC.RiskReportItem", b =>
                {
                    b.HasOne("KYC.Web.Models.KYC.RiskItem")
                        .WithMany()
                        .HasForeignKey("RiskItemId");

                    b.HasOne("KYC.Web.Models.KYC.RiskReport")
                        .WithMany()
                        .HasForeignKey("RiskReportId");
                });
        }
    }
}
