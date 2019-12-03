package com.easondongh.service;

import com.easondongh.domain.User;

import java.util.List;

public interface UserService {
    /**
     * 查询所有用户
     * @return
     */
    List<User> listAll();

    /**
     * 保存用户
     * @param user
     */
    void save(User user);
}
