package dao.impl;

import com.sun.tools.internal.xjc.reader.xmlschema.bindinfo.BIConversion;
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
}
