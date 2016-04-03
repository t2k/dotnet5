
namespace KYC.Web.Models.KYC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CustomerRiskAssessment")]
    public partial class CustomerRiskAssessment
    {
        private const int DEFAULT_SCORE = 0;

        /// <summary>
        /// identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// the list of assessed risk items
        /// </summary>

        /// <summary>
        /// customerID foreign key
        /// </summary>
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        /// <summary>
        /// Report ID foreign Key
        /// </summary>
        public int RiskReportId { get; set; }
        [ForeignKey("RiskReportId"), Display(Name = "Risk Report")]
        public virtual RiskReport RiskReport { get; set; }

        [Display(Name = "Assessment Date")]
        public DateTime AssessmentDate { get; set; }


        [DefaultValueAttribute(DEFAULT_SCORE), Display(Name = "Risk Score")]
        public int CustomerRiskScore { get; set; }

        [Display(Name = "Assessed Items")]
        public int AssessedCount
        {
            get
            {
                return AssessedRiskItems != null ? AssessedRiskItems.Count : 0;
            }
        }

        public RAComplianceStatus Status { get; set; }

        [Display(Name = "Risk Classification")]
        public string Classification
        {
            get
            {
                var score = CustomerRiskScore;

                if (score == 0)
                {
                    return "Not rated";
                }
                else if (score <= 60)
                {
                    return "Low Risk";
                }
                else if (score <= 100)
                {
                    return "Medium Risk";
                }
                else
                { return "High Risk"; }
            }
        }

        /// <summary>
        /// user assessed risk items
        /// </summary>
        public List<RiskItem> AssessedRiskItems { get; set; }
    }
}