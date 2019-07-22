using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class ArcFaceBLL
    {
        private ArcFaceDAL _arcFaceDAL = new ArcFaceDAL();

        public bool Insert(ArcFaceModel model)
        {
            model.id = Guid.NewGuid().ToString();
            return this._arcFaceDAL.Insert(model) > 0;
        }

        public IEnumerable<ArcFaceModel> GetList()
        {
            return this._arcFaceDAL.GetList();
        }
    }
}
