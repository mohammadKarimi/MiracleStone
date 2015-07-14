using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiracleStone.Data.Context;
namespace MiracleStone.Web.Controllers
{
    public partial class LayoutController : Controller
    {
        private readonly MiracleStoneDbContext db = new MiracleStoneDbContext();

        [ChildActionOnly]
        public virtual PartialViewResult Header()
        {
            return PartialView(db.TblCompanyInfo.FirstOrDefault());
        }

        [ChildActionOnly]
        public virtual PartialViewResult Footer()
        {
            return PartialView(db.TblCompanyInfo.FirstOrDefault());
        }

        [ChildActionOnly]
        public virtual PartialViewResult RecentImage()
        {
            var Query = db.TblImage.OrderByDescending(X => X.TblImageID).Take(9).ToList();
            return PartialView(Query);
        }
    }
}