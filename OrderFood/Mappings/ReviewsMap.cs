using FluentNHibernate.Mapping;
using OrderFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderFood.Mappings
{
    public class ReviewsMap : ClassMap<RestaurantReview>
    {
        public ReviewsMap()
        {
            Id(c => c.Id);
            Map(c => c.Rating);
            Map(c => c.Body);
            Map(c => c.ReviewerName);
            Map(c => c.RestaurantId);
            Table("Reviews");
            
        }
    }
}