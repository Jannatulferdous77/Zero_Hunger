using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Entity_Framework;

namespace ZeroHunger.Controllers
{
    public class NGODashboardController : Controller
    {
        // GET: NGODashboard
        public ActionResult Index()
        {
            var database = new ZeroHungerDatabaseEntities();
            var data = database.restaurants.ToList();
            return View(data);
        }

        public ActionResult RestaurantList()
        {
            var database = new ZeroHungerDatabaseEntities();
            var data = database.restaurants.ToList();
            return View(data);
        }

        public ActionResult EmployeeList()
        {
            var database = new ZeroHungerDatabaseEntities();
            var data = database.employees.ToList();
            return View(data);
        }

        public ActionResult CollectRequestList()
        {
            var database = new ZeroHungerDatabaseEntities();
            var data = database.collect_requests.ToList();
            return View(data);
        }

        public ActionResult CollectedFoodItemsList()
        {
            var database = new ZeroHungerDatabaseEntities();
            var data = database.collected_food_items.ToList();
            return View(data);
        }

        public ActionResult DistributeFood(int id)
        {
            var database = new ZeroHungerDatabaseEntities();
            var data = database.collected_food_items.Find(id);
            data.distribution_status = "Distributed";
            data.distribution_completion_time = DateTime.Now;
            database.SaveChanges();
            return RedirectToAction("CollectedFoodItemsList");
        }

        public ActionResult AssignEmployee(int id)
        {
            var database = new ZeroHungerDatabaseEntities();
            var data = database.collect_requests.Find(id);
            var employees = database.employees.ToList();
            ViewBag.EmployeeList = employees;
            return View(data);
        }

        [HttpPost]
        public ActionResult AssignEmployee(collect_requests c)
        {
            var database = new ZeroHungerDatabaseEntities();
            var data = database.collect_requests.Find(c.id);
            data.employee_id = c.employee_id;
            data.status = "Assigned";
            database.SaveChanges();
            return RedirectToAction("CollectRequestList");
        }
    }
}