package dao;

import java.util.List;
import domain.User;
import mybatis.annotations.Select;

public interface UserDao {

    /**
     * 查找所有用户
     * @return
     */
    @Select("select * from user ")
    List<User> listAll();
}
