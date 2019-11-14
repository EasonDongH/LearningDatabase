using BLL;
using Models;
using System;
using System.Collections.Generic;

namespace EFTest
{
    class Program
    {
        private static NewsManager objNewsManager = new NewsManager();

        static void Main(string[] args)
        {
            // 测试1：添加新闻
            //News news = new News() { NewsTitle="测试添加新闻",NewsContents="这是测试内容，测试时间为："+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms")};
            //Console.WriteLine(objNewsManager.AddNews(news));
            // 测试2：修改新闻
            //News news = new News() { NewsId = 1000, NewsTitle = "测试修改新闻", NewsContents="这是测试内容", CategoryId = 1, PublishTime = DateTime.Now };
            //Console.WriteLine(objNewsManager.ModifyNews(news));
            // 测试3：删除新闻
            //Console.WriteLine(objNewsManager.DeleteNews(1000));
            // 测试4：查询前N条新闻
            for (int i = 0; i < 10; ++i)
            {
                News news = new News() { NewsTitle = "测试查询" + i, NewsContents = "测试查询内容" + i, CategoryId = 1 };
                objNewsManager.AddNews(news);
                Console.WriteLine($"第{i}条测试新闻添加成功！");
            }
            List<News> newsList = objNewsManager.GetNewsList(7);
            foreach (var n in newsList)
            {
                Console.WriteLine($"{n.NewsId}  {n.NewsTitle}  {n.NewsContents}");
            }


            Console.ReadLine();
        }
    }
}
