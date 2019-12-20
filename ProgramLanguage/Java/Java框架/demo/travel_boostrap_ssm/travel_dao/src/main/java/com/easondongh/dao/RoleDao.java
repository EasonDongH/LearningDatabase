package com.easondongh.dao;

import com.easondongh.domain.Role;
import org.apache.ibatis.annotations.Many;
import org.apache.ibatis.annotations.Result;
import org.apache.ibatis.annotations.Results;
import org.apache.ibatis.annotations.Select;

import javax.tools.JavaCompiler;
import java.util.List;

public interface RoleDao {

    /**
     * 根据userId查找Role列表
     * @param userId
     * @return
     */
    @Select("select * from role where id in (select roleId from users_role where userId = #{userId})")
    @Results({
            @Result(id = true,property = "id",column = "id"),
            @Result(property = "roleName", column = "roleName"),
            @Result(property = "roleDesc", column = "roleDesc"),
            @Result(property = "permissions", column = "id", javaType = java.util.List.class, many = @Many(select = "com.easondongh.dao.PermissionDao.findByRoleId"))
    })
    List<Role> findByUserId(String userId);
}
