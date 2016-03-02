namespace KYC.Entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  [Table("Note")]
  public partial class Note
  {
    public int Id { get; set; }

    [DataType(DataType.MultilineText)]
    public string Comment { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public DateTime Timestamp { get; set; }
   
    public virtual ICollection<Customer> Customers { get; set; }
  }
}
