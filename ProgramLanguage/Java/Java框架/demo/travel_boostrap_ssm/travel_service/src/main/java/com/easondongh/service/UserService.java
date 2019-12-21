package com.easondongh.service;

import com.easondongh.domain.Role;
import com.easondongh.domain.UserInfo;
import org.springframework.security.core.userdetails.UserDetailsService;

import java.util.List;

public interface UserService extends UserDetailsService {

    /**
     * 添加用户
     * @param userInfo
     * @return
     */
    boolean saveUser(UserInfo userInfo);

    /**
     * 查询所有用户
     * @return
     */
    List<UserInfo> findAll();

    /**
     * 根据用户id查询
     * @param id
     * @return
     */
    UserInfo findById(String id);

    /**
     * 给该userId添加权限
     * @param userId
     * @param roleIds
     * @return
     */
    boolean addRolesToUser(String userId, String[] roleIds);

    /**
     * 查找该userId不具有的Role
     * @param userId
     * @return
     */
    List<Role> findOtherRole(String userId);
}
