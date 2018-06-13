using eBuy_elctronics_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eBuy_elctronics.Controllers
{
    public class cmsQueriesController : Controller
    {
        #region EF Ref
        Entities DB = new Entities();
        #endregion

        #region Queries list
        /// <summary>
        /// Get all user entered queries
        /// </summary>
        public ActionResult Index()
        {
            try
            {
                if (Session["user"] != null)
                {
                  
                    IList<Query> _AllQuery = DB.Queries.ToList();
                    return View(_AllQuery);
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

        #region Replay for query
        public ActionResult Replay(int Id)
        {
        try
            {
                if (Session["user"] != null)
                {
                    var QueryData = DB.Queries.Where(x => x.QueryID == Id).FirstOrDefault();
                    ViewBag.Query = QueryData.Description;
                    ViewBag.QueryId = QueryData.QueryID;
                    Solution result = new Solution();

                    return View(result);
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
        [HttpPost]
        public ActionResult Replay(Solution obj)
        {
            try
            {
                if (Session["user"] != null)
                {
                    obj.IsDeleted = false;
                    obj.IsActive = true;
                    obj.SolvedDate = DateTime.Now;
                    DB.Solutions.Add(obj);
                    DB.SaveChanges();

                    ViewBag.sucMsg = "Replay send success.";
                    return View("Index");
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
