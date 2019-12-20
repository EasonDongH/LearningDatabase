package com.easondongh.controller;

import com.easondongh.domain.UserInfo;
import com.easondongh.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;

import java.util.List;

@Controller
@RequestMapping("/user")
public class UserController {

    @Autowired
    private UserService userService;

    /**
     * 添加用户
     * @param userInfo
     * @return
     */
    @RequestMapping("/saveUser.do")
    public String saveUser(UserInfo userInfo) {
        ModelAndView mv = new ModelAndView();
        boolean saveUser = this.userService.saveUser(userInfo);
        return "redirect:findAll.do";
    }

    @RequestMapping("/findAll.do")
    public ModelAndView findAll(){
        ModelAndView mv = new ModelAndView();
        List<UserInfo> userInfoList = this.userService.findAll();
        mv.addObject("userList", userInfoList);
        mv.setViewName("user-list");
        return mv;
    }

    @RequestMapping("/findById.do")
    public ModelAndView findById(String id){
        ModelAndView mv = new ModelAndView();
        UserInfo userInfo = this.userService.findById(id);
        mv.addObject("userInfo",userInfo );
        mv.setViewName("user-show");
        return mv;
    }
}
