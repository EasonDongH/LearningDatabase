package com.easondongh.service.impl;

import com.easondongh.dao.UserDao;
import com.easondongh.domain.User;
import com.easondongh.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Service("userService")
public class UserServiceImpl implements UserService {

    @Autowired
    private UserDao userDao;

    @Override
    public List<User> listAll() {
        return userDao.listAll();
    }

    @Override
    public void save(User user) {
        try {
            userDao.save(user);
            int i = 10 / 0;
            user.setName(user.getName() + "123");
            userDao.save(user);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
