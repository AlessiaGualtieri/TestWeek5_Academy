using System;
using System.Collections.Generic;
using System.Text;
using Week5.Test.Restaurant.Core.Models;

namespace Week5.Test.Restaurant.Core.Repositories
{
    public interface IBusinessLayer
    {
        public User GetUser(string username);
        public bool RegisterUser(User item);


        public IList<Dish> GetDishes();
        public Dish GetDishByID(int id_dish);
        public Dish GetDishByName(string name);
        public bool AddDish(Dish item);
        public bool EditDish(Dish item);
        public bool DeleteDishByID(int id_dish);



    }
}
