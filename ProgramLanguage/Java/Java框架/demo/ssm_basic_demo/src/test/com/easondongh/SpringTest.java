package com.easondongh;

import com.easondongh.domain.User;
import com.easondongh.service.UserService;
import org.junit.Test;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

public class SpringTest {

    @Test
    public void test1(){
        ApplicationContext ac = new ClassPathXmlApplicationContext("applicationContext.xml") ;
        UserService userService = ac.getBean("userService", UserService.class);
        userService.listAll();
    }

    @Test
    public void testTransaction(){
        ApplicationContext ac = new ClassPathXmlApplicationContext("applicationContext.xml") ;
        UserService userService = ac.getBean("userService", UserService.class);
        User user = new User();
        user.setName("testTransaction_SaveUser");
        user.setPassword("123456");
        userService.save(user);
    }
}
