package com.easondongh.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
public class HelloController {

    @RequestMapping(path = "/hello")
    public String saveHello(){
        System.out.println("Hello SpringMVC");
        return "success";
    }
}
