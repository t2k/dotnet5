namespace KYC.Entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  [Table("RiskReport")]
  public partial class RiskReport
  {

    public int Id { get; set; }

    [Required, DataType(DataType.MultilineText), Display(Name = "Report Title")]
    public string Title { get; set; }


    [Required, Display(Name = "Version")]
    public string SemVer { get; set; }

    public List<RiskReportItem> RiskReportItems { get; set; }
  }
}