namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("CustomerOwnership")]
  public partial class CustomerOwnership
  {

    [Key, ForeignKey("Customer"), DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int CustomerID { get; set; }
    public virtual Customer Customer { get; set; }

    [Display(Name="Owner")]
    public int? DepartmentId { get; set; }
    public virtual Department Department { get; set; }

    public virtual IEnumerable<CustomerEmployeeRole> Employees { get; set; }
  }
}
