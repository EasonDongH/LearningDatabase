package com.easondongh.dao;

import com.easondongh.domain.UserInfo;
import org.apache.ibatis.annotations.*;

import javax.tools.JavaCompiler;
import java.util.List;

public interface UserDao {

    /**
     * 添加用户
     * @param userInfo
     * @return
     */
    @Insert("insert into users(id,username,email,password,phoneNum,status) values(#{id},#{username},#{email},#{password},#{phoneNum},#{status})")
    int saveUser(UserInfo userInfo);

    /**
     * 根据username（唯一键）查询users表
     * @param username
     * @return
     */
    @Select("select * from users where username = #{username}")
    @Results({
            @Result(id = true, property = "id", column = "id"),
            @Result(property = "username", column = "username"),
            @Result(property = "email", column = "email"),
            @Result(property = "password", column = "password"),
            @Result(property = "phoneNum", column = "phoneNum"),
            @Result(property = "status", column = "status"),
            @Result(property = "roles", column = "id", javaType = java.util.List.class, many = @Many(select = "com.easondongh.dao.RoleDao.findByUserId"))
    })
    UserInfo findByUsername(String username);

    /**
     * 查找所有用户
     * @return
     */
    @Select("select * from users")
    List<UserInfo> findAll();
}
