package dao.impl;

import dao.RouteDao;
import domain.Route;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import util.JDBCUtils;

import java.util.List;
import java.util.Properties;

public class RouteDaoImpl implements RouteDao {
    private JdbcTemplate template = new JdbcTemplate(JDBCUtils.getDataSource());

    @Override
    public int getTotalRouteSizeByCid(int cid) {
        int result = 0;
        String sql = "select count(*) from tab_route where cid = ?";
        try {
            result = this.template.queryForObject(sql,Integer.class,cid);
        } catch (Exception e){
            e.printStackTrace();
        }
        return result;
    }

    @Override
    public List<Route> getPageData(int cid, int start, int pageSize) {
        List<Route> result = null;
        String sql = "select * from tab_route where cid = ? limit ?,?";
        try {
            result = this.template.query(sql,new BeanPropertyRowMapper<Route>(Route.class), cid, start, pageSize);
        } catch (Exception e){
            e.printStackTrace();
        }
        return result;
    }
}
