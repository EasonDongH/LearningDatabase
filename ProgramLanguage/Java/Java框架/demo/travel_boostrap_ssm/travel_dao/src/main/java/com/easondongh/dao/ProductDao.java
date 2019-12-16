package com.easondongh.dao;

import com.easondongh.domain.Product;
import org.apache.ibatis.annotations.Select;

import java.util.List;

public interface ProductDao {

    /**
     *  获取所有产品信息
     * @return
     */
    @Select("select * from product")
    List<Product> findAll();
}
