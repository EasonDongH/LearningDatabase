package com.easondongh;

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
}
