package com.easondongh.service;

import com.easondongh.domain.User;
import com.easondongh.mapper.UserMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import sun.rmi.runtime.Log;

/**
 * @author EasonDongH
 * @date 2020/2/19 11:08
 */
@Service
public class UserService {

    @Autowired
    private UserMapper userMapper;

    public User selectById(Long id) {
        return this.userMapper.selectById(id);
    }
}
