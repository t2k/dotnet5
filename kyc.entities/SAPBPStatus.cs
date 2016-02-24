namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  public partial class SAPBPStatus
  {
    public SAPBPStatus()
    {
      SAPDetails = new HashSet<CustomerSAPDetail>();
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "BP Status Code"), Required, MaxLength(4)]
    public string Id { get; set; }

    [Required]
    public string Description { get; set; }

    public virtual ICollection<CustomerSAPDetail> SAPDetails { get; set; }

  }
}