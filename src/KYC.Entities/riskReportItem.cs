namespace KYC.Entities
{
  public partial class RiskReportItem
  {
    public int RiskReportId { get; set; }
    public RiskReport RiskReport {get;set;}
    
    public int RiskItemId { get; set; }
    public RiskItem RiskItem {get;set;}
  }
}