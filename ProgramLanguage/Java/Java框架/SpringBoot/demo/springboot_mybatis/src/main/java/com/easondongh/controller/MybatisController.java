package com.easondongh.controller;

import com.easondongh.domain.User;
import com.easondongh.mapper.UserMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
public class MybatisController {

    @Autowired
    private UserMapper userMapper;

    @RequestMapping("/query")
    public String query(){
        List<User> userList = userMapper.queryUserList();
        return userList.toString();
    }
}
