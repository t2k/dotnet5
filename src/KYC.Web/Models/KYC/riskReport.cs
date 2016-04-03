namespace KYC.Web.Models.KYC
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    // using System.Data.Entity.Spatial;

    [Table("RiskReport")]
    public partial class RiskReport
    {
        public RiskReport()
        {
            RiskItems = new List<RiskItem>();
            RiskReportItems = new List<RiskReportItem>();
        }
        public int RiskReportId { get; set; }

        [Required, DataType(DataType.MultilineText), Display(Name = "Report Title")]
        public string Title { get; set; }

        [Required, Display(Name = "Version")]
        public string SemVer { get; set; }

        public virtual List<RiskItem> RiskItems { get; set; }
        public virtual List<RiskReportItem> RiskReportItems { get; set; }
    }
}