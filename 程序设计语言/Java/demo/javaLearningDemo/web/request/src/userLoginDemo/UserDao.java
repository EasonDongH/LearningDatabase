package userLoginDemo;

import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;

public class UserDao {
    private JdbcTemplate template = new JdbcTemplate(JDBCUtils.getDataSource());

//    CREATE DATABASE dbtest;
//
//    USE dbtest;
//
//    CREATE TABLE USER(
//            id INT PRIMARY KEY AUTO_INCREMENT,
//            NAME VARCHAR(32) UNIQUE NOT NULL,
//    PASSWORD VARCHAR(32) NOT NULL
//        );
    public User login(User loginUser){
        String sql = "select * from user where name=? and password=?";
        User user = null;
        try{
             user = template.queryForObject(sql,
                    new BeanPropertyRowMapper<User>(User.class),
                    loginUser.getName(), loginUser.getPassword());

        } catch (Exception e){
            e.printStackTrace();
        }
        return user;
    }
}
