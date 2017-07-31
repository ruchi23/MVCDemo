using OrderFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderFood.Controllers
{
    public class HomeController : Controller
    {
        OrderFoodDb _db = new OrderFoodDb();   
        //instantiate the db

        public ActionResult Autocomplete(string term) 
        {
            var model =
                _db.Restaurants
                .Where(r => r.Name.StartsWith(term))
                .Take(10)
                .Select(r => new
                {
                    label = r.Name
                });
            
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index(string searchTerm = null)
        {
           
            var model =
                _db.Restaurants
                .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))                 //filtering throught the search term parameter
                .Take(10)
                .Select(r => new RestaurantListViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    City = r.City,
                    Country = r.Country,
                    CountOfReviews = r.Reviews.Count()
                });

            if (Request.IsAjaxRequest()) //determine whether the request returned is Ajax async request
            {
                return PartialView("_Restaurants", model);
            }
            
            return View(model);
        }

        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Joey";
            model.Location = "NY";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();   //if db isnot null, it will dispose itslef i.e clean up resources that might be open
            }
            base.Dispose(disposing);
        }
    }
}
