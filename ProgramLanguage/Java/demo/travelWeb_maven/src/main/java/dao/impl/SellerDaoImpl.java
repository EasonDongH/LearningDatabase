package dao.impl;

import dao.SellerDao;
import domain.Seller;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import util.JDBCUtils;

public class SellerDaoImpl implements SellerDao {
    private JdbcTemplate template = new JdbcTemplate(JDBCUtils.getDataSource());

    @Override
    public Seller getById(int sid) {
        String sql = "select * from tab_seller where sid = ?";
        Seller result = null;
        try {
            result = this.template.queryForObject(sql,new BeanPropertyRowMapper<Seller>(Seller.class),sid);
        } catch (Exception e){
            e.printStackTrace();
        }

        return result;
    }
}
