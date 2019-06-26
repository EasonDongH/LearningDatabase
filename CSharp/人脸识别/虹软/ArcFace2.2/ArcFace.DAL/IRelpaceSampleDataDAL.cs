using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcFace.DAL
{
    public interface IRelpaceSampleDataDAL
    {
        int GetNeedUpdateAmount(decimal version);

        IEnumerable<T> GetPagingData<T>(int startIndex, int num, decimal ver);

        int Update<T>(List<T> models);

        int Update<T>(T model);
    }
}
