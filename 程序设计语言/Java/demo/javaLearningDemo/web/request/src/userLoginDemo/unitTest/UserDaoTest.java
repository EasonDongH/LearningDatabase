package userLoginDemo.unitTest;

import org.junit.Test;
import userLoginDemo.User;
import userLoginDemo.UserDao;

public class UserDaoTest {
    @Test
    public void testLogin(){
        User loginUser = new User();
        loginUser.setName("张三");
        loginUser.setPassword("123456");
        UserDao dao = new UserDao();
        User user = dao.login(loginUser);
        System.out.println(user);
    }
}
