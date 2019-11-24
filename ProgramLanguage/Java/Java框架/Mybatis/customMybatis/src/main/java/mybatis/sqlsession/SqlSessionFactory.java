package mybatis.sqlsession;

public interface SqlSessionFactory {

    /**
     * 新建并返回SqlSession对象
     * @return
     */
    SqlSession openSession();

}
