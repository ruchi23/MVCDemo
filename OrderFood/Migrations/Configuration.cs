namespace OrderFood.Migrations
{
    using OrderFood.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OrderFood.Models.OrderFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            //entity framework won't make changes to the db unless this is enabled true explicitly 
        }

        protected override void Seed(OrderFood.Models.OrderFoodDb context)     //populate the db with some initial data
        {
            context.Restaurants.AddOrUpdate(
                    r => r.Name,
                    new Restaurant { Name = "Sayaji", City = "Baroda", Country = "India" },
                    new Restaurant { Name = "Pizza Plater", City = "New York", Country = "US" },
                    new Restaurant
                    {
                        Name = "Smaka",
                        City = "XYZ",
                        Country = "Sweden",
                        Reviews =
                                new List<RestaurantReview>{
                                new RestaurantReview {Rating=9,Body="Great food!", ReviewerName="Ruchi"}}
                    }


                );

            //for (int i = 0; i < 25; i++)
            //{
            //    context.Restaurants.AddOrUpdate(r => r.Name,
            //        new Restaurant { Name = i.ToString(), City = "Nowhere", Country = "USA" });
            //}
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
