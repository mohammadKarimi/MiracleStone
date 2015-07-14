using MiracleStone.Data.Context;
using MiracleStone.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiracleStone.Web.Controllers
{
    public partial class GalleryController : Controller
    {
        private readonly MiracleStoneDbContext db = new MiracleStoneDbContext();

        public virtual ActionResult Show()
        {
            var Query = (from prd in db.TblProduct
                         join cat in db.TblCategories on prd.TblCategoriesID equals cat.TblCategoriesID
                         join img in db.TblImage on prd.TblProductID equals img.ForeignKey
                         orderby prd.TblProductID descending
                         where img.TableName == "Product"
                         select new Gallery { Address = img.Address, Name = prd.Name, Class = cat.Name }).Take(100).ToList();
            return View(Query);
        }
    }
}