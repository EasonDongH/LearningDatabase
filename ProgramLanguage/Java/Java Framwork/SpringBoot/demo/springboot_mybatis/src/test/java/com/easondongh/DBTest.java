package com.easondongh;

import com.easondongh.domain.User;
import com.easondongh.mapper.UserMapper;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import java.time.LocalDateTime;

/**
 * @author EasonDongH
 * @date 2020/2/18 19:55
 */
@RunWith(SpringRunner.class)
@SpringBootTest
public class DBTest {

    @Autowired
    private UserMapper userMapper;

    @Test
    public void testSelectOne() {

    }

    @Test
    public void testInsert() {
        User user = new User();
        user.setName("王雨");
        user.setAge(38);
        user.setManagerId(1088248166370832385L);
        user.setCreateTime(LocalDateTime.now());
        int rows = this.userMapper.insert(user);
        System.out.println(rows);
    }
}
