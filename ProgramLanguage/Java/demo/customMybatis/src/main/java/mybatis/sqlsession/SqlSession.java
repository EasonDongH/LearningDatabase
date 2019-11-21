package mybatis.sqlsession;

public interface SqlSession {

     <T> T getMapper(Class<T> tClass);

     void close();
}
