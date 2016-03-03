namespace KYC.Entities
{
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  [Table("Interface")]
  public partial class Interface
  {
    public int Id { get; set; }

    [Required, Display(Name="KYC-API")]
    public KYCSystemInterface Name { get; set; }

    [Required, DataType(DataType.MultilineText)]
    public string Description { get; set; }

    public int CustomerId {get;set;}
    public Customer Customer { get; set; }
  }
}
