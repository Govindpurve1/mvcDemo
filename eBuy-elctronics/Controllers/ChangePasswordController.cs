using eBuy_elctronics_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eBuy_elctronics.Models;


namespace eBuy_elctronics.Controllers
{
    public class ChangePasswordController : Controller
    {
        #region EF Ref
        Entities DB = new Entities();
        #endregion

        #region change password details
        public ActionResult Index()
        {
            try
            {
                if (Session["user"] != null) 
                {
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

        #region add new password
        /// <summary>
        /// Add new password required old password and login name
        /// </summary>
        public ActionResult addnewpassword(ChangePasword obj)
        {
            try
            {
                if (Session["user"] != null)
                {
                    Logindetail user = DB.Logindetails.Where(x => x.Loginname == obj.username && x.Password == obj.oldpassword && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                    if (user != null)
                    {
                        user.Password = obj.newpassword;
                        user.Passmodifieddate = DateTime.Now;
                        user.UpdatedBy = user.Loginid.ToString();
                        user.UpdatedDate = DateTime.Now;
                        
                        DB.SaveChanges();
                        ViewBag.sucMsg = "Password is changed successfully.";
                        return View("Index");
                    }
                    else
                    {
                        ViewBag.sucMsg = "Login name and password is not matched please try agin.";
                        return View("Index");
                    }
                    
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
