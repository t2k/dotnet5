namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  [Table("Event")]
  public partial class Event
  {
    public int Id { get; set; }

    [Required]
    public KYCEvent Type { get; set; }
    public DateTime Timestamp { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public virtual ICollection<Customer> Customers { get; set; }
  }
}
