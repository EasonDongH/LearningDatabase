package dao.impl;

import dao.UserDao;
import domain.User;
import org.apache.commons.dbutils.QueryRunner;
import org.apache.commons.dbutils.handlers.BeanHandler;
import org.apache.commons.dbutils.handlers.BeanListHandler;

import java.sql.SQLException;
import java.util.List;

public class UserDaoImpl implements UserDao {

    private QueryRunner runner;

    public void setRunner(QueryRunner runner) {
        this.runner = runner;
    }

    public List<User> listAllUsers() {
        List<User> users = null;
        try {
            users = this.runner.query("select * from user", new BeanListHandler<User>(User.class));
        } catch (Exception e) {
            e.printStackTrace();
        }
        return users;
    }

    public User getUserById(Integer id) {
        User user = null;
        try {
            user = this.runner.query("select * from user where id = ?",new BeanHandler<User>(User.class), id);
        } catch (SQLException e) {
            e.printStackTrace();
        } return user;
    }

    public void update(User user) {
        try {
            this.runner.update("update user set name=?,password=? where id=?", user.getName(),user.getPassword(),user.getId());
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void saveUser(User user)  {
        try {
            this.runner.update("insert user (name,password)values(?,?)", user.getName(),user.getPassword());
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void removeUser(Integer id) {
        try {
            this.runner.update("delete from user where id = ?", id);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
