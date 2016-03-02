namespace KYC.Entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  [Table("Employee")]
  public partial class Employee : Person
  {

    [Required]
    public EmployeeStatus Status { get; set; }

    [DataType(DataType.DateTime)]
    [Display(Name="Active Date")]
    public DateTime ActiveDate { get; set; }

    public IEnumerable<CustomerEmployeeRole> CustomerRoles { get; set; }

  }
}