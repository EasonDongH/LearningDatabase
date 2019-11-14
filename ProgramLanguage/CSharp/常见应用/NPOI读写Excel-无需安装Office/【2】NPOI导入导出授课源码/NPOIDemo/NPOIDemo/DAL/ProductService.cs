using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NPOIDemo
{
    public class ProductService
    {
        /// <summary>
        /// 获取全部的商品信息列表
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProductList()
        {
            string sql = "select ProductId,ProductName,Unit,UnitPrice,Discount from Products order by ProductId";
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<Product> objList = new List<Product>();
            while (objReader.Read())
            {
                objList.Add(new Product()
                {
                    ProductId = objReader["ProductId"].ToString(),
                    ProductName = objReader["ProductName"].ToString(),
                    Unit = objReader["Unit"].ToString(),
                    UnitPrice = Convert.ToDecimal(objReader["UnitPrice"]),
                    Discount = Convert.ToInt32(objReader["Discount"])
                });
            }
            objReader.Close();
            return objList;
        }
    }
}
