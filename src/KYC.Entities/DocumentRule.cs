namespace KYC.Entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  public partial class DocumentRule
  {
    [Key]
    public int Id { get; set; }

    [Display(Name = "Customer Type")]
    public CIPType CIPType { get; set; }

    [ForeignKey("DocumentType"), Display(Name = "Document Type")]
    public int DocumentTypeId { get; set; }
    public DocumentType DocumentType { get; set; }

    public DocumentChoice Choice { get; set; }
  }
}