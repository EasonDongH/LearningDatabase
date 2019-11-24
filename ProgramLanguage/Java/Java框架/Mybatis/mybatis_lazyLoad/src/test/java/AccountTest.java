import dao.IAccountDao;
import domain.Account;
import org.apache.ibatis.io.Resources;
import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.ibatis.session.SqlSessionFactoryBuilder;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import java.io.IOException;
import java.io.InputStream;
import java.util.List;

public class AccountTest {
    private InputStream in;
    private SqlSession sqlSession;
    private IAccountDao accountDao;
    SqlSessionFactory factory;

    @Before//用于在测试方法执行之前执行
    public void init()throws Exception{
        //1.读取配置文件，生成字节输入流
        in = Resources.getResourceAsStream("SqlMapConfig.xml");
        //2.获取SqlSessionFactory
        factory = new SqlSessionFactoryBuilder().build(in);
        //3.获取SqlSession对象
        sqlSession = factory.openSession();
        //4.获取dao的代理对象
        accountDao = sqlSession.getMapper(IAccountDao.class);
    }

    @After//用于在测试方法执行之后执行
    public void destroy()throws Exception{
        //提交事务
        sqlSession.commit();
        //6.释放资源
        sqlSession.close();
        in.close();
    }

    @Test
    public void testFindAll(){
        List<Account> accountList = this.accountDao.findAll();
        for (Account account : accountList) {
            System.out.println(account);
        }
    }

    @Test
    public void testFindAccountByUid() throws IOException {
        Account account1 = this.accountDao.findAccountByUid(1);

//        InputStream in2 = Resources.getResourceAsStream("SqlMapConfig.xml");
//        //2.获取SqlSessionFactory
//        SqlSessionFactory factory2 = new SqlSessionFactoryBuilder().build(in2);
//        //3.获取SqlSession对象
//        SqlSession sqlSession2 = factory2.openSession();
//        //4.获取dao的代理对象
//        IAccountDao accountDao2 = sqlSession2.getMapper(IAccountDao.class);

        Account account2 = accountDao.findAccountByUid(1);

        System.out.println(account1 == account2);
    }
}
