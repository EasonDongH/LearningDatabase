package dao.impl;

import dao.UserDao;
import domain.User;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import util.JDBCUtils;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Set;

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
        try {
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
        try {
            res = this.template.update(sql, user.getName(), user.getPassword(), user.getAge(), user.getGender(), user.getEmail(), user.getAddress(), user.getQq());
        } catch (Exception e) {
            res = 0;
        }
        return res > 0;
    }

    @Override
    public boolean delete(int id) {
        int res = 0;
        String sql = "delete from user where id = ?";
        try {
            res = this.template.update(sql, id);
        } catch (Exception e) {
            res = 0;
        }
        return res > 0;
    }

    @Override
    public User findById(int id) {
        User user = null;
        String sql = "select * from user where id = ?";
        try {
            user = this.template.queryForObject(sql, new BeanPropertyRowMapper<>(User.class), id);
        } catch (Exception e) {
            user = null;
        }
        return user;
    }

    @Override
    public boolean update(User user) {
        int res = 0;
        String sql = "update user set name=?, password=?, gender=?,age=?,address=?,qq=?,email=? where id = ?";
        try {
            res = this.template.update(sql, user.getName(), user.getPassword(), user.getGender(), user.getAge(), user.getAddress(), user.getQq(), user.getEmail(), user.getId());
        } catch (Exception e) {
            res = 0;
        }
        return res > 0;
    }

    @Override
    public int findTotalCount(Map<String, String> condition) {
        StringBuilder sql = new StringBuilder("select count(*) from user where 1=1");
        List<Object> params = new ArrayList<Object>();
        if(condition != null && condition.isEmpty() == false) {
            for (String key : condition.keySet()) {
                String value = condition.get(key);
                if(value != null && "".equals(value) == false){
                    sql.append(" and " + key + " like ? ");
                    params.add( "%" + value + "%");
                }
            }
        }
        Integer query = this.template.queryForObject(sql.toString(), Integer.class, params.toArray());
        return query;
    }

    @Override
    public List<User> findByPage(int start, int rows, Map<String, String> condition) {
        StringBuilder sql = new StringBuilder("select * from user where 1=1");
        List<Object> params = new ArrayList<Object>();
        if(condition != null && condition.isEmpty() == false) {
            for (String key : condition.keySet()) {
                String value = condition.get(key);
                if(value != null && "".equals(value) == false){
                    sql.append(" and " + key + " like ? ");
                    params.add( "%" + value + "%");
                }
            }
        }
        sql.append(" limit ?, ?");
        params.add(start);
        params.add(rows);
        List<User> userList = this.template.query(sql.toString(), new BeanPropertyRowMapper<User>(User.class), params.toArray());
        return userList;
    }
}
