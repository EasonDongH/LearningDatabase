package com.easondongh.service.impl;

import com.easondongh.dao.UserDao;
import com.easondongh.domain.User;
import com.easondongh.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Lazy;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Service("userService")
@Lazy
public class UserServiceImpl implements UserService {

    @Autowired
    private UserDao userDao;

    public UserServiceImpl(){
        int i = 1+2;
    }

    @Override
    public List<User> listAll() {
        return userDao.listAll();
    }

    @Override
    @Transactional
    public void save(User user) {

            userDao.save(user);
            int i = 10 / 0;
            user.setName(user.getName() + "123");
            userDao.save(user);

    }
}
