namespace KYC.Entities
{
  using System;
  using System.ComponentModel.DataAnnotations;
  //using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  //[Table("Event")]
  public partial class Event
  {
    public int Id { get; set; }

    [Required]
    public KYCEvent Type { get; set; }
    public DateTime Timestamp { get; set; }
    public int CustomerId {get;set;}
    public Customer Customer { get; set; }
  }
}
