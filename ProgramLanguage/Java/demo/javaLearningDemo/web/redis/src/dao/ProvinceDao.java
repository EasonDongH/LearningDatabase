package dao;

import domain.Province;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import util.JDBCUtils;

import java.util.List;

public class ProvinceDao {
    private JdbcTemplate template = new JdbcTemplate(JDBCUtils.getDataSource());

    public List<Province> getAllProvinces(){
        String sql = "select * from province ";
        List<Province> list = this.template.query(sql, new BeanPropertyRowMapper<>(Province.class));
        return list;
    }
}
