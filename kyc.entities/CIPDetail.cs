namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("CIPDetail")]
  public class CIPDetail
  {
    public CIPDetail()
    {
      CoIdentifiers = new HashSet<PublicIdentifier>();
    }

    [Key, ForeignKey("Customer")]
    public int CustomerId { get; set; }

    [Display(Name="Account Purpose"), DataType(DataType.MultilineText)]
    public string AccountPurpose { get; set; }

    [Display(Name="Nature of Business"), DataType(DataType.MultilineText)]

    public string NatureOfBusiness { get; set; }

    [Display(Name = "Existing Relationship")]
    public bool ExistingRelationship { get; set; }

    [Display(Name = "KYC Notification Given")]
    public bool NotificationGiven { get; set; }

    [Display(Name = "Regulatin GG Certification")]
    public bool RegGgGiven { get; set; }

    public virtual ICollection<PublicIdentifier> CoIdentifiers { get; set; }
    public virtual Customer Customer { get; set; }
  }
}