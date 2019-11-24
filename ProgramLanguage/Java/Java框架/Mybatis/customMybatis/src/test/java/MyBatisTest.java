
import dao.UserDao;
import domain.User;
import mybatis.io.Resources;
import mybatis.sqlsession.SqlSession;
import mybatis.sqlsession.SqlSessionFactory;
import mybatis.sqlsession.SqlSessionFactoryBuilder;

import java.io.IOException;
import java.io.InputStream;
import java.util.List;

public class MyBatisTest {
    public static void main(String[] args) throws IOException {
        InputStream inputStream = Resources.getResourceAsStream("SqlMapConfig.xml");
        SqlSessionFactoryBuilder builder = new SqlSessionFactoryBuilder();
        SqlSessionFactory factory = builder.build(inputStream);
        SqlSession session = factory.openSession();
        UserDao userDao = session.getMapper(UserDao.class);
        List<User> userList = userDao.listAll();
        for (User user : userList) {
            System.out.println(user);
        }
        session.close();
        inputStream.close();
    }
}
