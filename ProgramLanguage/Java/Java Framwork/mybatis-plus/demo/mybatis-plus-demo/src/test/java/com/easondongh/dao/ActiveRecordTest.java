package com.easondongh.dao;

import com.easondongh.entity.User;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

/**
 * @author EasonDongH
 * @date 2020/1/22 13:00
 */
@RunWith(SpringRunner.class)
@SpringBootTest
public class ActiveRecordTest {

    @Test
    public void testSelect(){
        User user = new User();
        user.setId(1087982257332887553L);
        User user1 = user.selectById();
        System.out.println(user1);
    }
}
