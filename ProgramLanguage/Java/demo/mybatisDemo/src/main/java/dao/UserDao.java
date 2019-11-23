package dao;

import java.util.List;

import domain.QueryVo;
import domain.User;
import org.apache.ibatis.annotations.*;


public interface UserDao {

    /**
     * 查找所有用户
     * @return
     */
    @Select("select * from user ")
    @Results({
            @Result(property = "userId", column = "id", id = true)
    })
    List<User> listAll();

    /**
     * 保存用户
     * @param user
     * @return
     */
    @SelectKey(statement = "select last_insert_id();", keyProperty = "id", keyColumn = "id", before = false, resultType = Integer.class)
    @Insert({"insert into user(name,password) values(#{name},#{password})"})
    int saveUser(User user);

    /**
     * 根据id获取用户
     * @return
     */
    @Select("select * from user where id = #{uid}") // 仅一个非自定义类型参数时，参数名称无所谓
    User getById(int userId);

    /**
     * 根据name模糊查询
     * @param name
     * @return
     */
    @Select("select * from user where name like #{name}") // 模糊查询时，%由参数传入
    List<User> listByName(String name);

    /**
     * 统计用户总数
     * @return
     */
    @Select("select count(*) from user")
    int countUser();

    /**
     * 使用QueryVo进行姓名的模糊查询
     * @param queryVo
     * @return
     */
    @Select("select * from user where name like #{user.name}")
    List<User> listByQueryVoName(QueryVo queryVo);

    @Select("select * from user where 1=1 ")

    List<User> listByCondition(User user);
}
