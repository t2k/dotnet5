namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  
  public partial class GeographicRiskRating
  {
    public GeographicRiskRating()
    {
      this.Customers = new HashSet<Customer>();
    }

    [Key]
    public int Id { get; set; }

    [Required, Display(Name="Country Name")]
    public string Country { get; set; }

    [Required, Display(Name = "Risk Class US")]
    public GeoRisk RiskClassUS { get; set; }

    [Display(Name = "Rating Date")]
    public DateTime? RatingDate { get; set; }

    [Display(Name="Risk Score"), Range(1,100)]
    public int RiskScore { get; set; }

    public virtual ICollection<Customer> Customers { get; set; }
  }
}