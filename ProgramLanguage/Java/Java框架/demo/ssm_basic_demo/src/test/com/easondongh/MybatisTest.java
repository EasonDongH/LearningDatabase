package com.easondongh;

import com.easondongh.dao.UserDao;
import com.easondongh.domain.User;
import org.apache.ibatis.io.Resources;
import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.ibatis.session.SqlSessionFactoryBuilder;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.springframework.test.context.junit4.SpringRunner;

import java.io.IOException;
import java.io.InputStream;
import java.util.List;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations = { "classpath*:/applicationContext.xml"})
public class MybatisTest {

    @Autowired
    private UserDao userDao;

    @Test
    public void testListAll() throws IOException {
//        InputStream inputStream = Resources.getResourceAsStream("SqlMapConfig.xml");
//        SqlSessionFactory sessionFactory = new SqlSessionFactoryBuilder().build(inputStream);
//        SqlSession session = sessionFactory.openSession();
//        UserDao userDao = session.getMapper(UserDao.class);
        List<User> users = userDao.listAll();
        System.out.println(users);
    }

    @Test
    public void testSaveUser() throws IOException {
        InputStream inputStream = Resources.getResourceAsStream("SqlMapConfig.xml");
        SqlSessionFactory sessionFactory = new SqlSessionFactoryBuilder().build(inputStream);
        SqlSession session = sessionFactory.openSession();
        UserDao userDao = session.getMapper(UserDao.class);
       User user = new User();
       user.setName("mybatis_testSaveUser");
       user.setPassword("123456");
       userDao.save(user);
       session.commit();
    }
}
