package com.easondongh.service.impl;

import com.easondongh.dao.OrdersDao;
import com.easondongh.domain.Orders;
import com.easondongh.service.OrdersService;
import com.github.pagehelper.PageHelper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Service
@Transactional
public class OrderServiceImpl implements OrdersService {

    @Autowired
    private OrdersDao ordersDao;

    @Override
    public List<Orders> findAll(int pageNum,int pageSize) {
        PageHelper.startPage(pageNum, pageSize);
        return this.ordersDao.findAll();
    }
}
