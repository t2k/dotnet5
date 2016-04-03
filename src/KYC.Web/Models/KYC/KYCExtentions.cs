using System;
using System.Linq;
using Microsoft.Data.Entity;
using System.Collections.Generic;

namespace KYC.Web.Models.KYC
{
    public static class KYCExtensions
    {
        public static void EnsureSeedData(this KYCContext context)
        {
            if (context.AllMigrationsApplied())
            {
                if (!context.RiskClasses.Any())
                {
                    context.RiskClasses.Add(new RiskClass { Classification = "High", Ordinal = 1 });
                    context.RiskClasses.Add(new RiskClass { Classification = "Medium", Ordinal = 2 });
                    context.RiskClasses.Add(new RiskClass { Classification = "Low", Ordinal = 3 });

                    // ENTITY risk category
                    context.RiskCategories.Add(new RiskCategory { CategoryName = "Description of Business", Ordinal = 1 });
                    context.RiskCategories.Add(new RiskCategory { CategoryName = "Transaction Type", Ordinal = 2 });
                    context.RiskCategories.Add(new RiskCategory { CategoryName = "Credit Facility", Ordinal = 3 });
                    context.RiskCategories.Add(new RiskCategory { CategoryName = "Geographic Risk Country", Ordinal = 4 });
                    context.RiskCategories.Add(new RiskCategory { CategoryName = "Customer Relationship", Ordinal = 5 });
                    context.RiskCategories.Add(new RiskCategory { CategoryName = "Reputation/Regulatory/Legal Risk", Ordinal = 6 });

                    context.SaveChanges();

                    List<RiskItem> riskItems = new List<RiskItem>();

                    //ENTITY RISKITEM
                    // Cat 1; High
                    riskItems.Add(new RiskItem { Description = "Foreign banks", RiskCategoryId = 1, RiskClassId = 1, Score = 35 });
                    riskItems.Add(new RiskItem { Description = "Collection accounts", RiskCategoryId = 1, RiskClassId = 1, Score = 30 });
                    riskItems.Add(new RiskItem { Description = "Off-shore activities", RiskCategoryId = 1, RiskClassId = 1, Score = 30 });
                    riskItems.Add(new RiskItem { Description = "Import and export companies", RiskCategoryId = 1, RiskClassId = 1, Score = 30 });
                    riskItems.Add(new RiskItem { Description = "High-risk country governments/Private companies", RiskCategoryId = 1, RiskClassId = 1, Score = 30 });
                    riskItems.Add(new RiskItem { Description = "PICs offshore", RiskCategoryId = 1, RiskClassId = 1, Score = 30 });
                    riskItems.Add(new RiskItem { Description = "Sellers of luxury items (i.e. jewelry)", RiskCategoryId = 1, RiskClassId = 1, Score = 30 });
                    riskItems.Add(new RiskItem { Description = "Gambling and other cash businesses", RiskCategoryId = 1, RiskClassId = 1, Score = 30 });
                    riskItems.Add(new RiskItem { Description = "Professionals (CPAs, doctors, etc.)", RiskCategoryId = 1, RiskClassId = 1, Score = 30 });
                    riskItems.Add(new RiskItem { Description = "Insurance companies", RiskCategoryId = 1, RiskClassId = 1, Score = 30 });
                    riskItems.Add(new RiskItem { Description = "Brokers", RiskCategoryId = 1, RiskClassId = 1, Score = 30 });
                    riskItems.Add(new RiskItem { Description = "REITs/Real estate holding companies", RiskCategoryId = 1, RiskClassId = 1, Score = 30 });

                    // Cat 1; Medium
                    riskItems.Add(new RiskItem { Description = "Public companies not listed on an approved exchange", RiskCategoryId = 1, RiskClassId = 2, Score = 20 });
                    riskItems.Add(new RiskItem { Description = "Private companies", RiskCategoryId = 1, RiskClassId = 2, Score = 20 });
                    riskItems.Add(new RiskItem { Description = "Foreign Fund", RiskCategoryId = 1, RiskClassId = 2, Score = 20 });
                    riskItems.Add(new RiskItem { Description = "Medium-risk country governments", RiskCategoryId = 1, RiskClassId = 2, Score = 20 });
                    riskItems.Add(new RiskItem { Description = "United Nations", RiskCategoryId = 1, RiskClassId = 2, Score = 20 });

                    // Cat 1; Low
                    riskItems.Add(new RiskItem { Description = "Banks or brokers regulated by a U.S. regulator", RiskCategoryId = 1, RiskClassId = 3, Score = 10 });
                    riskItems.Add(new RiskItem { Description = "Domestic Fund", RiskCategoryId = 1, RiskClassId = 3, Score = 10 });
                    riskItems.Add(new RiskItem { Description = "Public corporations listed on an approved exchange", RiskCategoryId = 1, RiskClassId = 3, Score = 10 });
                    riskItems.Add(new RiskItem { Description = "Low-risk country governments", RiskCategoryId = 1, RiskClassId = 3, Score = 10 });
                    riskItems.Add(new RiskItem { Description = "Foreign central bank", RiskCategoryId = 1, RiskClassId = 3, Score = 10 });

                    // Cat 2; High
                    riskItems.Add(new RiskItem { Description = "Correspondent banks", RiskCategoryId = 2, RiskClassId = 1, Score = 30 });
                    riskItems.Add(new RiskItem { Description = "International wire activity", RiskCategoryId = 2, RiskClassId = 1, Score = 30 });
                    riskItems.Add(new RiskItem { Description = "Cash activity", RiskCategoryId = 2, RiskClassId = 1, Score = 30 });
                    riskItems.Add(new RiskItem { Description = "Trust accounts/custody/escrow", RiskCategoryId = 2, RiskClassId = 1, Score = 30 });
                    riskItems.Add(new RiskItem { Description = "Treasury and FOREX activities (non bank-to-bank)", RiskCategoryId = 2, RiskClassId = 1, Score = 30 });

                    // Cat 2; Medium
                    riskItems.Add(new RiskItem { Description = "Check deposits/withdrawals 51-100 items per month ", RiskCategoryId = 2, RiskClassId = 2, Score = 20 });
                    riskItems.Add(new RiskItem { Description = "Domestic wire transfers in/out 10-20 per month ", RiskCategoryId = 2, RiskClassId = 2, Score = 20 });

                    // Cat 2; Class=3(Low)
                    riskItems.Add(new RiskItem { Description = "Check deposits/ withdrawals 1-50 items per month", RiskCategoryId = 2, RiskClassId = 3, Score = 10 });
                    riskItems.Add(new RiskItem { Description = "Time deposits/money market deposits", RiskCategoryId = 2, RiskClassId = 3, Score = 10 });
                    riskItems.Add(new RiskItem { Description = "Domestic wire transfers in/out 1-10 per month", RiskCategoryId = 2, RiskClassId = 3, Score = 10 });
                    riskItems.Add(new RiskItem { Description = "Cash management functions", RiskCategoryId = 2, RiskClassId = 3, Score = 10 });
                    riskItems.Add(new RiskItem { Description = "Sale of own Commercial Paper", RiskCategoryId = 2, RiskClassId = 3, Score = 10 });
                    riskItems.Add(new RiskItem { Description = "Treasury and FOREX activities (bank-to-bank", RiskCategoryId = 2, RiskClassId = 3, Score = 10 });

                    // Cat 3; class=1 High
                    riskItems.Add(new RiskItem { Description = "International L/C's -Trade finance (privately entities) ", RiskCategoryId = 3, RiskClassId = 1, Score = 30 });
                    riskItems.Add(new RiskItem { Description = "Cash-secured loans", RiskCategoryId = 3, RiskClassId = 1, Score = 30 });

                    // Cat 3; class=2 Medium
                    riskItems.Add(new RiskItem { Description = "Syndicated loans agented by a bank abroad", RiskCategoryId = 3, RiskClassId = 2, Score = 20 });

                    // Cat 3; class=3 Low
                    riskItems.Add(new RiskItem { Description = "Corporate loans", RiskCategoryId = 3, RiskClassId = 3, Score = 10 });
                    riskItems.Add(new RiskItem { Description = "Revolving Lines of Credit", RiskCategoryId = 3, RiskClassId = 3, Score = 10 });
                    riskItems.Add(new RiskItem { Description = "Syndicated loans agented by a bank in the US", RiskCategoryId = 3, RiskClassId = 3, Score = 10 });
                    riskItems.Add(new RiskItem { Description = "Publicly-traded company commercial L/Cs", RiskCategoryId = 3, RiskClassId = 3, Score = 10 });
                    riskItems.Add(new RiskItem { Description = "Standby L/Cs", RiskCategoryId = 3, RiskClassId = 3, Score = 10 });
                    riskItems.Add(new RiskItem { Description = "Commercial mortgage loans", RiskCategoryId = 3, RiskClassId = 3, Score = 10 });

                    // Cat 4; class=1 High
                    riskItems.Add(new RiskItem { Description = "FAFT current list of NCCT countries", RiskCategoryId = 4, RiskClassId = 1, Score = 30 });
                    riskItems.Add(new RiskItem { Description = "OFAC countries and SDN list", RiskCategoryId = 4, RiskClassId = 1, Score = 30 });
                    riskItems.Add(new RiskItem { Description = "Other government lists and sanctions", RiskCategoryId = 4, RiskClassId = 1, Score = 30 });
                    riskItems.Add(new RiskItem { Description = "Countries rated High Risk on AML Geo risk", RiskCategoryId = 4, RiskClassId = 1, Score = 30 });

                    // Cat 4; class=2 Medium
                    riskItems.Add(new RiskItem { Description = "Countries rated Medium Risk on AML Geo risk", RiskCategoryId = 4, RiskClassId = 2, Score = 20 });

                    // Cat 4; class=3 Low
                    riskItems.Add(new RiskItem { Description = "Countries rated Low Risk on AML Geo risk", RiskCategoryId = 4, RiskClassId = 3, Score = 10 });

                    // Cat 5; class=1 High
                    riskItems.Add(new RiskItem { Description = "Under 2 years", RiskCategoryId = 5, RiskClassId = 1, Score = 20 });

                    // Cat 5; class=2 Medium
                    riskItems.Add(new RiskItem { Description = "2 – 5 years ", RiskCategoryId = 5, RiskClassId = 2, Score = 10 });

                    // Cat 5; class=3 Low
                    riskItems.Add(new RiskItem { Description = "Over 5 years", RiskCategoryId = 5, RiskClassId = 3, Score = 0 });
                    riskItems.Add(new RiskItem { Description = "Under 5 years for subsidiaries under common management with a parent that has a relationship with Branch over 5 years", RiskCategoryId = 5, RiskClassId = 3, Score = 0 });

                    // Cat 6; class=1 High
                    riskItems.Add(new RiskItem { Description = "Bad press", RiskCategoryId = 6, RiskClassId = 1, Score = 20 });
                    riskItems.Add(new RiskItem { Description = "PEP - Auto High Risk Categorization ", RiskCategoryId = 6, RiskClassId = 1, Score = 100 });
                    riskItems.Add(new RiskItem { Description = "Regulatory filing (SAR)  - Auto High Risk Categorization ", RiskCategoryId = 6, RiskClassId = 1, Score = 100 });
                    riskItems.Add(new RiskItem { Description = "Government issued subpoena  - Auto High Risk Categorization ", RiskCategoryId = 6, RiskClassId = 1, Score = 100 });

                    // Cat 6; class=2 Medium
                    riskItems.Add(new RiskItem { Description = "Bad press/Reg GG", RiskCategoryId = 6, RiskClassId = 2, Score = 10 });

                    // Cat 6; class=3 Low
                    riskItems.Add(new RiskItem { Description = "Bad press", RiskCategoryId = 6, RiskClassId = 3, Score = 0 });

                    // NEWLY ADDED after original 60 items
                    riskItems.Add(new RiskItem { Description = "Reg GG", RiskCategoryId = 6, RiskClassId = 3, Score = 0 });
                    riskItems.Add(new RiskItem { Description = "Reg GG", RiskCategoryId = 6, RiskClassId = 2, Score = 10 });
                    riskItems.Add(new RiskItem { Description = "Reg GG", RiskCategoryId = 6, RiskClassId = 1, Score = 20 });

                    // boom!!!
                    //riskItems.ForEach(r => context.RiskItems.Add(r));
                    context.RiskItems.AddRange(riskItems);
                    context.SaveChanges();
                    Console.WriteLine($"Saved {riskItems.Count} riskitems");


                    RiskReport report = new RiskReport();
                    report.Title = "DZ Bank New York: Risk Rating Report";
                    report.SemVer = "v1.0.0";
                    riskItems.ForEach(i => report.RiskItems.Add(i));
                    context.SaveChanges();
                    //riskItems.ForEach(i => report.RiskReportItems.Add( new RiskReportItem { RiskReportId=report.RiskReportId, RiskItemId= i.Id}));

                    //RiskReport report2 = new RiskReport();
                    //report2.Title = "DZ Bank New York: Risk Rating Report#2";
                    //report2.SemVer = "v1.0.1";
                    //riskItems.Where(i=>i.Id>10).ToList().ForEach(i => report2.RiskItems.Add(i));
                    //riskItems.Where(i=>i.Id>10).ToList().ForEach(i => report2.RiskReportItems.Add( new RiskReportItem { RiskReportId=report2.RiskReportId, RiskItemId= i.Id}));

                    
                    Console.WriteLine($"Risk Report is created on the stack, now saving...");
                    context.RiskReports.Add(report);
                    context.SaveChanges();
                    
                    Console.WriteLine($"report has {report.RiskItems.Count} items");
                    //context.RiskReports.Add(report2);
                    //Console.WriteLine($"report has {report2.RiskItems.Count} items");
                    //context.SaveChanges();
                    Console.WriteLine($"Reports saved like a boss!");
                    
                    //var tmp = context.RiskReports.Include(i => i.RiskItems).Include(i => i.RiskReportItems).ToList();
                    //tmp.ForEach(i=> Console.WriteLine($"{i.Title} has {i.RiskItems.Count} RiskItems and {i.RiskReportItems.Count} RiskReportItmes"));

                }

            }
        }
    }
}