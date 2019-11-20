package dao.impl;

import dao.FavoriteDao;
import domain.Favorite;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import util.JDBCUtils;

import java.util.Date;

public class FavoriteDaoImpl implements FavoriteDao {

    private JdbcTemplate template = new JdbcTemplate(JDBCUtils.getDataSource());

    @Override
    public Favorite getFavoriteByRidAndUid(int rid, int uid) {
        String sql = "select * from tab_favorite where rid = ? and uid = ? ";
        Favorite result = null;
        try {
            result = this.template.queryForObject(sql, new BeanPropertyRowMapper<>(Favorite.class), rid, uid);
        } catch (Exception e) {
//            e.printStackTrace();
        }
        return result;
    }

    @Override
    public int countFavorite(int rid) {
        String sql = "select count(*) from tab_favorite where rid = ? ";
        return this.template.queryForObject(sql, Integer.class, rid);
    }

    @Override
    public int saveFavorite(int rid, int uid) {
        String sql = "insert into tab_favorite(rid,date,uid) values(?,?,?) ";
        return this.template.update(sql, rid, new Date(), uid);
    }

    @Override
    public int removeFavorite(int rid, int uid) {
        String sql = "DELETE FROM tab_favorite WHERE rid = ? AND uid = ? ";
        return this.template.update(sql, rid, uid);
    }
}
