package service.impl;

import com.fasterxml.jackson.databind.ObjectMapper;
import dao.CategoryDao;
import dao.impl.CategoryDaoImpl;
import domain.Category;
import redis.clients.jedis.Jedis;
import redis.clients.jedis.Tuple;
import service.CategoryService;
import util.JedisUtil;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;

public class CategoryServiceImpl implements CategoryService {

    private CategoryDao categoryDao = new CategoryDaoImpl();
    /**
     * 获取所有分类信息，已排序（sql排序）
     * @return
     */
    @Override
    public List<Category> getAllCategories() {
        Jedis jedis = JedisUtil.getJedis();
        Set<Tuple> categories = jedis.zrangeWithScores("category", 0, -1);
        List<Category> allCategories = null;
        ObjectMapper mapper = new ObjectMapper();
        if(categories == null || categories.size() == 0) {
            allCategories = this.categoryDao.getAllCategories();
            for (int i = 0; i < allCategories.size(); i++) {
                jedis.zadd("category", allCategories.get(i).getCid(),allCategories.get(i).getCname());
            }
        } else {
            allCategories = new ArrayList<Category>();
            for(Tuple tuple : categories) {
                allCategories.add(new Category((int)tuple.getScore(),tuple.getElement()));
            }
        }

        return allCategories;
    }
}
