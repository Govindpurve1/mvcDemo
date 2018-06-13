using eBuy_elctronics_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eBuyelctronics.Models;

namespace eBuy_elctronics.Controllers
{
    public class CardDetailsController : Controller
    {
        #region EF Ref
        Entities DB = new Entities();
        #endregion

        #region Cradit card OR debit card entry
        /// <summary>
        /// Get the cradit card and debit cards entry
        /// </summary>
        public ActionResult Index(cGet_Items Obj) //Getting there buying order id and quantity
        {
            // Creating cradit details object 
            CraditDetails model = new CraditDetails();

            // assigning values cradit details object
            model.OrderItemId = Obj.ItemID;
            model.OrderQuantity = Convert.ToInt32(Obj.Quantity);

            // returning cradit details view
            return View(model);
        }
        #endregion

        #region Create cradit card OR Debit card information
        /// <summary>
        /// To create cradit car OR deit card info
        /// </summary>
        [HttpPost]
        public ActionResult Create(CraditDetails obj)
        {
            try //try catch block to check the valid details
            {
                if (Session["user"] != null) // Checking session is valid or not
                {
                    Logindetail LogInfo = Session["user"] as Logindetail; // getting stored session values in Logindetails object
                    obj.LoginId = LogInfo.Loginid; // Assigning LoginId to Creaditapp

                    // Quantity validation

                 Inventory dbobj=   DB.Inventories.Where(x => x.ItemID == obj.OrderItemId).FirstOrDefault();

                 if (dbobj != null)
                 {
                    dbobj.Quantity = dbobj.Quantity - obj.OrderQuantity;
                    DB.SaveChanges();
                 }

                    //Saving Ordered details and cradit details 
                    DB.sp_Save_Orders(obj.OrderItemId, obj.OrderQuantity, obj.LoginId, obj.Type, obj.CcNumber, obj.CName, obj.Cvv, obj.Exp, obj.Street, obj.CityID, obj.StateID, obj.CountryID, obj.Zipcode);
                    
                    //Adding message for added new order...
                    ViewBag.sucMsg = "Added new order success.";
                   
                    //Redirecting to all order details
                    return RedirectToAction("Index", "Order");
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
