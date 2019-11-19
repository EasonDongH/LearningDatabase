package dao.impl;

import dao.RouteImgDao;
import domain.RouteImg;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import util.JDBCUtils;

import java.util.List;

public class RouteImgDaoImpl implements RouteImgDao {
    private JdbcTemplate template = new JdbcTemplate(JDBCUtils.getDataSource());

    @Override
    public List<RouteImg> getByRid(int rid) {
        String sql = "select * from tab_route_img where rid = ?";
        List<RouteImg> list = null;
        try {
            list = this.template.query(sql, new BeanPropertyRowMapper<RouteImg>(RouteImg.class), rid);
        } catch (Exception e){
            e.printStackTrace();
        }
        return list;
    }
}
