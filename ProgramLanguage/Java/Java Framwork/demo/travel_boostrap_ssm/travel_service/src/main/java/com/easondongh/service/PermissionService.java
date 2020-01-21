package com.easondongh.service;

import com.easondongh.domain.Permission;

import java.util.List;

public interface PermissionService {

    /**
     * 查找所需权限
     * @return
     */
    List<Permission> findAll();

    /**
     * 添加权限
     * @param permissionName
     * @param url
     * @return
     */
    boolean save(String permissionName, String url);
}
