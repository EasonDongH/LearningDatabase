package com.easondongh.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
@RequestMapping("commonlyAnnotations")
public class CommonlyAnnotations {

    @RequestMapping("testRequestParam")
    public String testRequestParam(@RequestParam("username") String name){
        System.out.println(name);
        return "success";
    }

    @RequestMapping("testRequestBody")
    public String testRequestBody(@RequestBody String body){
        System.out.println(body);
        return "success";
    }

    @RequestMapping("testPathVariable/{uid}")
    public String testPathVariable(@PathVariable(name = "uid")String id){
        System.out.println(id);
        return "success";
    }


}
