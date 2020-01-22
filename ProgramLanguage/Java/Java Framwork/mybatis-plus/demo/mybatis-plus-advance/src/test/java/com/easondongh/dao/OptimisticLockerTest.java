package com.easondongh.dao;

import com.easondongh.entity.User;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

/**
 * @author EasonDongH
 * @date 2020/1/22 15:57
 */
@RunWith(SpringRunner.class)
@SpringBootTest
public class OptimisticLockerTest {

    @Autowired
    private UserMapper userMapper;

    @Test
    public void testUpdate(){
        int version = 1;
        User user = new User();
        user.setId(1094592041087729666L);
        user.setEmail("lhm2@baomidou.com");
        user.setVersion(version);
        int rows = this.userMapper.updateById(user);
        System.out.println(rows);
        System.out.println(user.getVersion());
    }
}
