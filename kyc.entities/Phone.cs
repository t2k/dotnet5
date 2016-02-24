namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  /// <summary>
  /// The Phone table with M-1 rel to person
  /// </summary>
  [Table("Phone")]
  public partial class Phone
  {
    public int Id { get; set; }

    [Required]
    public PhoneType Type { get; set; }

    [Required, DataType(DataType.PhoneNumber)]
    public string Number { get; set; }

  }
}
