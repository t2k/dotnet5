using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyc.entities
{

  //static methods for Enum 
  public static class EnumExtension
  {
    /// <summary>
    /// use reflection to pick up the Display attribute
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string GetDisplayName(this System.Enum value)
    {
      return value.GetType().GetMember(value.ToString()).First().GetCustomAttribute<DisplayAttribute>().GetName();
    }


    /// <summary>
    /// use reflection to return a int, string dictionary of an enum
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Dictionary<int, string> ToDisplayDict<T>() where T : struct
    {
      var values = Enum.GetValues(typeof(T));
      Dictionary<int, string> dict = new Dictionary<int, string>();

      foreach (Enum value in values)
      {
        dict.Add(Convert.ToInt32(value), value.GetDisplayName());
      }
      return dict;
    }
   //   }
      //return ((IEnumerable<T>)Enum.GetValues(typeof(T))).ToDictionary(item => Convert.ToInt32(item), item => item.GetDisplayName());
      //return ((IEnumerable<T>)Enum.GetValues(typeof(T))).ToDictionary(item => Convert.ToInt32(item), item => item.);
   // }

  }


  /// <summary>
  /// Customer Identification Program Types
  /// </summary>
  public enum CIPType
  {
    [Display(Name = "Financial Institution")]
    FI,
    [Display(Name = "Legal Entity Public")]
    LEPublic,
    [Display(Name = "Legal Entity Private")]
    LEPrivate
  }


  /// <summary>
  /// Customer Document Status
  /// </summary>
  public enum CustomerDocumentStatus
  {
    Attached,
    Detached
  }



  /// <summary>
  /// Roles between customer and employee
  /// </summary>
  public enum EmployeeCustomerRole
  {
    [Display(Name = "Account Manager")]
    AccountManager,
    [Display(Name = "Credit Officer")]
    CreditOfficer,
    [Display(Name = "Compliance Officer")]
    ComplianceOfficer
  }



  /// <summary>
  /// Event Codes
  /// </summary>
  public enum KYCEvent
  {
    Approved,
    Rejected,
    Activated,
    Inactivated,
    RiskRated,
    RoleSaved,
    CreditApproved,
    CreditRejected
  }


  /// <summary>
  /// Financial Institution Types
  /// </summary>
  public enum FIType
  {
    Bank,
    Broker,
    [Display(Name = "Insurance Co")]
    InsuranceCo,
    Fund
  }

  /// <summary>
  /// 
  /// </summary>
  public enum Identifier
  {
    [Display(Name = "IRS No")]
    IRSNo,
    [Display(Name = "EIN ID No")]
    EIN_ID_No,
    [Display(Name = "Govt Issued No")]
    GovIssuedNo
  }

  /// <summary>
  /// Phone Attribute
  /// </summary>
  public enum PhoneType
  {
    work,
    mobile,
    fax,
    home,
    other
  }


  /// <summary>
  /// Sovereign Attributes
  /// </summary>
  public enum SovereignEntity
  {
    Government,
    [Display(Name = "United Nations")]
    UnitedNations,
    [Display(Name = "Not Applicable")]
    NotApplicable
  }


  /// <summary>
  /// System Interfaces
  /// </summary>
  public enum KYCSystemInterface
  {
    Murex,
    SAP
  }


  /// <summary>
  /// Employee Status
  /// </summary>
  public enum EmployeeStatus
  {
    Active,
    Inactive
  }


  /// <summary>
  /// SAP attributes
  /// </summary>
  public enum SAPSpecType
  {
    [Display(Name = "Other Credit Institute")]
    OKIS,
    [Display(Name = "Other Enterprise")]
    OUNU,
    [Display(Name = "Not Assigned")]
    NA
  }

  /// <summary>
  /// Document Choice
  /// </summary>
  public enum DocumentChoice
  {
    Optional,
    Required
  }


  /// <summary>
  /// Geographic Risk types
  /// </summary>
  public enum GeoRisk
  {
    Low,
    Medium,
    High
  }


  /// <summary>
  /// Address Location Type
  /// </summary>
  public enum LocationType
  {
    [Display(Name = "Legal Address")]
    Legal,

    [Display(Name = "Care Of Address")]
    CareOf,

    [Display(Name = "Home Address")]
    Home,

    [Display(Name = "Delivery Address")]
    Delivery,

    [Display(Name = "Other Address")]
    Other
  }

  /// <summary>
  /// Risk Assessment Compliance Status
  /// </summary>
  public enum RAComplianceStatus
  {
    Approved,

    [Display(Name = "Pending Approval")]
    Pending,

    [Display(Name = "Rejected")]
    Rejected,

    [Display(Name = "Rating Expired")]
    Expired
  }
}