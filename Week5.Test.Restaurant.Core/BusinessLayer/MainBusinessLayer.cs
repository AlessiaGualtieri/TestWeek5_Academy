using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week5.Test.Restaurant.Core.Models;
using Week5.Test.Restaurant.Core.Repositories;

namespace Week5.Test.Restaurant.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IUserRepository userRepository;
        private readonly IDishRepository dishRepository;

        public MainBusinessLayer(IUserRepository userRepository, IDishRepository dishRepository)
        {
            this.userRepository = userRepository;
            this.dishRepository = dishRepository;
        }

        public IList<Dish> GetDishes()
        {
            return dishRepository.Fetch();
        }

        public Dish GetDishByID(int id_dish)
        {
            return (id_dish <= 0) ? throw new ArgumentException("Invali id") :
                dishRepository.GetByID(id_dish);
        }
        public User GetUser(string username)
        {
            if (String.IsNullOrEmpty(username))
                throw new ArgumentException("Invalid username");
            return userRepository.GetUser(username);
        }

        public bool RegisterUser(User item)
        {
            if (item == null)
                throw new ArgumentNullException("Invalid user");
            return userRepository.Add(item);
        }

        public Dish GetDishByName(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Invalid name");
            return GetDishes().Where(d => d.Name == name).FirstOrDefault();
        }

        public bool AddDish(Dish item)
        {
            return (item == null) ?
                throw new ArgumentNullException("Invalid dish")
                : dishRepository.Add(item);
        }

        public bool EditDish(Dish item)
        {
            return (item == null) ?
                throw new ArgumentNullException("Invalid dish")
                : dishRepository.Update(item);
        }

        public bool DeleteDishByID(int id_dish)
        {
            return (id_dish <= 0) ?
                throw new ArgumentException("Invalid id")
                : dishRepository.DeleteById(id_dish);
        }
    }
}
