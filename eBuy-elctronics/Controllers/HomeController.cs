using eBuy_elctronics_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eBuy_elctronics.Controllers
{
    public class HomeController : Controller
    {
        #region EF Ref
        Entities DB = new Entities();
        #endregion

        #region home load all latest created items brands and categories
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                if (Session["user"] != null)
                {
                    IList<Brand> _Brands = DB.Brands.OrderByDescending(x => x.CreatedDate).Take(6).ToList();
                    IList<Category> _Category = DB.Categories.OrderByDescending(x => x.CreatedDate).Take(3).ToList();
                    IList<cGet_Items> _Items = DB.sp_Get_Items().Take(5).ToList();
                    ViewBag.Brands = _Brands;
                    ViewBag.category = _Category;
                    ViewBag.Items = _Items;
                    return View();
                }
                else
                {
                    ViewBag.ErrorEx = "Session is expired.";
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorEx = ex.Message;
                return View("Index");
            }
        }
        #endregion

    }
}
