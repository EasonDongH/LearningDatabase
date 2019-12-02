package com.easondongh.service.impl;

import com.easondongh.service.AccountService;
import org.springframework.stereotype.Service;

@Service("accountService")
public class AccountServiceImpl implements AccountService {

    private Integer test;

    public void save() {
//        int i = 1/0;
        System.out.println("执行了保存");
    }

    public boolean transfer(String source, String target, double money) {
        System.out.println("从" + source + "减去金额：" + money);
        System.out.println("给" + target + "增加金额：" + money);
        return true;
    }
}
