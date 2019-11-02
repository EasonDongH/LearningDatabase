using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
   public  class DishesManager
    {
        private DishesService objDishesService = new DishesService();

        public int DishesBook(DishesBook book)
        {
            return objDishesService.DishesBook(book);
        }

        public List<DishesBook> GetDishesBookList()
        {
            return objDishesService.GetDishesBookList();
        }

        public int DeleteDishesBook(int dishesBookId)
        {
            return objDishesService.DeleteDishesBook(dishesBookId);
        }

        public int ModifyDishesBookStatus(int bookId, int status)
        {
            return objDishesService.ModifyDishesBookStatus(bookId, status);
        }

        public Dishes GetDishesById(int dishesId)
        {
            return objDishesService.GetDishesById(dishesId);
        }

        public List<Dishes> GetDishesListByCategoryId(int categoryId = 0)
        {
            return objDishesService.GetDishesListByCategoryId(categoryId);
        }

        public List<DishesCategory> GetDishesCategories()
        {
            return objDishesService.GetDishesCategories();
        }

        public int PublishDishes(Dishes dishes)
        {
            return objDishesService.PublishDishes(dishes);
        }

        public int ModifyDishes(Dishes dishes)
        {
            return objDishesService.ModifyDishes(dishes);
        }

        public int DeleteDishes(int dishesId)
        {
            return objDishesService.DeleteDishes(dishesId);
        }
    }
}
