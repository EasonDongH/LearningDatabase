package com.easondongh.dao;

import com.easondongh.domain.Permission;
import org.apache.ibatis.annotations.Insert;
import org.apache.ibatis.annotations.Select;

import java.util.List;

public interface PermissionDao {

    /**
     * 查询该roleId对应的所有权限
     * @param roleId
     * @return
     */
    @Select("select * from permission where id in (select permissionId from role_permission where roleId = #{roleId})")
    List<Permission> findByRoleId(String roleId);

    /**
     * 查询所有权限
     * @return
     */
    @Select("select * from permission")
    List<Permission> findAll();

    /**
     * 添加权限
     * @param permission
     * @return
     */
    @Insert("insert into permission(id,permissionName,url) values(#{id},#{permissionName},#{url})")
    int save(Permission permission);
}
