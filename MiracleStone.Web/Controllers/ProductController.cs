using MiracleStone.Data.Context;
using MiracleStone.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiracleStone.Web.Controllers
{
    public partial class ProductController : Controller
    {
        private readonly MiracleStoneDbContext db = new MiracleStoneDbContext();

        [HttpGet]
        [Route("Product/List/{title}/{categoriesID:int}")]
        public virtual ActionResult List(int categoriesID)
        {
            return View(db.TblProduct.Where(X => X.TblCategoriesID == categoriesID).OrderByDescending(X => X.TblProductID).ToList());
        }

        [HttpGet]
        public virtual ContentResult GetDefaultImage(int id)
        {
            var Query = db.TblImage.Where(X => X.IsDefault == true && X.ForeignKey == id && X.TableName == "Product").FirstOrDefault();
            if (Query == null)
                return Content(string.Empty);
            return Content(Query.Address);
        }

        public virtual PartialViewResult GetAllImage(int id)
        {
            return PartialView(db.TblImage.Where(X => X.ForeignKey == id && X.TableName == "Product").ToList());
        }

        [HttpGet]
        public virtual ViewResult Add()
        {
            ViewBag.TblCategories = new SelectList(db.TblCategories.ToList(), "TblCategoriesID", "Name");
            return View();
        }


        [HttpGet]
        public virtual ViewResult ListOfProduct()
        {
            return View(db.TblProduct.ToList());
        }


        [HttpPost]
        public virtual ActionResult Add(TblProduct model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.TblCategories = new SelectList(db.TblCategories.ToList(), "TblCategoriesID", "Name");
                return View(model);
            }
            db.TblProduct.Add(model);
            db.SaveChanges();
            return RedirectToAction(MVC.Image.ActionNames.Add, MVC.Image.Name, new { tableName = "Product", id = model.TblProductID });
        }

        [HttpGet]
        public virtual ViewResult Edit(int id)
        {
            ViewBag.TblCategories = new SelectList(db.TblCategories.ToList(), "TblCategoriesID", "Name");

            return View(db.TblProduct.FirstOrDefault(X => X.TblProductID == id));
        }

        [HttpPost]
        public virtual ActionResult Edit(TblProduct model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.TblCategories = new SelectList(db.TblCategories.ToList(), "TblCategoriesID", "Name");
                return View(model);
            }
            db.TblProduct.Attach(model);
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction(MVC.Image.ActionNames.Add, MVC.Image.Name, new { tableName = "Product", id = model.TblProductID });
        }


        [HttpPost]
        public virtual RedirectToRouteResult Remove(int TblProductID)
        {
            try
            {
                var Query = db.TblProduct.FirstOrDefault(X => X.TblProductID == TblProductID);
                if (Query != null)
                {
                    db.TblProduct.Remove(Query);
                    db.TblImage.RemoveRange(db.TblImage.Where(X => X.ForeignKey == TblProductID && X.TableName == "Product"));
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
            return RedirectToAction(MVC.Product.ActionNames.ListOfProduct, MVC.Product.Name);
        }
    }
}