package com.easondongh.dao;

import com.easondongh.entity.User;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import java.time.LocalDateTime;

/**
 * @author EasonDongH
 * @date 2020/1/21 13:56
 */
@RunWith(SpringRunner.class)
@SpringBootTest
public class InsertTest {

    @Autowired
    private UserMapper userMapper;

    @Test
    public void testInsert(){
        User user = new User();
        user.setName("王雨");
        user.setAge(38);
        user.setManagerId(1088248166370832385L);
        user.setCreateTime(LocalDateTime.now());
        int rows = this.userMapper.insert(user);
        System.out.println(rows);
    }
}
