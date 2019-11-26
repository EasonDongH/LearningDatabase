import domain.User;
import org.junit.Test;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import service.UserService;

import java.util.List;

public class UserServiceTest {

    @Test
    public void testListAllUsers(){
        ApplicationContext ac = new ClassPathXmlApplicationContext("bean.xml");
        UserService userService = ac.getBean("userService", UserService.class);
        List<User> users = userService.listAllUsers();
        for (User user : users) {
            System.out.println(user);
        }
    }

    @Test
    public void testGetUserById(){
        ApplicationContext ac = new ClassPathXmlApplicationContext("bean.xml");
        UserService userService = ac.getBean("userService", UserService.class);
        User user = userService.getUserById(3);
        System.out.println(user);
    }

    @Test
    public void testUpdateUser(){
        ApplicationContext ac = new ClassPathXmlApplicationContext("bean.xml");
        UserService userService = ac.getBean("userService", UserService.class);
        User user = new User();
        user.setId(3);
        user.setName("test-2019-11-26-20-45");
        user.setPassword("abc12345");
        userService.update(user);
    }

    @Test
    public void testSaveUser(){
        ApplicationContext ac = new ClassPathXmlApplicationContext("bean.xml");
        UserService userService = ac.getBean("userService", UserService.class);
        User user = new User();
        user.setName("test-2019-11-26-20-47");
        user.setPassword("abc12345");
        userService.saveUser(user);
    }

    @Test
    public void testRemoveUser(){
        ApplicationContext ac = new ClassPathXmlApplicationContext("bean.xml");
        UserService userService = ac.getBean("userService", UserService.class);
        userService.removeUser(7);
    }
}
