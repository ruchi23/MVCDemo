using Autofac;
using OrderFood.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OrderFood.App_Start
{
    public class DatabaseConfig
    {
        public static void Initialize(IComponentContext componentContext)
        {
            try
            {


                using (var dbContext = componentContext.Resolve<DbContext>())
                {

                    Database.SetInitializer(new MigrateDatabaseToLatestVersion<OrderFood.Models.OrderFoodDb, Configuration>());
                    dbContext.Database.Initialize(false);

                    //if (!dbContext.Database.Exists())
                    //{
                    //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<OrderFood.Models.OrderFoodDb, Configuration>());
                    //    dbContext.Database.Initialize(false);

                    //}


                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}