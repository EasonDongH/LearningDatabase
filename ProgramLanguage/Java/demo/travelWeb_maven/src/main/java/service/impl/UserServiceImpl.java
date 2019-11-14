package service.impl;

import dao.UserDao;
import dao.impl.UserDaoImpl;
import domain.User;
import service.UserService;

public class UserServiceImpl implements UserService {

    private UserDao userDao = new UserDaoImpl();
    @Override
    public User findUserByUserName(String userName) {
        return this.userDao.findUserByUserName(userName);
    }

    @Override
    public boolean saveUser(User user) {
        return this.userDao.findUserByUserName(user.getUsername())==null && this.userDao.saveUser(user);
    }
}
