namespace KYC.Entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("CustomerRiskAssessment")]
  public partial class CustomerRiskAssessment
  {
    /// <summary>
    /// identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// the list of assessed risk items
    /// </summary>
    public CustomerRiskAssessment()
    {
      AssessedRiskItems = new List<RiskItem>();
    }

    /// <summary>
    /// customerID foreign key
    /// </summary>
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    /// <summary>
    /// Report ID foreign Key
    /// </summary>
    [ForeignKey("RiskReport"), Display(Name = "Risk Report")]
    public int RiskReportId { get; set; }
    public virtual RiskReport RiskReport { get; set; }

    [Display(Name = "Assessment Date")]
    public DateTime AssessmentDate { get; set; }

    [Display(Name = "Next Review Date")]
    public DateTime? NextReviewDate { get; set; }

    [Display(Name = "Approval Date")]
    public DateTime? DateApprovalDate { get; set; }

    [Display(Name = "Risk Score")]
    public int? CustomerRiskScore { get; set; }

    public int AssessorId { get; set; }
    [ForeignKey("AssessorId"), Display(Name = "Assessed By")]
    public virtual Employee Assessor { get; set; }

    public int ApproverId { get; set; }
    [ForeignKey("ApproverId"), Display(Name = "Approved By")]
    public virtual Employee Approver { get; set; }

    [Display(Name = "Assessed Items")]
    public int AssessedCount
    {
      get
      {
        return AssessedRiskItems != null ? AssessedRiskItems.Count : 0;
      }
    }


    public RAComplianceStatus Status
    {
      get; set;
    }

    [Display(Name = "Risk Classification")]
    public string Classification
    {
      get
      {
        var score = CustomerRiskScore;

        if (!score.HasValue || score.Value <= 0)
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
    public virtual ICollection<RiskItem> AssessedRiskItems { get; set; }
  }
}