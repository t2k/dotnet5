using System.Collections.Generic;
using KYC.Web.Models.KYC;

namespace KYC.Web.ViewModels.Risk
{
    public class RiskReportViewModel
    {
        public RiskReport riskReport {get;set;}
        public List<RiskClass> reportClasses {get;set;}
        public List<RiskCategory> reportCategories {get;set;}
        
    }
}
