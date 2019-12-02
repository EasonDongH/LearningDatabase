package com.easondongh.controller;

import com.easondongh.exception.SysException;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("/user")
public class UserController {

    @RequestMapping("/saveUser")
    public String saveUser() throws SysException{
        try {
            int i = 10 / 0;
        } catch (Exception e){
            e.printStackTrace();
            throw e;
        }
        return "success";
    }
}
