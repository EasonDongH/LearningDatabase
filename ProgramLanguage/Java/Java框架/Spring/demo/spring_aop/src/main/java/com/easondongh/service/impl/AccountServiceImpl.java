package com.easondongh.service.impl;

import com.easondongh.service.AccountService;

public class AccountServiceImpl implements AccountService {

    private Integer test;

    public void save() {
        System.out.println("执行了保存");
    }

    public boolean transfer(String source, String target, double money) {
        System.out.println("从" + source + "减去金额：" + money);
        System.out.println("给" + target + "增加金额：" + money);
        return true;
    }
}
