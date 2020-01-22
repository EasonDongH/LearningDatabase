package com.easondongh.dao;

import com.baomidou.mybatisplus.core.conditions.update.LambdaUpdateWrapper;
import com.baomidou.mybatisplus.core.conditions.update.UpdateWrapper;
import com.baomidou.mybatisplus.extension.service.additional.update.impl.LambdaUpdateChainWrapper;
import com.easondongh.entity.User;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

/**
 * @author EasonDongH
 * @date 2020/1/22 10:25
 */
@RunWith(SpringRunner.class)
@SpringBootTest
public class UpdateTest {

    @Autowired
    private UserMapper userMapper;

    @Test
    public void testUpdateById(){
        User user = new User();
        user.setId(1088248166370832385L);
        user.setAge(30);
        int count = this.userMapper.updateById(user);
        System.out.println("影响记录数：" + count);
    }

    @Test
    public void testUpdateByWrapper(){
        User user = new User();
        user.setAge(30);
        UpdateWrapper<User> updateWrapper = new UpdateWrapper<>();
        updateWrapper.eq("name", "李艺伟");
        int count = this.userMapper.update(user, updateWrapper);
        System.out.println("影响记录数：" + count);
    }

    @Test
    public void testUpdateByWrapperEntity(){
        User whereUser = new User();
        whereUser.setId(1094590409767661570L);
        User user = new User();
        user.setAge(30);
        UpdateWrapper<User> updateWrapper = new UpdateWrapper<>(whereUser);
        int count = this.userMapper.update(user, updateWrapper);
        System.out.println("影响记录数：" + count);
    }

    @Test
    public void testUpdateByWrapperSet(){
        UpdateWrapper<User> updateWrapper = new UpdateWrapper<>();
        updateWrapper.eq("id", 1094592041087729666L).set("age" , 30);
        int count = this.userMapper.update(null, updateWrapper);
        System.out.println("影响记录数：" + count);
    }

    @Test
    public void testUpdateByLambda(){
        LambdaUpdateWrapper<User> lambdaUpdateWrapper = new UpdateWrapper<User>().lambda();
        lambdaUpdateWrapper.eq(User::getId, 1094592041087729666L).set(User::getAge , 30);
        int count = this.userMapper.update(null, lambdaUpdateWrapper);
        System.out.println("影响记录数：" + count);
    }

    @Test
    public void testUpdateByLambdaChain(){
        boolean update = new LambdaUpdateChainWrapper<User>(this.userMapper).eq(User::getId, 1094592041087729666L )
                .set(User::getAge , 30).update();
        System.out.println("是否修改成功：" + update);
    }
}
