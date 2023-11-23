using AutoMapper;
using System.Linq;
using System.Web.Mvc;
using ZeroHunger.DTOs;
using ZeroHunger.Entity_Framework;

namespace ZeroHunger.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult RestaurantLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RestaurantLogin(RestaurantDTO restaurantDTO)
        {
            var mapperConfiguration = new MapperConfiguration(configure =>
            {
                configure.CreateMap<RestaurantDTO, restaurant>();
            });
            var mapper = new Mapper(mapperConfiguration);
            var data = mapper.Map<restaurant>(restaurantDTO);
            var database = new ZeroHungerDatabaseEntities();
            var restaurantData = database.restaurants.FirstOrDefault(r => r.email_address == data.email_address);
            if (restaurantData != null)
            {
                if (restaurantData.password == data.password)
                {
                    Session["restaurantID"] = restaurantData.id;
                    return RedirectToAction("Index", "RestaurantDashboard");
                }
            }
            return View(restaurantDTO);
        }

        public ActionResult EmployeeLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeLogin(EmployeeDTO employeeDTO)
        {
            var mapperConfiguration = new MapperConfiguration(configure =>
            {
                configure.CreateMap<EmployeeDTO, employee>();
            });
            var mapper = new Mapper(mapperConfiguration);
            var data = mapper.Map<employee>(employeeDTO);
            var database = new ZeroHungerDatabaseEntities();
            var employeeData = database.employees.FirstOrDefault(r => r.email_address == data.email_address);
            if (employeeData != null)
            {
                if (employeeData.password == data.password)
                {
                    Session["employeeID"] = employeeData.id;
                    return RedirectToAction("Index", "EmployeeDashboard");
                }
            }
            return View(employeeDTO);
        }

        public ActionResult NGOLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NGOLogin(RestaurantDTO restaurantDTO)
        {
            if (restaurantDTO.EmailAddress == "mdsazzadsiddique0@gmail.com" && restaurantDTO.Password == "123456")
            {
                Session["NGOID"] = 1;
                return RedirectToAction("Index", "NGODashboard");
            }
            return View(restaurantDTO);
        }
    }
}