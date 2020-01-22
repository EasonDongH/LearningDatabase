package com.easondongh.dao;

import com.baomidou.mybatisplus.core.toolkit.Wrappers;
import com.easondongh.entity.User;
import com.easondongh.service.UserService;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import java.util.Arrays;
import java.util.List;

/**
 * @author EasonDongH
 * @date 2020/1/22 13:48
 */
@RunWith(SpringRunner.class)
@SpringBootTest
public class ServiceTest {

    @Autowired
    private UserService userService;

    @Test
    public void testSelectOne(){
        // 第二个参数为false时，查询结果多个时返回第一个，并打印WARN
        User one = this.userService.getOne(Wrappers.<User>lambdaQuery().gt(User::getAge, 20), false);
        System.out.println(one);
    }

    @Test
    public void testSelectByChain(){
        List<User> list = this.userService.lambdaQuery().gt(User::getAge, 20).like(User::getName, "李").list();
        list.forEach(System.out::println);
    }

    @Test
    public void testInsert(){
        User user = new User();
        user.setName("王大力");
        boolean save = this.userService.save(user);
        System.out.println(save);
    }

    @Test
    public void testInsertBatch(){
        User user1 = new User();
        user1.setName("李林");
        User user2 = new User();
        user2.setName("李林2");

        boolean saveBatch = this.userService.saveBatch(Arrays.asList(user1, user2));
        System.out.println(saveBatch);
    }

    @Test
    public void testSaveOrUpdate(){
        User user1 = new User();
        user1.setId(1219860642765533186L);
        user1.setName("李林3");
        User user2 = new User();
        user2.setName("李林4");

        boolean saveBatch = this.userService.saveOrUpdateBatch(Arrays.asList(user1, user2));
        System.out.println(saveBatch);
    }
}
