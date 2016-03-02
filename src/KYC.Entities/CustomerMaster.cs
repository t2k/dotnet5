namespace KYC.Entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;


  [Table("CustomerMaster")]
  public partial class CustomerMaster
  {
    [Display(Name = "Customer No"), Required]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int CustomerMasterId { get; set; }

    [Display(Name = "Customer Name"), Required]
    public string CustomerName { get; set; }


    [DataType(DataType.DateTime), ScaffoldColumn(false), Display(Name = "Date Created")]
    public DateTime? DateCreated { get; set; }

    [ScaffoldColumn(false), Display(Name = "KYC Status")]
    public string KYCStatus { get; set; }

    [ScaffoldColumn(false), Display(Name = "Credit Status")]
    public string CreditStatus { get; set; }

    [ScaffoldColumn(false), Display(Name = "Customer Status")]
    public string CustomerStatus { get; set; }

    [ScaffoldColumn(false)]
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
  }
}