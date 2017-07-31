using NHibernate;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrderFood.Models;

namespace OrderFood
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        public static string ReadWrite { get; private set; }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
         .Database(MsSqlConfiguration.MsSql2012
         .ConnectionString(
             @"Server=(localdb)\v11.0;Initial Catalog=FluentHibernate;Integrated Security=SSPI")
            .ShowSql())
          
            .Mappings(m => m.FluentMappings
            .AddFromAssemblyOf<Restaurant>())
            .ExposeConfiguration(cfg => new SchemaExport(cfg)
            .Create(true,true))
            .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            
            return SessionFactory.OpenSession();
        }
    }
}