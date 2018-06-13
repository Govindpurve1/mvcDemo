using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eBuy_elctronics_DB;

namespace eBuy_elctronics.Controllers
{
    public class BrandsController : Controller
    {
        #region EF Ref
        Entities DB = new Entities();
        #endregion


        #region Brands
        /// <summary>
        /// Get Selected Brand's list
        /// </summary>
        public ActionResult Index()
        {
            try
            {
                if (Session["user"] != null)
                {
                    IList<Brand> _Brands = DB.Brands.ToList();
                    return View(_Brands);
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
                return View("Error");
            }

        }
        #endregion

        #region Brand items
        /// <summary>
        /// Get selected all brand items
        /// </summary>

        [HttpGet]
        public ActionResult BrandItems(int Id)
        {
            try
            {
                if (Session["user"] != null)
                {
                    IList<cGet_Items> _Get_Items = DB.sp_Get_Items().Where(x => x.BrandID == Id).ToList();
                    ViewBag.count = _Get_Items.Count();
                    return View(_Get_Items);
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
                return View("Error");
            }
        }
        #endregion

    }
}
