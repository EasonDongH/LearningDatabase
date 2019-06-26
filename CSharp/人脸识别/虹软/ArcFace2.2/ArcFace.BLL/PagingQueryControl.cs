using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcFace.BLL
{
    public class PagingQueryControl<T>
    {
        private int totalSize = 0;
        private int pageSize = 0;
        private int waitForReadDataAmount = 0;
        private int currentPageIndex = 0;
        private Func<int, int,IEnumerable<T>> GetPagingData = null;

        public bool HasDataWaitForRead { get { return this.waitForReadDataAmount > 0; } }

        public PagingQueryControl(int totalSize, int pageSize, Func<int, int,IEnumerable<T>> getPagingData)
        {
            this.totalSize = totalSize;
            this.waitForReadDataAmount = totalSize;
            this.pageSize = pageSize;
           
            this.GetPagingData = getPagingData;
        }

        public List<T> GetNextPagingData()
        {
            if (!this.HasDataWaitForRead)
                return null;
            List<T> pagingData = this.GetPagingData(this.currentPageIndex, this.pageSize).ToList();
            this.currentPageIndex += pagingData.Count();
            this.waitForReadDataAmount -= pagingData.Count();
            return pagingData;
        }
    }
}
