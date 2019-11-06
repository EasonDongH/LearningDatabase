package dao.impl;

import dao.UserDao;
import domain.User;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import util.JDBCUtils;

import java.util.List;
import java.util.Map;

public class UserDaoImpl implements UserDao {
    private JdbcTemplate template = new JdbcTemplate(JDBCUtils.getDataSource());

    @Override
    public List<User> findAll() {
        String sql = "select * from user";
        List<User> list = template.query(sql, new BeanPropertyRowMapper<User>(User.class));
        return list;
    }

    @Override
    public User findUserByUsernameAndPassword(String username, String password) {
        String sql = "select * from user where name= ? and password = ?";
        User user = null;
        try{
            user = template.queryForObject(sql, new BeanPropertyRowMapper<>(User.class), username, password);
        } catch (Exception e) {
            user = null;
        }
        return user;
    }

    @Override
    public boolean add(User user) {
        int res = 0;
        String sql = "insert into user(name, password, age, gender, email, address, qq) values(?,?,?,?,?,?,?)";
        try{
            res = this.template.update(sql, user.getName(), user.getPassword(), user.getAge(), user.getGender(), user.getEmail(), user.getAddress(), user.getQq());
        } catch (Exception e){
            res = 0;
        }
        return  res > 0;
    }

    @Override
    public void delete(int id) {

    }

    @Override
    public User findById(int i) {
        return null;
    }

    @Override
    public void update(User user) {

    }

    @Override
    public int findTotalCount(Map<String, String[]> condition) {
        return 0;
    }

    @Override
    public List<User> findByPage(int start, int rows, Map<String, String[]> condition) {
        return null;
    }
}
