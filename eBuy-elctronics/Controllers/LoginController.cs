using eBuy_elctronics_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace eBuy_elctronics.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        #region EF Ref
        Entities DB = new Entities();
        #endregion

        #region Login
        /// <summary>
        /// Get Login details
        /// </summary>
        public ActionResult Index(string msg)
        {
            // checking retuned url
            if (!string.IsNullOrEmpty(msg))
                ViewBag.sucMsg = msg;

            return View();
        }
        #endregion

        #region Check login access
        /// <summary>
        /// Get valid login details
        /// </summary>
        public ActionResult CheckLoginAccess(Logindetail Lobj, string ReturnUrl)
        {
            try
            {
                // Checking user exist or given user name and password
                Logindetail _User = DB.Logindetails.Where(x => x.Loginname == Lobj.Loginname && x.Password == Lobj.Password && x.IsDeleted == false).FirstOrDefault();
                // Validating user 
                if (_User != null)
                {
                    //Seting form authentication
                    FormsAuthentication.SetAuthCookie(_User.Logintype, false);
                                                            
                    //Store the user information in session
                    Session["user"] = _User as Logindetail;

                    //Checking user role accessing the controller's
                    if (_User.Logintype == "Admin")
                        return RedirectToAction("Index", "cmsAdmin");
                    else if (_User.Logintype == "Customer")
                        return RedirectToAction("Index", "Home");
                }
                    //In valid user
                else
                    ViewBag.sucMsg = "user name and password incorrect.";
                return View("Index");
            }
            catch (Exception ex)
            {
                // system handle exception return error view page.
                ViewBag.exError = ex.Message;
                return View("Error");
            }
        }
        #endregion

        #region Log out
        /// <summary>
        /// Log off customer details safe
        /// </summary>
        public ActionResult LogOff()
        {
            //remove the authenticated user
            FormsAuthentication.SignOut();
            //Remove store information in sessions
            Session.Abandon();
            Session["user"] = null;
            ViewBag.sucMsg = "Successfully sign off.";
            return View("Index");
        }
        #endregion
    }
}
