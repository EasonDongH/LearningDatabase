package com.easondongh.service.impl;

import com.easondongh.dao.PermissionDao;
import com.easondongh.domain.Permission;
import com.easondongh.service.PermissionService;
import com.easondongh.util.UuidUtil;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;
import java.util.UUID;

@Transactional
@Service("permissionService")
public class PermissionServiceImpl implements PermissionService {

    @Autowired
    private PermissionDao permissionDao;

    @Override
    public List<Permission> findAll() {
        return this.permissionDao.findAll();
    }

    @Override
    public boolean save(String permissionName, String url) {
        Permission permission = new Permission();
        permission.setId(UuidUtil.getUuid());
        permission.setPermissionName(permissionName);
        permission.setUrl(url);
        return this.permissionDao.save(permission) > 0;
    }
}
