package com.easondongh.service;

import com.easondongh.domain.Orders;

import java.util.List;

public interface OrdersService {

    /**
     * 查询所有订单
     * @return
     */
    List<Orders> findAll(int pageNum,int pageSize);
}
