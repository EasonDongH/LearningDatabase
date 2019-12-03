package com.easondongh.dao;

import com.easondongh.domain.User;
import org.apache.ibatis.annotations.Insert;
import org.apache.ibatis.annotations.Select;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface UserDao {
    /**
     * 列出所有用户
     * @return
     */
    @Select("select * from user")
    List<User> listAll();

    /**
     * 保存用户
     * @param user
     */
    @Insert("insert into user (name,password) values(#{name},#{password})")
    void save(User user);
}
