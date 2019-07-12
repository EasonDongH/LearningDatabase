using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ArcFace.DAL;
using ArcFace.Models;
using System.Drawing.Imaging;

namespace ArcFace.BLL
{
    public class FaceSampleBLL
    {
        private FaceSampleDAL objFaceSampleDAL = new FaceSampleDAL();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(FaceSampleModel model)
        {
            model.Id = System.Guid.NewGuid().ToString();
            int add_Result = this.objFaceSampleDAL.Add(model);
            return add_Result > 0;
        }

        /// <summary>
        /// 获取数据库表“face_sample”所有数据
        /// </summary>
        /// <returns></returns>
        public List<FaceSampleModel> GetList(string ver)
        {
            IEnumerable<FaceSampleModel> models = this.objFaceSampleDAL.GetList(ver);
            return models.ToList();
        }

        /// <summary>
        /// 获取数据库表“face_sample”所有的id、sampledata数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FaceSampleModel> GetAllSampleInfo()
        {
            IEnumerable<FaceSampleModel> models = this.objFaceSampleDAL.GetAllSampleInfo();
            return models.ToList();
        }

        public int GetNeedUpdateAmount(decimal version)
        {
            return this.objFaceSampleDAL.GetNeedUpdateAmount(version);
        }

        public bool Update(FaceSampleModel model)
        {
            return this.objFaceSampleDAL.Update(model) > 0;
        }

        public bool ResetDBTestData()
        {
            return this.objFaceSampleDAL.ResetDBTestData() > 0;
        }

    }
}
