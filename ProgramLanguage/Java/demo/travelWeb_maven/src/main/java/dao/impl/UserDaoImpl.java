package dao.impl;

import dao.UserDao;
import domain.User;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import util.JDBCUtils;

public class UserDaoImpl implements UserDao {

    private JdbcTemplate template = new JdbcTemplate(JDBCUtils.getDataSource());

    @Override
    public User findUserByUserName(String userName) {
        String sql = "select * from tab_user WHERE username = ?";
        User user = null;
        try{
            user = this.template.queryForObject(sql, new BeanPropertyRowMapper<>(User.class), userName);
        } catch (Exception e){
            user = null;
//            e.printStackTrace();
        }
        return user;
    }

    @Override
    public User findUserByActiveCode(String activeCode) {
        String sql = "select * from tab_user WHERE code = ?";
        User user = null;
        try{
            user = this.template.queryForObject(sql, new BeanPropertyRowMapper<>(User.class), activeCode);
        } catch (Exception e){
            user = null;
        }
        return user;
    }

    @Override
    public boolean activeUser(String activeCode) {
        boolean res= false;
        String sql = "UPDATE tab_user SET status='Y' WHERE code = ?";
        try {
            int cnt = this.template.update(sql, activeCode);
            res = cnt > 0;
        } catch (Exception e) {
            e.printStackTrace();
        }
        return  res;
    }

    @Override
    public boolean saveUser(User user) {
        boolean res= false;
        String sql = "insert tab_user (username,password,name,birthday,sex,telephone,email,status,code) value(?,?,?,?,?,?,?,?,?)";
        try {
            int cnt = this.template.update(sql, user.getUsername(), user.getPassword(), user.getName(), user.getBirthday(),
                    user.getSex(), user.getTelephone(), user.getEmail(), user.getStatus(), user.getCode());
            res = cnt > 0;
        } catch (Exception e) {
            e.printStackTrace();
        }
        return  res;
    }

    @Override
    public User findUserByUserNameAndPwd(String username, String pwd) {
        String sql = "SELECT * FROM tab_user WHERE username = ? AND password = ?";
        User user = null;
        try{
            user = this.template.queryForObject(sql, new BeanPropertyRowMapper<>(User.class), username, pwd);
        } catch (Exception e){
            user = null;
        }
        return user;
    }
}
