using MiracleStone.Data.Context;
using MiracleStone.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiracleStone.Web.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly MiracleStoneDbContext db = new MiracleStoneDbContext();

        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }

        #region Contact Us
        [HttpGet]
        public virtual ViewResult ContactUs()
        {
            return View(db.TblCompanyInfo.FirstOrDefault(X => X.Lang == Lang.Fa));
        }

        [HttpPost]
        public virtual ActionResult ContactUs(TblContactUs ins)
        {
            if (!ModelState.IsValid)
            {
                return View(db.TblCompanyInfo.FirstOrDefault(X => X.Lang == Lang.Fa));
            }
            ins.ContactStatus = ContactStatus.UnRead;
            db.TblContactUs.Add(ins);
            db.SaveChanges();
            return RedirectToAction(MVC.Home.ActionNames.Success, MVC.Home.Name);
        }

        public virtual ViewResult Success()
        {
            return View();
        }

        #endregion
        [HttpGet]
        public virtual ViewResult AboutUs()
        {
            return View(db.TblCompanyInfo.FirstOrDefault(X=>X.Lang==Lang.Fa));
        }
    }
}