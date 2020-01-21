package com.easondongh.dao;

import com.easondongh.domain.Role;
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

    /**
     * 根据用户id进行查询
     * @param id
     * @return
     */
    @Select("select * from users where id = #{id}")
    @Results({
            @Result(id = true, property = "id", column = "id"),
            @Result(property = "username", column = "username"),
            @Result(property = "email", column = "email"),
            @Result(property = "password", column = "password"),
            @Result(property = "phoneNum", column = "phoneNum"),
            @Result(property = "status", column = "status"),
            @Result(property = "roles", column = "id", javaType = java.util.List.class, many = @Many(select = "com.easondongh.dao.RoleDao.findByUserId"))
    })
    UserInfo findById(String id);

    /**
     * 给该userId新增role
     * @param userId
     * @param roleId
     * @return
     */
    @Insert("insert into users_role(userId,roleId) values(#{userId}, #{roleId})")
    int addRoleToUser(@Param("userId") String userId, @Param("roleId") String roleId);

    @Insert("<script>" +
                "insert into users_role(userId,roleId) values" +
                "<foreach collection='roleIds' item='roleId' separator=','>"+
                    "(#{userId},#{roleId})" +
                "</foreach>" +
            "</script>"
    )
    int addRolesToUser(@Param("userId") String userId, @Param("roleIds") String[] roleIds);

    /**
     * 查找该userId不具有的Role
     * @param userId
     * @return
     */
    @Select("select * from role where id not in (select roleId from users_role where userId=#{userId})")
    List<Role> findOtherRoles(String userId);
}
