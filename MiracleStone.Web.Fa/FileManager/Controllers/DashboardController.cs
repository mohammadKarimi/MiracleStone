using MiracleStone.Data.Context;
using MiracleStone.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiracleStone.Web.Controllers
{
    public partial class DashboardController : Controller
    {
        private readonly MiracleStoneDbContext db = new MiracleStoneDbContext();

        public virtual ViewResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult SignIn(TblUser model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (db.TblUser.Where(X => X.UserName == model.UserName && X.Password == model.Password).FirstOrDefault() != null)
            {
                return RedirectToAction(MVC.Dashboard.ActionNames.ContactUs, MVC.Dashboard.Name);
            }
            else
            {
                ModelState.AddModelError("Password", "Invalid UserName Or Password");
            }
            return View(model);
        }

        public virtual ViewResult ContactUs()
        {
            return View(db.TblContactUs.Where(X => X.ParentID == null).OrderByDescending(X => X.TblContactUsID).ToList());
        }

        [HttpGet, Route("Dashboard/AnswerContact/{tblContactID:int}")]
        public virtual ActionResult AnswerContact(int tblContactID)
        {
            var Query = db.TblContactUs.Where(X => X.TblContactUsID == tblContactID).FirstOrDefault();
            if (Query == null)
            {
                return RedirectToAction(MVC.Dashboard.ActionNames.ContactUs, MVC.Dashboard.Name);
            }
            return View(Query);
        }
        [HttpPost]
        public virtual ActionResult AnswerContact(TblContactUs ins)
        {
            if (!ModelState.IsValid)
            {
                return View(db.TblCompanyInfo.FirstOrDefault());
            }
            ins.ContactStatus = ContactStatus.Read;
            db.TblContactUs.Add(ins);
            db.SaveChanges();
            return RedirectToAction(MVC.Home.ActionNames.Success, MVC.Home.Name);
        }


        public virtual ActionResult CompanyInfo()
        {
            return View(db.TblCompanyInfo.FirstOrDefault());
        }

        [ValidateInput(false)]
        [HttpPost]
        public virtual ActionResult CompanyInfo(TblCompanyInfo model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            db.TblCompanyInfo.Attach(model);
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction(MVC.Dashboard.ActionNames.ContactUs, MVC.Dashboard.Name);
        }
    }
}