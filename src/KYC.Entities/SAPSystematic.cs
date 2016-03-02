namespace KYC.Entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  public partial class SAPSystematic
  {

    public SAPSystematic()
    {
      SAPDetails = new HashSet<CustomerSAPDetail>();
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Industry Code"), StringLength(5), Required]
    public string Id { get; set; }

    [Required, Display(Name = "Systematic Industry")]
    public string Description { get; set; }

    public virtual ICollection<CustomerSAPDetail> SAPDetails { get; set; }
  }
}