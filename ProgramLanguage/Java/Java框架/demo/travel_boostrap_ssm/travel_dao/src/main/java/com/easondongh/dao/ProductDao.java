package com.easondongh.dao;

import com.easondongh.domain.Product;
import org.apache.ibatis.annotations.Insert;
import org.apache.ibatis.annotations.Select;

import java.util.List;

public interface ProductDao {

    /**
     *  获取所有产品信息
     * @return
     */
    @Select("select * from product")
    List<Product> findAll();

    /**
     * 保存新产品信息
     * @param product
     * @return
     */
    @Insert("insert into product(productNum,productName,cityName,departureTime,productPrice,productDesc,productStatus) " +
            "values(#{productNum},#{productName},#{cityName},#{departureTime},#{productPrice},#{productDesc},#{productStatus})")
    int save(Product product);
}
