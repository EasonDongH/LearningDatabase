using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class NewsService
    {
        EFHelper helper = new EFHelper(new HotelDBEntities());
        // 添加新闻
        public int AddNews(News news)
        {
            return helper.Add<News>(news);
        }
        // 修改新闻
        public int ModifyNews(News news)
        {
            return helper.Modify<News>(news);
        }
        // 删除新闻：根据id
        public int DeleteNews(int newsId)
        {
            return helper.Delete<News>(new News() { NewsId=newsId});
        }
        // 查询新闻集合：查询指定数量的新闻
        public List<News> GetNewsList(int count)
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                var queryList = (from n in hotelDBEntities.News orderby n.PublishTime descending select new {
                    n.NewsId,
                    n.NewsTitle,
                    n.PublishTime,
                    n.NewsContents,
                    n.CategoryId,
                    n.NewsCategory.CategoryName
                }).Take(count).ToList();

                List<News> newsList = new List<News>();
                foreach (var item in queryList)
                {
                    newsList.Add(new News() {
                        NewsId=item.NewsId,
                        NewsTitle=item.NewsTitle,
                        NewsContents=item.NewsContents,
                        PublishTime=item.PublishTime,
                        CategoryId=item.CategoryId,
                        NewsCategory =new NewsCategory { CategoryId=(int)item.CategoryId,CategoryName=item.CategoryName}
                    });
                }
                return newsList;
            }
        }
        // 查询新闻详细：根据id
        public News GetNews(int newsId)
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                return (from n in hotelDBEntities.News where n.NewsId == newsId select n).FirstOrDefault();
            }
        }

        // 查询所有新闻分类
        public List<NewsCategory> GetNewsCategories()
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                return (from c in hotelDBEntities.NewsCategory select c).ToList();
            }
        }
        // 根据新闻分类Id返回新闻分类名
        public string GetCategoryName(int categoryId)
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                return (from c in hotelDBEntities.NewsCategory where c.CategoryId == categoryId select c.CategoryName).FirstOrDefault();
            }
        }
    }
}
