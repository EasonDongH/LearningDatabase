using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewTest
{
    class TVNode
    {
        public int MenuId { get; set; }
        public int MenuLevel { get; set; }
        public string MenuIcon { get; set; }
        public string MenuName { get; set; }
        public string MenuCode { get; set; }
        public int ParentId { get; set; }
    }
}
