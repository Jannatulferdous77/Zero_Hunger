using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Entity_Framework;

namespace ZeroHunger.Controllers
{
    public class EmployeeDashboardController : Controller
    {
        // GET: EmployeeDashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AssignedCollectRequests()
        {
            var database = new ZeroHungerDatabaseEntities();
            int employeeID = (int)Session["employeeID"];
            var data = database.collect_requests.Where(c => c.employee_id == employeeID);
            return View(data);
        }

        public ActionResult ConfirmRequest(int id)
        {
            var database = new ZeroHungerDatabaseEntities();
            var data = database.collect_requests.Find(id);
            data.status = "In Progress";
            database.SaveChanges();
            return RedirectToAction("AssignedCollectRequests");
        }

        public ActionResult CompleteRequest(int id)
        {
            var database = new ZeroHungerDatabaseEntities();
            var data = database.collect_requests.Find(id);
            data.status = "Completed";
            data.completion_time = DateTime.Now;
            database.SaveChanges();
            return RedirectToAction("AssignedCollectRequests");
        }
    }
}