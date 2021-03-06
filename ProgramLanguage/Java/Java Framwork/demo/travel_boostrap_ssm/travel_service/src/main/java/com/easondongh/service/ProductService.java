package com.easondongh.service;

import com.easondongh.domain.Product;

import java.util.List;

public interface ProductService {

    /**
     * 获取所有产品信息
     * @return
     */
    List<Product> findAll();

    /**
     * 保存新产品
     * @param product
     * @return
     */
    boolean save(Product product);
}
