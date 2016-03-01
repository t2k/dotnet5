namespace KYC.Entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  public partial class SAPLegalForm
  {
    public SAPLegalForm()
    {
      this.SAPDetails = new HashSet<CustomerSAPDetail>();
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name="Legal Form"), StringLength(3)]
    public string Id { get; set; }

    [Required, DataType(DataType.MultilineText), Display(Name="English"), StringLength(60)]
    public string DescriptionEnglish { get; set; }

    [Required, DataType(DataType.MultilineText), Display(Name = "German"), StringLength(60)]
    public string DescriptionGerman { get; set; }


    public virtual ICollection<CustomerSAPDetail> SAPDetails { get; set; }
  }
}