using Dapper;

namespace ArcFace.Models
{
    public class ColumnMapper
    {
        public static void SetMapper()
        {
            //数据库字段名和c#属性名不一致，手动添加映射关系
            // SqlMapper.SetTypeMap(typeof(Books), new ColumnAttributeTypeMapper<Books>());
            SqlMapper.SetTypeMap(typeof(FaceSampleModel),new ColumnAttributeTypeMapper<FaceSampleModel>());
            //每个需要用到[colmun(Name="")]特性的model，都要在这里添加映射
        }
    }
}