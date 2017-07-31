using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderFood.Models;
using NHibernate;
using NHibernate.Linq;

namespace OrderFood.Controllers
{
    public class RestaurantController : Controller
    {
        private OrderFoodDb db = new OrderFoodDb();

        //
        // GET: /Restaurant/

        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var restaurants = session.Query<Restaurant>().ToList();
                return View(restaurants);

                //return View(db.Restaurants.ToList());
            }
        }

        //

        // GET: /Restaurant/Create

        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /Restaurant/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {

            {
                try
                {
                    using (ISession session = NHibernateHelper.OpenSession())
                    {
                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            session.Save(restaurant);
                            transaction.Commit();
                        }
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception exception)
                {
                    return View();
                }
            }
            //if (ModelState.IsValid)
            //{
            //    db.Restaurants.Add(restaurant);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(restaurant);
        }

        //
        // GET: /Restaurant/Edit/5

        public ActionResult Edit(int id)
        {
           using (ISession session = NHibernateHelper.OpenSession())
            {
                var restaurant = session.Get<Restaurant>(id);
                return View(restaurant);
            }
        }

        //
        // POST: /Restaurant/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Restaurant restaurant)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var restauranttoUpdate = session.Get<Restaurant>(id);

                    restauranttoUpdate.Name = restaurant.Name;
                    restauranttoUpdate.City = restaurant.City;
                    restauranttoUpdate.Country = restaurant.Country;
                    restauranttoUpdate.Active = restaurant.Active;
                    restauranttoUpdate.CreatedOn = restaurant.CreatedOn;
                    restauranttoUpdate.UpdatedOn = restaurant.UpdatedOn;
                    restauranttoUpdate.Reviews = restaurant.Reviews;

                    using(ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(restauranttoUpdate);
                        transaction.Commit();
                    }

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Restaurant/Delete/5

        public ActionResult Delete(int id = 0)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var restaurant = session.Get<Restaurant>(id);
                return View(restaurant);
            }
        }

        //
        // POST: /Restaurant/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id,Restaurant restaurant)
        {
            try
            {
                using(ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(restaurant);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch(Exception exception)
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}