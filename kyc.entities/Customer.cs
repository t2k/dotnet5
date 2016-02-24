namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("Customer")]
  public partial class Customer
  {
    public Customer()
    {
      this.KYCInterfaces = new HashSet<Interface>();
      this.CustomerRiskReports = new HashSet<CustomerRiskAssessment>();
      this.Events = new HashSet<Event>();
      this.Notes = new HashSet<Note>();
      this.Locations = new HashSet<Location>();
      this.Documents = new HashSet<CustomerDocument>();
    }

    [Key, ForeignKey("CustomerMaster"), DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Customer No")]
    public int CustomerId { get; set; }
    public virtual CustomerMaster CustomerMaster { get; set; }

    [Display(Name="Customer Type")]
    public CIPType Type { get; set; }


    [Display(Name = "Country of Risk")]
    public int? GeographicRiskRatingId { get; set; }
    public virtual GeographicRiskRating GeographicRiskRating { get; set; }

    [Display(Name="Department Owner")]
    public int? DepartmentId { get; set; }
    public virtual Department Department { get; set; }



    // one to one sub schemas
    [ScaffoldColumn(false)]
    public int CIPDetailId { get; set; }
    public virtual CIPDetail CIPDetail { get; set; }
    // save public int CustomerAddressId { get; set; }
    // save public virtual CustomerAddress CustomerAddress { get; set; }
    // save public int CustomerOwnershipId { get; set; }
    // save public virtual CustomerOwnership CustomerOwnership { get; set; }
    [ScaffoldColumn(false)]
    public int SAPDetailsId { get; set; }
    public virtual CustomerSAPDetail SAPDetail { get; set; }

   

    /// <summary>
    /// external interface identifiers: MUREX, SAP etc
    /// </summary>
 
    public virtual ICollection<Interface> KYCInterfaces { get; set; }

    /// <summary>
    /// Risk Assessements
    /// </summary>
    public virtual ICollection<CustomerRiskAssessment> CustomerRiskReports { get; set; }

    /// <summary>
    /// internal system events
    /// </summary>
    public virtual ICollection<Event> Events { get; set; }

    /// <summary>
    /// customer notes
    /// </summary>
    /// 
    public virtual ICollection<Note> Notes { get; set; }

    /// <summary>
    /// locations addresses etc
    /// </summary>
    public virtual ICollection<Location> Locations { get; set; }

    /// <summary>
    /// document storage
    /// </summary>
    public virtual ICollection<CustomerDocument> Documents { get; set; }
  }
}