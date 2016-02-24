namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("Document")]
  public partial class Document
  {
    public Document()
    {
      this.Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public string UserId { get; set; }
    public string PathSpec { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public Int64 ContentLength { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime TimeStamp { get; set; }


    // [DataType(DataType.Url)]
    // public string FileUrl { get; set; }

    public virtual ICollection<Customer> Customers { get; set; }
  }
}