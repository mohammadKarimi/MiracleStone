using MiracleStone.Data.Context;
using MiracleStone.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiracleStone.Web.Controllers
{
    public partial class ProjectController : Controller
    {
        private readonly MiracleStoneDbContext db = new MiracleStoneDbContext();

        [HttpGet]
        public virtual ActionResult List()
        {
            return View(db.TblProjects.OrderByDescending(X => X.TblProjectsID).ToList());
        }

        [HttpGet]
        public virtual FilePathResult GetDefaultImage(int id)
        {
            var Query = db.TblImage.Where(X => X.IsDefault == true && X.ForeignKey == id && X.TableName == "Project").FirstOrDefault();
            if (Query == null)
                return File(string.Empty, "image/jpeg");
            return File(Query.Address, "image/jpeg");
        }

        public virtual PartialViewResult GetAllImage(int id)
        {
            return PartialView(db.TblImage.Where(X => X.ForeignKey == id && X.TableName == "Project").ToList());
        }

        [HttpGet]
        public virtual ViewResult ListOfProjects()
        {
            return View(db.TblProjects.ToList());
        }

        [HttpGet]
        public virtual ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Add(TblProjects model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            db.TblProjects.Add(model);
            db.SaveChanges();
            return RedirectToAction(MVC.Image.ActionNames.Add, MVC.Image.Name, new { tableName = "Project", id = model.TblProjectsID });
        }

        [HttpGet]
        public virtual ViewResult Edit(int id)
        {
            return View(db.TblProjects.FirstOrDefault(X => X.TblProjectsID == id));
        }

        [HttpPost]
        public virtual ActionResult Edit(TblProjects model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            db.TblProjects.Attach(model);
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction(MVC.Image.ActionNames.Add, MVC.Image.Name, new { tableName = "Project", id = model.TblProjectsID });
        }

        [HttpPost]
        public virtual RedirectToRouteResult Remove(int TblProjectsID)
        {
            try
            {
                var Query = db.TblProjects.FirstOrDefault(X => X.TblProjectsID == TblProjectsID);
                if (Query != null)
                {
                    db.TblProjects.Remove(Query);
                    db.TblImage.RemoveRange(db.TblImage.Where(X => X.ForeignKey == TblProjectsID && X.TableName == "Project"));
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
            return RedirectToAction(MVC.Project.ActionNames.ListOfProjects, MVC.Project.Name);
        }

    }
}