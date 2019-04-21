using System.Data.Entity;

namespace DAL
{
    internal class EFHelper
    {
        private DbContext dbContext = null;
        /// <summary>
        /// DbContext赋值
        /// </summary>
        /// <param name="context"></param>
        internal EFHelper(DbContext context)
        {
            this.dbContext = context;
        }
        /// <summary>
        /// 通用Add
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        internal int Add<T>(T entity) where T : class
        {
            this.dbContext.Entry<T>(entity).State = EntityState.Added;
            return this.dbContext.SaveChanges();
        }
        /// <summary>
        /// 通用Modify
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        internal int Modify<T>(T entity) where T : class
        {
            this.dbContext.Entry<T>(entity).State = EntityState.Modified;
            return this.dbContext.SaveChanges();
        }
        /// <summary>
        /// 通用Delete
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        internal int Delete<T>(T entity) where T : class
        {
            this.dbContext.Entry<T>(entity).State = EntityState.Deleted;
            return this.dbContext.SaveChanges();
        }
    }
}
