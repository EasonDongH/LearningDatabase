package service;

import dao.UserDao;
import dao.impl.UserDaoImpl;
import domain.User;

import java.util.List;

public class UserService {
    private UserDao userDao = new UserDaoImpl();

    public User login(User user) {
        return this.userDao.findUserByUsernameAndPassword(user.getName(), user.getPassword());
    }

    public List<User> findAll() {
        return this.userDao.findAll();
    }

    public boolean addUser(User user) {
        return this.userDao.add(user);
    }
}
