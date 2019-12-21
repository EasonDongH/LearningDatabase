package com.easondongh.controller;

import com.easondongh.domain.Role;
import com.easondongh.domain.UserInfo;
import com.easondongh.service.RoleService;
import com.easondongh.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.ModelAndView;

import java.util.List;

@Controller
@RequestMapping("/user")
public class UserController {

    @Autowired
    private UserService userService;
    @Autowired
    private RoleService roleService;

    /**
     * 添加用户
     *
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
    public ModelAndView findAll() {
        ModelAndView mv = new ModelAndView();
        List<UserInfo> userInfoList = this.userService.findAll();
        mv.addObject("userList", userInfoList);
        mv.setViewName("user-list");
        return mv;
    }

    @RequestMapping("/findById.do")
    public ModelAndView findById(String id) {
        ModelAndView mv = new ModelAndView();
        UserInfo userInfo = this.userService.findById(id);
        mv.addObject("userInfo", userInfo);
        mv.setViewName("user-show");
        return mv;
    }

    @RequestMapping("/findUserByIdAndAllRole.do")
    public ModelAndView findUserByIdAndAllRole(@RequestParam(name = "id", required = true) String userId) {
        ModelAndView mv = new ModelAndView();
        UserInfo userInfo = this.userService.findById(userId);
        List<Role> roleList = this.userService.findOtherRole(userId);
        mv.addObject("user", userInfo);
        mv.addObject("roleList", roleList);
        mv.setViewName("user-role-add");
        return mv;
    }

    @RequestMapping("/addRolesToUser.do")
    public String addRolesToUser(String userId, String[] ids) {
        this.userService.addRolesToUser(userId, ids);
        return "redirect:findAll.do";
    }
}
