using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KYC.Web.Models;
using KYC.DbOld;
using KYC.Entities;
using KYC.Web.DataContext;


namespace KYC.Web.Areas.Admin
{
  public class DataMigrateController : Controller
  {
    private KYCDb db = new KYCDb();
    private KYC_OldDb oldDb = new KYC_OldDb();


    // GET: Admin/DataMigrate
    public ActionResult Index()
    {
      return View();
    }

    // GET: Admin/DataMigrate
    public ActionResult DoEmployee()
    {

      var bu = oldDb.BranchUsers.Where(b=>b.Status=="1"&& b.Email!=null).ToList();
      foreach (var b in bu)
      {
        var emp = new Employee()
        {
          Name = string.Format("{0} {1}", b.FirstName, b.LastName),
          Email = b.Email,
          Status= EmployeeStatus.Active,
          ActiveDate = DateTime.Today

        };
        db.Employees.Add(emp);
      }
      db.SaveChanges();
      // proocess employee migration here...
      return RedirectToAction("Index");

    }

    public ActionResult DoRiskMigration()
    {
      KYCDbInitializer init = new KYCDbInitializer();

      // proocess Other migration here...
      init.MigrateRiskRatings(db, oldDb);
      return RedirectToAction("Index");

    }

    public ActionResult DoDocumentMigration()
    {
      KYCDbInitializer init = new KYCDbInitializer();

      init.MigrateCustomerDocuments(db, oldDb);
      return RedirectToAction("Index");

    }


  }
}