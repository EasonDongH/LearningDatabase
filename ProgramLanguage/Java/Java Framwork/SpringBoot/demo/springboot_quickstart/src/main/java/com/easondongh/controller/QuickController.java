package com.easondongh.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

@Controller
public class QuickController {

    @RequestMapping("/quick")
    @ResponseBody
    public String quick(){
        return "你好 SpringBoot";
    }
}
