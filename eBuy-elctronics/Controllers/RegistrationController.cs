using eBuy_elctronics_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eBuy_elctronics.Models;

namespace eBuy_elctronics.Controllers
{
    [AllowAnonymous]
    public class RegistrationController : Controller
    {

        #region DB Ref
        Entities DB = new Entities();
        #endregion

        #region Registration
        /// <summary>
        /// Users registration access
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Create
        /// <summary>
        /// Create  registration for customer
        /// </summary>
        [HttpPost]
        public ActionResult Create(Registration obj)
        {
            try
            {
                //Store the customer registration details in DB.
                DB.sp_SaveRegstration(obj.Firstname, obj.Lastname, obj.Birthdate, obj.Hno, obj.Street, obj.City, obj.State, obj.Country, obj.Pincode, obj.ContactNo, obj.Email, obj.Loginname, obj.Password,obj.Squestionid,obj.Sanswer);
               
                string Rmsg = "Registration is success.";
                //Returning to login page to login with registered user name and password.
                return RedirectToAction("Index", "Login", new {msg=Rmsg });
            }
            catch (Exception ex)
            {
                 ViewBag.exError = ex.Message;
                 return View("Error");
            }
        }
        #endregion

    }
}
