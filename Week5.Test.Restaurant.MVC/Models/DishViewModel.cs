using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Week5.Test.Restaurant.Core.Models;

namespace Week5.Test.Restaurant.MVC.Models
{
    public class DishViewModel
    {
        public int ID_Dish { get; set; }
        [Required, DataType(DataType.Text), DisplayName("Name")]
        public string Name { get; set; }
        [Required, DataType(DataType.Text), DisplayName("Description")]
        public string Description { get; set; }
        [Required, DisplayFormat, DisplayName("Type")]
        public DishType Type { get; set; }
        [Required, DataType(DataType.Currency), DisplayName("Price")]
        public decimal Price { get; set; }
    }
}
