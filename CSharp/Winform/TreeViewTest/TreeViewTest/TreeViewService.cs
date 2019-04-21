using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace TreeViewTest
{
    class TreeViewService
    {
        public List<TVNode> GetAllTVNodes()
        {
            string sql = "select * from MenuList";
            List<TVNode> tVNodes = new List<TVNode>();
            SqlDataReader sqlDataReader = SQLHelper.GetDataReader(sql);
            while (sqlDataReader.Read())
            {
                tVNodes.Add(new TVNode {
                    MenuId = Convert.ToInt32(sqlDataReader["MenuId"]),
                    MenuLevel = Convert.ToInt32(sqlDataReader["MenuLevel"]),
                    MenuName=sqlDataReader["MenuName"].ToString(),
                    MenuIcon = sqlDataReader["MenuIcon"].ToString(),
                    MenuCode = sqlDataReader["MenuCode"].ToString(),
                    ParentId = Convert.ToInt32(sqlDataReader["ParentId"])
                });
            }
            sqlDataReader.Close();
            return tVNodes;
        }
    }
}
