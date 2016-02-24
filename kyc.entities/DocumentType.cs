namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("DocumentType")]
  public partial class DocumentType
  {
    public int Id { get; set; }

    [Required, Display(Name="Description")]
    public string Description { get; set; }

    /// <summary>
    /// many to many
    /// </summary>
    public virtual ICollection<CustomerDocument> CustomerDocuments { get; set; }
  }
}