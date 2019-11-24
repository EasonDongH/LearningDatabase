
import dao.UserDao;
import domain.QueryVo;
import domain.User;
import org.apache.ibatis.io.Resources;
import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.ibatis.session.SqlSessionFactoryBuilder;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import sun.rmi.server.UnicastServerRef;

import java.io.IOException;
import java.io.InputStream;
import java.util.Date;
import java.util.List;
import java.util.Random;

public class MyBatisTest {
    InputStream inputStream;
    SqlSession session;
    UserDao userDao;

    @Before
    public void init() throws IOException {
        inputStream = Resources.getResourceAsStream("SqlMapConfig.xml");
        SqlSessionFactoryBuilder builder = new SqlSessionFactoryBuilder();
        SqlSessionFactory factory = builder.build(inputStream);
        session = factory.openSession();
        userDao = session.getMapper(UserDao.class);
    }

    @After
    public void destroy() throws IOException {
        this.session.commit();
        session.close();
        inputStream.close();
    }

    /**
     * 测试查询所有用户
     * @throws IOException
     */
    @Test
    public void testListAll() throws IOException {
        List<User> userList = userDao.listAll();
        for (User user : userList) {
            System.out.println(user);
        }
    }

    /**
     * 测试保存用户
     */
    @Test
    public void testSaveUser() {
        User user = new User();
        user.setName("test" + new Date().getTime());
        user.setPassword("123456");
        System.out.println(user);
        int result = this.userDao.saveUser(user);
        System.out.println(result);
        System.out.println(user);
    }

    @Test
    public void testGetById(){
        User user = this.userDao.getById(1);
        System.out.println(user);
    }

    @Test
    public void testListByName(){
        List<User> users = this.userDao.listByName("%e%");
        for (User user : users) {
            System.out.println(user);
        }
    }

    @Test
    public void testCountUser(){
        int cnt = this.userDao.countUser();
        System.out.println(cnt);
    }

    @Test
    public void testListByQueryVoName(){
        User user = new User();
        user.setName("%e%");
        QueryVo queryVo =new QueryVo();
        queryVo.setUser(user);
        List<User> users = this.userDao.listByQueryVoName(queryVo);
        for (User item : users) {
            System.out.println(item);
        }
    }
}
