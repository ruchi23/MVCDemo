using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrderFood.Models
{
    public class Restaurant
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string City { get; set; }
        [Required]
        public virtual string Country { get; set; }
        public virtual bool Active { get; set; }

        [DataType(DataType.Date), 
        DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy HH:mm}",
            ApplyFormatInEditMode = true), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual DateTime? CreatedOn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
             ApplyFormatInEditMode = true), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual DateTime? UpdatedOn { get; set; }

        public virtual ICollection<RestaurantReview> Reviews { get; set; }                  //adding a virtual keyword - at runtime it will create a wrapper class and intercept through to the Reviews property
    }
}