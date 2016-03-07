namespace KYC.Web.Models.KYC
{
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  

  [Table("Customer")]
  public partial class Customer
  {
  
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Customer No")]
    public int Id { get; set; }
  
    [Display(Name="Customer Type")]
    public CIPType Type { get; set; }


    [Display(Name = "Country of Risk")]
    public int? GeographicRiskRatingId { get; set; }
    //public virtual GeographicRiskRating GeographicRiskRating { get; set; }

    [Display(Name="Department Owner")]
    public int? DepartmentId { get; set; }
    //public virtual Department Department { get; set; }


    // one to one sub schemas
    [ScaffoldColumn(false)]
    public int CIPDetailId { get; set; }
    //public virtual CIPDetail CIPDetail { get; set; }
    // save public int CustomerAddressId { get; set; }
    // save public virtual CustomerAddress CustomerAddress { get; set; }
    // save public int CustomerOwnershipId { get; set; }
    // save public virtual CustomerOwnership CustomerOwnership { get; set; }
    [ScaffoldColumn(false)]
    //public int SAPDetailsId { get; set; }
    //public virtual CustomerSAPDetail SAPDetail { get; set; }

   
    public virtual List<CustomerRiskAssessment> CustomerRiskReports { get; set; }

    //public virtual ICollection<Event> Events { get; set; }

    //public virtual ICollection<Note> Notes { get; set; }

    //public virtual ICollection<Location> Locations { get; set; }

    //public virtual ICollection<CustomerDocument> Documents { get; set; }
  }
}