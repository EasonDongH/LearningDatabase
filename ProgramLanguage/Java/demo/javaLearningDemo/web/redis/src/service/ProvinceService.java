package service;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import dao.ProvinceDao;
import domain.Province;
import jedis.util.JedisPoolUtils;
import redis.clients.jedis.Jedis;

import java.util.List;

public class ProvinceService {
    private ProvinceDao dao = new ProvinceDao();

    public List<Province> getAllProvinces(){
        return  this.dao.getAllProvinces();
    }

    public String getAllProvincesByRedis(){
        Jedis jedis = JedisPoolUtils.getJedis();
        String provinces_json = jedis.get("provinces");
        if(provinces_json == null || provinces_json.length() == 0) {
            List<Province> list = getAllProvinces();
            try {
                provinces_json = new ObjectMapper().writeValueAsString(list);
                jedis.set("provinces", provinces_json);
            } catch (JsonProcessingException e) {
                e.printStackTrace();
            }
        }
        jedis.close();
        return provinces_json;
    }
}
