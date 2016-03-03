namespace KYC.Entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;
/// <summary>
/// Many to Many Customer to Document  with extra storage
/// </summary>
  [Table("CustomerDocument")]
  public partial class CustomerDocument
  {
    public int Id { get; set; }

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public Guid DocumentId { get; set; }
    [ForeignKey("DocumentId")]
    public Document Document { get; set; }

    [Display(Name="Document Type")]
    public int DocumentTypeId { get; set; }
    public DocumentType DocumentType { get; set; }
    /// <summary>
    /// user string
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Attached or Detached
    /// </summary>
    public CustomerDocumentStatus Status { get; set; }
  }
}
