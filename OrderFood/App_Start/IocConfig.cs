using Autofac;
using OrderFood.Controllers;
using System;
using System.Data.Entity;
using System.Web.Mvc;


namespace OrderFood.App_Start
{
    public class IocConfig
    {
        public static Autofac.IContainer RegisterDependencies()
        {
            try
            {
                var containerBuilder = new ContainerBuilder();

                /*Register all the controllers within the current assembly.*/
                containerBuilder.RegisterAssemblyModules(typeof(HomeController).Assembly);

                /*Register Libs Files Here*/
                

                //Register Database Configuration
                containerBuilder.RegisterType(typeof(DatabaseConfig)).InstancePerDependency();

                //Register Database Context
                containerBuilder.RegisterType<OrderFood.Models.OrderFoodDb>().As<DbContext>().InstancePerDependency();

                //Register Database Repository
                //containerBuilder.RegisterGeneric(typeof(DataRepository<>)).As(typeof(IDataRepository<>)).
                //    InstancePerDependency();




                var container = containerBuilder.Build();
                //var resolver = new AutofacDependencyResolver(container);
                //DependencyResolver.SetResolver(resolver);
                return container;

            }
            catch (Exception ex)
            {
               
                return null;
            }
        }
    }
    }