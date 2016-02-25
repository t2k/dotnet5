namespace kyc.entities
{
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;
  [Table("CustomerEmployeeAssignment")]
  public partial class CustomerEmployeeAssignment
  {
    public int Id { get; set; }

    public int CustomerID { get; set; }
    public int EmployeeId { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual Employee Employee { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }

  }
}
