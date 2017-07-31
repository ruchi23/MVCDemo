using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OrderFood.Models
{
    public class OrderFoodDb : DbContext
    {
        public OrderFoodDb() : base("name=DefaultConnection")  //Base class constructor where we input the name of connection string from web config. This helps to connect to the db.
        {
             
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }
        
    }
}
