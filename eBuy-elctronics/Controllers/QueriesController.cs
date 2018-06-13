using eBuy_elctronics_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eBuy_elctronics.Controllers
{
    [Authorize]
    public class QueriesController : Controller
    {
        #region EF Ref
        Entities DB = new Entities();
        #endregion

        #region All Queries
        /// <summary>
        /// Get all queries list
        /// </summary>
        public ActionResult Index()
        {
            try
            {
                if (Session["user"] != null)
                {
                    ViewBag.AllQueries = DB.Queries.ToList();
                    ViewBag.AllQuestions = DB.Questionbases.ToList();
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
                return View("Error");
            }
        }
        #endregion

        #region Create Queries
        /// <summary>
        /// Create queries 
        /// </summary>
        public ActionResult CreateQuery()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorEx = ex.Message;
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult CreateQuery(Query obj)
        {
            try
            {
                if (Session["user"] != null)
                {
                    Logindetail LogInfo = Session["user"] as Logindetail;
                    obj.LogiID = LogInfo.Loginid;
                    obj.QueryDate = DateTime.Now;
                    obj.IsActive = true;
                    obj.IsDeleted = false;
                    DB.Queries.Add(obj);
                    DB.SaveChanges();
                    ViewBag.sucMsg = "Query sends success.";
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
                return View("Error");
            }
        }
        #endregion

        #region Create Question
        /// <summary>
        /// Create Question 
        /// </summary>
        public ActionResult CreateQuestion()
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
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult CreateQuestion(Questionbase obj)
        {
            try
            {
                if (Session["user"] != null)
                {
                    Logindetail LogInfo = Session["user"] as Logindetail;
                    obj.LoginID = LogInfo.Loginid;
                    obj.CreatedDate = DateTime.Now;
                    DB.Questionbases.Add(obj);
                    DB.SaveChanges();
                    ViewBag.sucMsg = "Question sends success.";
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
                return View("Error");
            }
        }
        #endregion

    }
}
