package com.easondongh.controller;

import com.easondongh.domain.User;
import com.easondongh.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.List;

@Controller
@RequestMapping("/user")
public class UserController {

    @Autowired
    private UserService userService;

    @RequestMapping("/listAll")
    public String listAll(Model model){
        List<User> users = userService.listAll();
       model.addAttribute("users", users);
        return "list";
    }

    @RequestMapping("/save")
    public void save(User user, HttpServletRequest request, HttpServletResponse response) throws IOException {
        userService.save(user);
        response.sendRedirect(request.getContextPath() + "/user/listAll");
    }

}
