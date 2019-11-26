package service.impl;

import dao.UserDao;
import domain.User;
import service.UserService;

import java.util.List;

public class UserServiceImpl implements UserService {

    private UserDao userDao;

    public void setUserDao(UserDao userDao) {
        this.userDao = userDao;
    }

    public List<User> listAllUsers() {
        return this.userDao.listAllUsers();
    }

    public User getUserById(Integer id) {
        return this.userDao.getUserById(id);
    }

    public void update(User user) {
        this.userDao.update(user);
    }

    public void saveUser(User user) {
        this.userDao.saveUser(user);
    }

    public void removeUser(Integer id) {
        this.userDao.removeUser(id);
    }
}
