using AutoMapper;
using System;
using System.Linq;
using System.Web.Mvc;
using ZeroHunger.DTOs;
using ZeroHunger.Entity_Framework;

namespace ZeroHunger.Controllers
{
    public class RestaurantDashboardController : Controller
    {
        // GET: RestaurantDashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateCollectRequest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCollectRequest(CollectedFoodItemDTO collectedFoodItemDTO)
        {
            var collectRequestDTO = new CollectRequestDTO()
            {
                RestaurantId = (int)Session["restaurantID"],
                Time = DateTime.Now,
                MaximumPreserveTime = DateTime.Now.AddHours(collectedFoodItemDTO.MaximumPreserveTimeInHours),
                Status = "Unassigned"
            };

            var collectRequestMapperConfiguration = new MapperConfiguration(configure =>
            {
                configure.CreateMap<CollectRequestDTO, collect_requests>();
            });
            var collectRequestMapper = new Mapper(collectRequestMapperConfiguration);
            var collectRequestData = collectRequestMapper.Map<collect_requests>(collectRequestDTO);
            var database = new ZeroHungerDatabaseEntities();
            database.collect_requests.Add(collectRequestData);
            database.SaveChanges();
            collectedFoodItemDTO.CollectRequestId = collectRequestData.id;
            collectedFoodItemDTO.Condition = "Good";
            collectedFoodItemDTO.DistributionStatus = "Undistributed";
            var collectedFoodItemsMapperConfiguration = new MapperConfiguration(configure =>
            {
                configure.CreateMap<CollectedFoodItemDTO, collected_food_items>();
            });
            var collectedFoodItemsMapper = new Mapper(collectedFoodItemsMapperConfiguration);
            var collectedFoodItemsData = collectedFoodItemsMapper.Map<collected_food_items>(collectedFoodItemDTO);
            database.collected_food_items.Add(collectedFoodItemsData);
            database.SaveChanges();
            return RedirectToAction("Index", "RestaurantDashboard");
        }

        public ActionResult CollectRequestList()
        {
            var database = new ZeroHungerDatabaseEntities();
            int restaurantID = (int)Session["restaurantID"];
            var data = database.collect_requests.Where(c => c.restaurant_id == restaurantID);
            return View(data);
        }

        public ActionResult CollectedFoodItemsList()
        {
            var database = new ZeroHungerDatabaseEntities();
            int restaurantID = (int)Session["restaurantID"];
            var data = database.collected_food_items.Where(c => c.collect_requests.id == restaurantID);
            return View(data);
        }

        public ActionResult DeleteCollectRequests(int id)
        {
            var database = new ZeroHungerDatabaseEntities();
            var collectRequestsData = database.collect_requests.Find(id);
            var collectedFoodItemsData = database.collected_food_items.FirstOrDefault(c => c.collect_request_id == collectRequestsData.id);
            database.collect_requests.Remove(collectRequestsData);
            database.collected_food_items.Remove(collectedFoodItemsData);
            database.SaveChanges();
            return RedirectToAction("CollectRequestList", "RestaurantDashboard");
        }

        public ActionResult DeleteCollectedFoodItemsList(int id)
        {
            var database = new ZeroHungerDatabaseEntities();
            var collectedFoodItemsData = database.collected_food_items.Find(id);
            var collectRequestsData = database.collect_requests.Find(collectedFoodItemsData.collect_request_id);
            database.collect_requests.Remove(collectRequestsData);
            database.collected_food_items.Remove(collectedFoodItemsData);
            database.SaveChanges();
            return RedirectToAction("CollectedFoodItemsList", "RestaurantDashboard");
        }
    }
}