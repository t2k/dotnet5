namespace KYC.Entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  public partial class SAPCountry
  {

    public SAPCountry()
    {
      SAPDetails = new HashSet<CustomerSAPDetail>();
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "SAP Code"), StringLength(2)]
    public string Id { get; set; }

    [Required, Display(Name = "Country Name")]
    public string Country { get; set; }

    public virtual ICollection<CustomerSAPDetail> SAPDetails { get; set; }

  }
}