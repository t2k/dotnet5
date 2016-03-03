namespace KYC.Entities
{
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  [Table("Customer")]
  public partial class Customer
  {

    [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Customer No")]
    public int CustomerId { get; set; }
    [Display(Name="Customer Type")]
    public CIPType Type { get; set; }

    [Display(Name = "Country of Risk")]
    public int? GeographicRiskRatingId { get; set; }
    public  GeographicRiskRating GeographicRiskRating { get; set; }

    [Display(Name="Department Owner")]
    public int? DepartmentId { get; set; }
    public  Department Department { get; set; }

    // one to one sub schemas
    [ScaffoldColumn(false)]
    public int CIPDetailId { get; set; }
    public CIPDetail CIPDetail { get; set; }
    // save public int CustomerAddressId { get; set; }
    // save public virtual CustomerAddress CustomerAddress { get; set; }
    // save public int CustomerOwnershipId { get; set; }
    // save public virtual CustomerOwnership CustomerOwnership { get; set; }
    [ScaffoldColumn(false)]
    public int SAPDetailsId { get; set; }
    
    
    public CustomerSAPDetail SAPDetail { get; set; }

    public virtual List<CustomerRiskAssessment> CustomerRiskReports {get;set;}
    public virtual List<Interface> Interfaces { get; set; }

    public virtual List<CustomerRiskAssessment> CustomerRiskReports { get; set; }

    public virtual List<Event> Events { get; set; }

    public virtual List<Note> Notes { get; set; }

    public virtual List<Location> Locations { get; set; }
    public virtual List<CustomerDocument> Documents { get; set; }
  }
}