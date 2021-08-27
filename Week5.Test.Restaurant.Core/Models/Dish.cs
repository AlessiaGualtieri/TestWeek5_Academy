using System;
using System.Collections.Generic;
using System.Text;

namespace Week5.Test.Restaurant.Core.Models
{
    public enum DishType
    {
        Primo,
        Secondo,
        Contorno,
        Dolce
    }
    public class Dish
    {
        public int ID_Dish { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DishType Type { get; set; }
        public decimal Price { get; set; }
    }
}
