using FluentNHibernate.Mapping;
using OrderFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderFood.Mappings
{
    public class RestaurantMap : ClassMap<Restaurant>
    {
        public RestaurantMap()
        {
            Id(c => c.Id);  //PK
            Map(c => c.Name);
            Map(c => c.City);
            Map(c => c.Country);
            Map(c => c.Active);
            Map(c => c.CreatedOn);
            Map(c => c.UpdatedOn);
            
            Table("Restaurants");
        }
    }
}