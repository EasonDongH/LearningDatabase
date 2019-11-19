package dao.impl;

import dao.RouteDao;
import domain.Route;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import util.JDBCUtils;

import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

public class RouteDaoImpl implements RouteDao {
    private JdbcTemplate template = new JdbcTemplate(JDBCUtils.getDataSource());

    @Override
    public int getTotalRouteSizeByCid(int cid, String rname) {
        int result = 0;
        String sql = "select count(*) from tab_route where 1=1";
        List params = new ArrayList();
        try {
            if (cid > 0) {
                sql += " AND cid=?";
                params.add(cid);
            }
            if (rname != null && rname.length() > 0) {
                sql += " AND rname LIKE ?";
                params.add("%" + rname + "%");
            }
            result = this.template.queryForObject(sql, Integer.class, params.toArray());
        } catch (Exception e) {
            e.printStackTrace();
        }
        return result;
    }

    @Override
    public List<Route> getPageData(int cid, int start, int pageSize, String rname) {
        List<Route> result = null;
        String sql = "select * from tab_route where 1=1";
        List params = new ArrayList();
        try {
            if (cid > 0) {
                sql += " AND cid=?";
                params.add(cid);
            }
            if (rname != null && rname.length() > 0) {
                sql += " AND rname LIKE ?";
                params.add("%" + rname + "%");
            }
            params.add(start);
            params.add(pageSize);
            sql += " limit ?,?";
            result = this.template.query(sql, new BeanPropertyRowMapper<Route>(Route.class), params.toArray());
        } catch (Exception e) {
            e.printStackTrace();
        }
        return result;
    }

    @Override
    public Route getRouteDetailById(int rid) {
        String sql = "select * from tab_route where rid = ?";
        Route result = null;
        try {
            result = this.template.queryForObject(sql, new BeanPropertyRowMapper<Route>(Route.class), rid);
        } catch (Exception e) {
            e.printStackTrace();
        }
        return result;
    }


}
