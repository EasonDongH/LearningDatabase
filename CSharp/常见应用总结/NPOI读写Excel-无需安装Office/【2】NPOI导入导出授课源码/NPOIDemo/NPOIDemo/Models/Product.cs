using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPOIDemo
{
    /// <summary>
    /// 商品实体类
    /// </summary>
    [Serializable]
    public class Product
    {
        public Product() { }
        /// <summary>
        /// 商品编号
        /// </summary>   
        public string ProductId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public int Discount { get; set; }



    }
}
