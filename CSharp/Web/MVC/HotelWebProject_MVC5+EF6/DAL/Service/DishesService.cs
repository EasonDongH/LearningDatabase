using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class DishesService
    {
        public int DishesBook(DishesBook book)
        {
            using (HotelDBEntities hotelDB = new HotelDBEntities())
            {
                hotelDB.Entry<DishesBook>(book).State = System.Data.Entity.EntityState.Added;
                return hotelDB.SaveChanges();
            }
        }

        public List<DishesBook> GetDishesBookList()
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                return (from d in hotelDBEntities.DishesBook where d.OrderStatus!=3 orderby d.BookTime select d).ToList();
            }
        }

        public int ModifyDishesBookStatus(int bookId, int status)
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                DishesBook dishesBook = new DishesBook() { BookId = bookId };
                hotelDBEntities.DishesBook.Attach(dishesBook);
                dishesBook.OrderStatus = status;
                return hotelDBEntities.SaveChanges();
            }
        }

        public Dishes GetDishesById(int dishesId)
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                return (from d in hotelDBEntities.Dishes where dishesId == d.DishesId select d).FirstOrDefault();
            }
        }

        public List<Dishes> GetDishesListByCategoryId(int categoryId = 0)
        {
            //通过关联对象查询的写法
            using (HotelDBEntities db = new HotelDBEntities())
            {
                //需要查询关联对象
                var dishesList = from d in db.Dishes
                                 select new
                                 {
                                     d.DishesId,
                                     d.DishesName,
                                     d.UnitPrice,
                                     d.CategoryId,
                                     d.DishesCategory.CategoryName
                                 };
                if (categoryId != 0)
                {
                    dishesList = from d in dishesList where d.CategoryId == categoryId select d;
                }
                //转换成具体对象
                List<Dishes> list = new List<Dishes>();
                foreach (var item in dishesList)
                {
                    list.Add(new Dishes
                    {
                        DishesId = item.DishesId,
                        DishesName = item.DishesName,
                        UnitPrice = item.UnitPrice,
                        CategoryId = item.CategoryId,
                        DishesCategory = new DishesCategory { CategoryName = item.CategoryName }
                    });
                }
                return list;
            }
        }

        public List<DishesCategory> GetDishesCategories()
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                return (from c in hotelDBEntities.DishesCategory select c).ToList();
            }
        }

        public int PublishDishes(Dishes dishes)
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                hotelDBEntities.Entry<Dishes>(dishes).State = System.Data.Entity.EntityState.Added;
                return hotelDBEntities.SaveChanges();
            }
        }

        public int ModifyDishes(Dishes dishes)
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                hotelDBEntities.Entry<Dishes>(dishes).State = System.Data.Entity.EntityState.Modified;
                return hotelDBEntities.SaveChanges();
            }
        }

        public int DeleteDishes(int dishesId)
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                Dishes dishes = new Dishes() { DishesId = dishesId };
                hotelDBEntities.Entry<Dishes>(dishes).State = System.Data.Entity.EntityState.Deleted;
                return hotelDBEntities.SaveChanges();
            }
        }

        public int DeleteDishesBook(int dishesBookId)
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                DishesBook dishesBook = new DishesBook() { BookId = dishesBookId };
                hotelDBEntities.Entry<DishesBook>(dishesBook).State = System.Data.Entity.EntityState.Deleted;
                return hotelDBEntities.SaveChanges();
            }
        }
    }
}
