using MiracleStone.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiracleStone.Web.Controllers
{
    public partial class CategoriesController : Controller
    {
           private MiracleStoneDbContext db = new MiracleStoneDbContext();
        public virtual ActionResult GetDescription(int id)
        {
            var Query = db.TblCategories.Find(id);
            if (Query != null)
            {
                return Content(Query.Description);
            }
            return Content("");
        }
    }
}