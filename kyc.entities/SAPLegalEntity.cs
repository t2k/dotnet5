namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  public partial class SAPLegalEntity
  {
    public SAPLegalEntity()
    {
      SAPDetails = new HashSet<CustomerSAPDetail>();
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.None), StringLength(2)]
    public string Id { get; set; }

    [Required]
    public string Description { get; set; }

    public virtual ICollection<CustomerSAPDetail> SAPDetails { get; set; }

  }
}