package com.easondongh.service.impl;

import com.easondongh.dao.ProductDao;
import com.easondongh.domain.Product;
import com.easondongh.service.ProductService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ProductServiceImpl implements ProductService {

    @Autowired
    private ProductDao productDao;

    public List<Product> findAll() {
        return this.productDao.findAll();
    }
}
