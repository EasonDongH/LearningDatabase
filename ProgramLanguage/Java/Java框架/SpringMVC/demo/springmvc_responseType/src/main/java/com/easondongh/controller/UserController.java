package com.easondongh.controller;

import com.easondongh.domain.User;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

@Controller
@RequestMapping("user")
public class UserController {

    @RequestMapping("testReturnString")
    public String testReturnString(Model model){
        // 模拟从数据库查数据
        User user = new User();
        user.setName("你好a");
        user.setPassword("abc12345");

        model.addAttribute("user",user);

        return "success";
    }

    @RequestMapping("testReturnModelAndView")
    public ModelAndView testReturnModelAndView(){
        ModelAndView modelAndView = new ModelAndView();

        // 模拟从数据库查数据
        User user = new User();
        user.setName("米ing吧");
        user.setPassword("abc12345");

        modelAndView.addObject("user", user);

        modelAndView.setViewName("success");

        return modelAndView;
    }

    /**
     * 传入的是JSON，框架自动通过jackson转User对象
     * 返回的是User对象，框架自动转JSON字符串
     * @param user
     * @return
     */
    @RequestMapping("testReturnJSON")
    public @ResponseBody User testReturnJSON(@RequestBody User user){
        user.setName("已修改的JSON对象");
        return user;
    }
}
