package mybatis.sqlsession;

import mybatis.cfg.Configuration;
import mybatis.sqlsession.defaults.DefaultSqlSessionFactory;
import mybatis.utils.XMLConfigBuilder;

import java.io.InputStream;

public class SqlSessionFactoryBuilder {

//    public SqlSessionFactory build(InputStream inputStream) {
//        Configuration cfg = XMLConfigBuilder.loadConfiguration(inputStream);
//        return new DefaultSqlSessionFactory(cfg);
//    }

    public SqlSessionFactory build(InputStream config){
        Configuration cfg = XMLConfigBuilder.loadConfiguration(config);
        return  new DefaultSqlSessionFactory(cfg);
    }
}
