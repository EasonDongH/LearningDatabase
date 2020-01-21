package com.easondongh.service.impl;

import com.easondongh.dao.RoleDao;
import com.easondongh.domain.Permission;
import com.easondongh.domain.Role;
import com.easondongh.service.RoleService;
import com.easondongh.util.UuidUtil;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Service("roleService")
@Transactional
public class RoleServiceImpl implements RoleService {

    @Autowired
    private RoleDao roleDao;

    @Override
    public List<Role> findAll() {
        return this.roleDao.findAll();
    }

    @Override
    public boolean save(String roleName, String roleDesc) {
        Role role = new Role();
        role.setId(UuidUtil.getUuid());
        role.setRoleName(roleName);
        role.setRoleDesc(roleDesc);
        return this.roleDao.save(role) > 0;
    }

    @Override
    public List<Permission> findOtherPermissions(String roleId) {
        return this.roleDao.findOtherPermissions(roleId);
    }

    @Override
    public boolean addPermissionsToRole(String roleId, String[] permissionIds) {
        boolean result = true;
        for(int i=0; i<permissionIds.length; i++) {
            result = this.roleDao.addPermissionToRole(roleId, permissionIds[i]) > 0;
        }
        return result;
    }

    @Override
    public Role findById(String roleId) {
        return this.roleDao.findById(roleId);
    }

}
