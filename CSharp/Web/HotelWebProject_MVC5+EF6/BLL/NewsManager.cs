using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;
using DAL;

namespace BLL
{
    public class NewsManager
    {
        private NewsService objNewsService = new NewsService();
        public int AddNews(News news)
        {
            return objNewsService.AddNews(news);
        }

        public int ModifyNews(News news)
        {
            return objNewsService.ModifyNews(news);
        }

        public int DeleteNews(int newsId)
        {
            return objNewsService.DeleteNews(newsId);
        }

        public List<News> GetNewsList(int count)
        {
            return objNewsService.GetNewsList(count);
        }

        public News GetNewsById(int newsId)
        {
            return objNewsService.GetNews(newsId);
        }

        public List<NewsCategory> GetNewsCategories()
        {
            return objNewsService.GetNewsCategories();
        }

        public string GetCategoryName(int categoryId)
        {
            return objNewsService.GetCategoryName(categoryId);
        }
    }
}
