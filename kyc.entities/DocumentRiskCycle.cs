namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  [Table("DocumentRiskCycle")]
  public partial class DocumentRiskCycle
  {
    [Key, Display(Name = "Risk Class"), Column(Order = 1), Required]
    public int RiskClassId { get; set; }
    public RiskClass RiskClass { get; set; }

    [Key, Display(Name = "Document Type"), Column(Order = 2), Required]
    public int DocumentTypeId { get; set; }
    public DocumentType DocumentType { get; set; }


    [Key, Column(Order = 3), Required, StringLength(3), RegularExpression(@"(\d{1,2}?[YM])", ErrorMessage="input pattern: 1Y, 2Y, 36M, etc"), Display(Name = "Cycle")]
    public string Cycle { get; set; }

  }
}