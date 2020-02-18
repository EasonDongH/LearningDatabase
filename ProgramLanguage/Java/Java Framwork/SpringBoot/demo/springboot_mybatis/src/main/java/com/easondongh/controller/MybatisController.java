package com.easondongh.controller;

import com.easondongh.domain.User;
import com.easondongh.mapper.UserMapper;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import javax.sql.DataSource;
import java.util.List;

@RestController
@Slf4j
public class MybatisController {

    @Autowired
    private UserMapper userMapper;

    @RequestMapping("/query")
    public String query() {
//        List<User> userList = userMapper.queryUserList();
//        return userList.toString();
        log.debug("query is running");
        return "Query";
    }
}
