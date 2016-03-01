namespace KYC.Entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;


  public class CustomerSAPDetail
  {
    [Key, ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    //lookup table
    [Display(Name = "SAP: BP Status")]
    public string SAPBPStatusId { get; set; }
    public virtual SAPBPStatus BPStatus { get; set; }

    //lookup table
    [Display(Name = "SAP: Legal Form")]
    public int? SAPLegalFormId { get; set; }
    public virtual SAPLegalForm LegalForm { get; set; }


    //lookup table
    [Display(Name = "SAP: Country")]
    public string SAPCountryId { get; set; }
    public virtual SAPCountry Country { get; set; }

    //lookup table
    [Display(Name = "SAP: Legal Entity")]
    public string SAPLegalEntityId { get; set; }
    public virtual SAPLegalEntity LegalEntity { get; set; }

    //lookup table
    [Display(Name = "SAP: Risk Sector")]
    public string SAPRiskSectorId { get; set; }
    public virtual SAPRiskSector RiskSector { get; set; }

    //lookup table
    [Display(Name = "SAP: Systematic")]
    public string SAPSystematicId { get; set; }
    public virtual SAPSystematic Systematic { get; set; }

    //lookup table
    [Display(Name = "SAP: Industry")]
    public string SAPIndustryId { get; set; }
    public virtual SAPIndustry Industry { get; set; }

    [Display(Name = "SAP: Specification Type")]
    public SAPSpecType SpecType { get; set; }


  }
}