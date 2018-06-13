using eBuy_elctronics_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eBuy_elctronics.Controllers
{
    public class ItemsController : Controller
    {

        #region EF Ref
        Entities DB = new Entities();
        #endregion

        #region Get all items
        /// <summary>
        /// Get all items list to select the item and order or add to cart
        /// </summary>
        public ActionResult Index()
        {
            try
            {
                if (Session["user"] != null)
                {
                    IList<cGet_Items> _Get_Items = DB.sp_Get_Items().ToList();
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

        #region Selected Item
        /// <summary>
        /// Get the selected item to order
        /// </summary>
        public ActionResult Display(int Id)
        {
            try
            {
                if (Session["user"] != null)
                {
                    cGet_Items _Get_Items = DB.sp_Get_Items().Where(x => x.ItemID == Id).FirstOrDefault();
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

        #region Check Quantity Availabilty
        /// <summary>
        /// Checking quantity availabilty to get result
        /// </summary>
        public JsonResult CheckQuantity(int ItemId, int Quantity, int InventoryId)
        {
            try
            {
                if (Session["user"] != null)
                {
                    var Check = DB.Inventories.Where(x => x.InventoryID == InventoryId && x.ItemID == ItemId).Select(x => x.Quantity).FirstOrDefault();
                    
                    if (Check > Quantity || Check == Quantity)
                    { Check = 1; }
                    else { Check = 0; }
                    return Json(Check, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ViewBag.ErrorEx = "Session is expired.";
                    return Json(404, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorEx = ex.Message;
                return Json(404, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion


    }
}
