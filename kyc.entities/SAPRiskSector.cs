namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  public partial class SAPRiskSector
  {

    public SAPRiskSector()
    {
      SAPDetails = new HashSet<CustomerSAPDetail>();
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Sector Code"), StringLength(8)]
    public string SAPRiskSectorId { get; set; }

    [Required, Display(Name = "Risk Sector Description"), StringLength(100)]
    public string Description { get; set; }

    public virtual ICollection<CustomerSAPDetail> SAPDetails { get; set; }
  }
}