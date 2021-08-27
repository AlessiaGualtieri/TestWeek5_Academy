using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week5.Test.Restaurant.Core.Models;
using Week5.Test.Restaurant.Core.Repositories;

namespace Week5.Test.Restaurant.Core.EF.Repositories
{
    public class EFDishRepository : IDishRepository
    {
        private readonly RestaurantContext ctx;

        public EFDishRepository(RestaurantContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Dish item)
        {
            if (item == null)
                throw new ArgumentNullException("Invalid dish");
            try
            {
                ctx.Dishes.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool DeleteById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid id");
            try
            {
                var dish = ctx.Dishes.Where(d => d.ID_Dish == id).FirstOrDefault();
                if(dish == null)
                    throw new ArgumentException("Invalid id");
                ctx.Dishes.Remove(dish);
                ctx.SaveChanges();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IList<Dish> Fetch()
        {
            return ctx.Dishes.ToList();
        }

        public Dish GetByID(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid id");
            return ctx.Dishes.Where(d => d.ID_Dish == id).FirstOrDefault();
        }

        public bool Update(Dish item)
        {
            if (item == null)
                throw new ArgumentNullException("Invalid dish");
            try
            {
                var dish = ctx.Dishes.Where(d => d.ID_Dish == item.ID_Dish).FirstOrDefault();
                if(dish == null)
                    throw new ArgumentException("Invalid dish");

                dish.Name = item.Name;
                dish.Description = item.Description;
                dish.Type = item.Type;
                dish.Price = item.Price;

                ctx.SaveChanges();
                return true;
            }catch(SqlException)
            {
                return false;
            }catch(Exception)
            {
                return false;
            }
        }
    }
}
