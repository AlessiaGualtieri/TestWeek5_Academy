using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week5.Test.Restaurant.Core.Models;
using Week5.Test.Restaurant.Core.Repositories;
using Week5.Test.Restaurant.MVC.Models;

namespace Week5.Test.Restaurant.MVC.Controllers
{
    [Authorize]
    public class RestaurantController : Controller
    {
        private readonly IBusinessLayer mainBL;

        public RestaurantController(IBusinessLayer mainBL)
        {
            this.mainBL = mainBL;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Contacts()
        {
            return View();
        }

        
        public IActionResult Menu()
        {
            var dishes = mainBL.GetDishes();
            return View(dishes);
        }

        public IActionResult Detail(int id_dish)
        {
            if (id_dish <= 0)
                return View("Error", new ErrorViewModel());
            var dish = mainBL.GetDishByID(id_dish);
            if(dish == null)
                return View("Error", new ErrorViewModel());

            return View(dish);
        }
        
        [Authorize(Roles ="Owner")]
        public IActionResult AddDish()
        {
            return View();
        }

        [Authorize(Roles = "Owner")]
        [HttpPost]
        public IActionResult AddDish(DishViewModel dish)
        {
            if (!ModelState.IsValid || dish == null)
                return View(dish);
            var dishExisting = mainBL.GetDishByName(dish.Name);
            if(dishExisting != null)
            {
                ViewData["DishError"] = "Dish name already existing";
                return View(dish);
            }
            var result = mainBL.AddDish(new Core.Models.Dish
            {
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                Type = dish.Type
            });
            if (result)
                return RedirectToAction("Menu");

            ViewData["DishError"] = "An error in the server occurred. Please try again later";
            return View(dish);
        }

        [Authorize(Roles = "Owner")]
        public IActionResult EditDish(int id_dish)
        {
            if (id_dish <= 0)
                return View("Error", new ErrorViewModel());
            var dish = mainBL.GetDishByID(id_dish);
            if(dish == null)
                return View("Error", new ErrorViewModel());

            return View(new DishViewModel()
            {
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                Type = dish.Type,
                ID_Dish = dish.ID_Dish
            }
            );
        }

        [HttpPost]
        [Authorize(Roles = "Owner")]
        public IActionResult EditDish(DishViewModel dish)
        {
            if (dish == null)
                return View("Error", new ErrorViewModel());
            var result = mainBL.EditDish(new Dish() {
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                Type = dish.Type,
                ID_Dish = dish.ID_Dish
            });
            if (result)
                return RedirectToAction("Menu");

            ViewData["DishError"] = "An error in the server occurred. Please try again later";
            return View();

        }

        public IActionResult DeleteDish(int id_dish)
        {
            if (id_dish <= 0)
                return View("Error", new ErrorViewModel());
            var result = mainBL.DeleteDishByID(id_dish);
            if (result)
                return RedirectToAction("Menu");
            ViewData["DeleteDishError"] = "Could not delete dish";
            return View("Menu");
        }


    }
}
