package com.easondongh.controller;

import com.easondongh.domain.Account;
import com.easondongh.domain.User;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("param")
public class ParamController {

    @RequestMapping("testBindingParam")
    public String testBindingParam(String username, String password) {
        System.out.println("username: " + username);
        System.out.println("password: " + password);
        return "success";
    }

    @RequestMapping("bindingJavaBean")
    public String bindingJavaBean(Account account) {
        System.out.println(account);
        return "success";
    }

    @RequestMapping("saveUser")
    public String saveUser(User user) {
        System.out.println(user);
        return "success";
    }
}
