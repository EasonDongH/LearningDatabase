package com.easondongh.dao;

import com.easondongh.entity.User;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import java.util.List;

/**
 * @author EasonDongH
 * @date 2020/1/22 14:44
 */
@RunWith(SpringRunner.class)
@SpringBootTest
public class LogicDeleteTest {

    @Autowired
    private UserMapper userMapper;

    @Test
    public void testLogicDel(){
        int delete = this.userMapper.deleteById(1094592041087729666L);
        System.out.println(delete);
    }

    @Test
    public void testSelect(){
        List<User> userList = this.userMapper.selectList(null);
    }
}
