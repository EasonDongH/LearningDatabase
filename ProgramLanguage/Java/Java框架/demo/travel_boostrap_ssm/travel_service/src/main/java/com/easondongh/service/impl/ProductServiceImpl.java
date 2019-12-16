package com.easondongh.service.impl;

import com.easondongh.dao.ProductDao;
import com.easondongh.domain.Product;
import com.easondongh.service.ProductService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Service
@Transactional
public class ProductServiceImpl implements ProductService {

    @Autowired
    private ProductDao productDao;

    public List<Product> findAll() {
        return this.productDao.findAll();
    }

    @Override
    public boolean save(Product product) {
        return this.productDao.save(product) > 0;
    }
}
