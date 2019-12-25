package com.easondongh.service;

import com.easondongh.domain.Permission;
import com.easondongh.domain.Role;

import java.util.List;

public interface RoleService {

    /**
     * 查找所有角色
     * @return
     */
    List<Role> findAll();

    /**
     * 保存角色
     * @param roleName
     * @param roleDesc
     * @return
     */
    boolean save(String roleName,String roleDesc);

    /**
     * 查找该userId不具有的权限
     * @param roleId
     * @return
     */
    List<Permission> findOtherPermissions(String roleId);

    /**
     * 给该roleId添加权限
     * @param roleId
     * @param permissionIds
     * @return
     */
    boolean addPermissionsToRole(String roleId, String[] permissionIds);

    /**
     * 根据id查找role
     * @param roleId
     * @return
     */
    Role findById(String roleId);
}
