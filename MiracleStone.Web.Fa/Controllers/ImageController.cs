using MiracleStone.Data.Context;
using MiracleStone.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiracleStone.Web.Controllers
{
    public partial class ImageController : Controller
    {
        private readonly MiracleStoneDbContext db = new MiracleStoneDbContext();

        [HttpGet]
        [Route("Image/Add/{tableName}/{id:int}")]
        public virtual ActionResult Add(string tableName, int id)
        {
            return View(db.TblImage.Where(X => X.TableName == tableName && X.ForeignKey == id).ToList());
        }

        [Route("Image/SetDefault/{id:int}/{tableName}/{fk:int}")]
        [HttpGet]
        public virtual ActionResult SetDefault(int id, string tableName, int fk)
        {
            var Query = db.TblImage.Where(X => X.TableName == tableName && X.ForeignKey == fk).ToList();
            if (Query != null)
            {
                foreach (var item in Query)
                {
                    if (item.TblImageID==id)
                    {
                        item.IsDefault = true;
                    }
                    else
                    {
                        item.IsDefault = false;
                    }
                }
                db.SaveChanges();
            }
            return RedirectToAction(MVC.Image.ActionNames.Add, MVC.Image.Name, new { tableName = tableName, id = fk });
        }

        [Route("Image/Remove/{id:int}/{tableName}/{fk:int}")]
        [HttpGet]
        public virtual ActionResult Remove(int id, string tableName, int fk)
        {
            var Query = db.TblImage.Where(X => X.TblImageID == id).FirstOrDefault();
            if (Query != null)
            {
                db.TblImage.Remove(Query);
                db.SaveChanges();
            }
            return RedirectToAction(MVC.Image.ActionNames.Add, MVC.Image.Name, new { tableName = tableName, id = fk });
        }

        [Route("Image/Upload/{tableName}/{fk:int}")]
        [HttpPost]
        public virtual ActionResult Upload(HttpPostedFileBase file, string tableName, int fk)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = file.FileName.Replace(" ", "");
                if (ModelState.IsValid)
                {
                    string Path = "/FileManager/" + tableName + "/" + fileName;
                    file.SaveAs(Server.MapPath(Path));
                    db.TblImage.Add(new TblImage
                    {
                        TableName = tableName,
                        Address = "http://www.MiracleStone.org" + Path,
                        ForeignKey = fk,
                        IsDefault = false
                    });
                    db.SaveChanges();
                }
            }
            return RedirectToAction(MVC.Image.ActionNames.Add, MVC.Image.Name, new { tableName = tableName, id = fk });
        }
    }
}