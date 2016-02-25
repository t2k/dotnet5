namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  public partial class SAPIndustry
  {
    public SAPIndustry()
    {
      SAPDetails = new HashSet<CustomerSAPDetail>();
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Industry Code"), Required, StringLength(6)]
    public string Id { get; set; }

    [Required, Display(Name = "Industry Description")]
    public string Description { get; set; }

    public virtual ICollection<CustomerSAPDetail> SAPDetails { get; set; }
  }
}