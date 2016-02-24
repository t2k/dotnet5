namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("RiskReport")]
  public partial class RiskReport
  {
    public RiskReport()
    {
      this.RiskItems = new HashSet<RiskItem>();
      this.CustomerRiskReports = new HashSet<CustomerRiskAssessment>();
    }

    public int Id { get; set; }

    [Required, DataType(DataType.MultilineText), Display(Name = "Report Title")]
    public string Title { get; set; }


    [Required, Display(Name = "Version")]
    public string SemVer { get; set; }

    public virtual ICollection<RiskItem> RiskItems { get; set; }
    public virtual ICollection<CustomerRiskAssessment> CustomerRiskReports { get; set; }


  }
}