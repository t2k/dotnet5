namespace KYC.Entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;


  /// <summary>
  /// The Person table with 1-M reln to Phone
  /// </summary>
  [Table("Person")]
  public partial class Person
  {
    public Person()
    {
      this.Phones = new HashSet<Phone>();
    }
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required, DataType(DataType.EmailAddress)]
    public string Email { get; set; }
   
    public virtual ICollection<Phone> Phones { get; set; }
  }
}
