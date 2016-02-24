namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("FinancialInstitution")]
  public partial class FinancialInstitution : CIPDetail
  {

    [Display(Name="Referred By")]
    public string ReferredBy { get; set; }

    [Display(Name="Parent Company")]
    public string ParentName { get; set; }

    public bool IsPrivateOwned { get; set; }
    public bool IsShellBank { get; set; }
    public bool IsSubsidiary { get; set; }

    [Display(Name = "Sovereign Entity")]
    public SovereignEntity SEType { get; set; }

    public int? PublicExchangeId { get; set; }
    public virtual PublicExchange PublicExchange { get; set; }
  }
}
