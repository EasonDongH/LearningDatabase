package com.easondongh.dao;

import com.baomidou.mybatisplus.core.conditions.query.LambdaQueryWrapper;
import com.baomidou.mybatisplus.core.toolkit.Wrappers;
import com.easondongh.entity.User;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import java.sql.Wrapper;
import java.util.Arrays;

/**
 * @author EasonDongH
 * @date 2020/1/22 11:05
 */
@RunWith(SpringRunner.class)
@SpringBootTest
public class DeleteTest {

    @Autowired
    private UserMapper userMapper;

    @Test
    public void testDeleteById(){
        int count = this.userMapper.deleteById(1219518931401039874L);
        System.out.println("影响记录数：" + count);
    }

    @Test
    public void testDeleteByBatchIds(){
        int count = this.userMapper.deleteBatchIds(Arrays.asList(1094592041087729666L,1094590409767661570L));
        System.out.println("影响记录数：" + count);
    }

    @Test
    public void testDeleteByWrapper(){
        LambdaQueryWrapper<User> lambdaQueryWrapper = Wrappers.<User>lambdaQuery();
        lambdaQueryWrapper.eq(User::getAge, 35);
        int count = this.userMapper.delete(lambdaQueryWrapper);
        System.out.println("影响记录数：" + count);
    }
}
