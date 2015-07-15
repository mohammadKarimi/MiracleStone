using MiracleStone.Data.Context;
using MiracleStone.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MiracleStone.Web.Fa.Controllers
{
    public partial class MaterialController : Controller
    {
        private readonly MiracleStoneDbContext db = new MiracleStoneDbContext();

        [HttpGet]
        [Route("Material/List/{title}/{categoriesID:int}")]
        public virtual ActionResult List(int categoriesID)
        {
            return View(db.TblProduct.Where(X => X.TblCategoriesID == categoriesID).OrderByDescending(X => X.TblProductID).ToList());
        }

        [HttpGet]
        public virtual string GetDefaultImage(int id)
        {
            var Query = db.TblImage.Where(X => X.IsDefault == true && X.ForeignKey == id && X.TableName == "Product").FirstOrDefault();
            if (Query == null)
                return string.Empty;
            return Query.Address;
        }

        public virtual PartialViewResult GetAllFiles(int id)
        {
            return PartialView(db.TblImage.Where(X => X.ForeignKey == id && X.TableName == "Product").ToList());
        }

    }
}
