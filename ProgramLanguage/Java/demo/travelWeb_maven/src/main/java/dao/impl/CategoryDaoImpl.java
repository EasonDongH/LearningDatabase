package dao.impl;

import dao.CategoryDao;
import domain.Category;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import util.JDBCUtils;

import java.util.List;

public class CategoryDaoImpl implements CategoryDao {

    private JdbcTemplate template = new JdbcTemplate(JDBCUtils.getDataSource());

    /**
     * 获取所有分类信息
     * @return
     */
    @Override
    public List<Category> getAllCategories() {
        String sql = "select * from tab_category ORDER BY cid";
        return this.template.query(sql, new BeanPropertyRowMapper<Category>(Category.class));
    }
}
