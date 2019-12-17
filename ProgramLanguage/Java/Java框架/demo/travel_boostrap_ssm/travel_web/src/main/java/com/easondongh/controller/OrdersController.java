package com.easondongh.controller;

import com.easondongh.domain.Orders;
import com.easondongh.service.OrdersService;
import com.github.pagehelper.PageInfo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.ModelAndView;

import java.util.List;

@Controller
@RequestMapping("/orders")
public class OrdersController {

    @Autowired
    private OrdersService ordersService;

    @RequestMapping("/findAll.do")
    public ModelAndView findAll(@RequestParam(name = "pageNum", required = true,defaultValue = "1") int pageNum, @RequestParam(name = "pageSize", required = true,defaultValue = "5") int pageSize){
        ModelAndView mv = new ModelAndView();
        List<Orders> list = this.ordersService.findAll(pageNum,pageSize);
        PageInfo pageInfo = new PageInfo(list);
        mv.addObject("pageInfo", pageInfo);
        mv.setViewName("orders-list");
        return mv;
    }
}
