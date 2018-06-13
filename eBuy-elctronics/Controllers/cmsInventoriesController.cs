using eBuy_elctronics_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eBuy_elctronics.Controllers
{
    public class cmsInventoriesController : Controller
    {
        #region EF Ref
        Entities DB = new Entities();
        #endregion

        #region All inventories
        public ActionResult Index()
        {
            try
            {
                if (Session["user"] != null)
                {

                    IList<cGet_Items> _All_Items = DB.sp_Get_Items().ToList();
                    return View(_All_Items);
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

        #region Update Quntity and Price
        public JsonResult UpdateQuantityPrice(int Quantity, int Price, int InventoryID)
        {
            try
            {
                if (Session["user"] != null)
                {
                    int resut = 0;
                    Inventory _inventory = DB.Inventories.Find(InventoryID);
                    if (_inventory != null)
                    {
                        _inventory.Quantity = _inventory.Quantity + Quantity;
                        _inventory.Price = _inventory.Price + Price;
                        DB.SaveChanges();
                        resut = 1;
                    }


                    return Json(resut, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ViewBag.ErrorEx = "Session is expired.";
                   return Json(404,JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorEx = ex.Message;
             return Json(404,JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}
