package com.easondongh.service;

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
}
