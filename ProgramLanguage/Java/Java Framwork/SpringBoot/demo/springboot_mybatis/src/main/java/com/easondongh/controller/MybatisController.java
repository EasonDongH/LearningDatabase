package com.easondongh.controller;

import com.easondongh.domain.User;
import com.easondongh.mapper.UserMapper;
import lombok.extern.slf4j.Slf4j;
import org.apache.ibatis.annotations.Param;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import javax.sql.DataSource;
import java.util.List;

@RestController
@Slf4j
public class MybatisController {

    @Autowired
    private UserMapper userMapper;

    @RequestMapping("/query/{id}")
    public User query(@PathVariable("id") Long id) {
        User user = this.userMapper.selectById(id);
        return user;
    }
}
