package com.easondongh.dao;

import com.easondongh.domain.Permission;
import com.easondongh.domain.Role;
import org.apache.ibatis.annotations.*;

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

    /**
     * 查找所有角色
     * @return
     */
    @Select("select * from role")
    List<Role> findAll();

    /**
     * 新增角色
     * @param role
     * @return
     */
    @Insert("insert into role (id,roleName,roleDesc) values(#{id},#{roleName},#{roleDesc})")
    int save(Role role);

    /**
     * 查找该userId不具有的Role
     * @param roleId
     * @return
     */
    @Select("select * from permission where id not in (select permissionId from role_permission where roleId=#{roleId})")
    List<Permission> findOtherPermissions(String roleId);

    /**
     * 给该roleId添加权限
     * @param roleId
     * @param permissionId
     * @return
     */
    @Insert("insert into role_permission(permissionId, roleId) values(#{permissionId}, #{roleId})")
    int addPermissionToRole(@Param("roleId") String roleId, @Param("permissionId") String permissionId);

    /**
     * 根据id查找Role
     * @param roleId
     * @return
     */
    @Select("select * from role where id = #{roleId}")
    Role findById(String roleId);
}
