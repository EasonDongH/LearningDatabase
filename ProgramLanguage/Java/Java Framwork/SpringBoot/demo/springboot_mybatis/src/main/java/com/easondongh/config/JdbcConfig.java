package com.easondongh.config;

import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.boot.context.properties.EnableConfigurationProperties;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import javax.sql.DataSource;

/**
 * @author EasonDongH
 * @date 2020/2/18 14:55
 */
@Configuration
//@EnableConfigurationProperties(JdbcProperties.class)
public class JdbcConfig {

//    @Bean
//    public DataSource dataSource(JdbcProperties properties) {
//        DruidDataSource dataSource = new DruidDataSource();
//        dataSource.setDriverClassName(properties.getDriverClassName());
//        dataSource.setUrl(properties.getUrl());
//        dataSource.setUsername(properties.getUsername());
//        dataSource.setPassword(properties.getPassword());
//        return dataSource;
//    }

    /**
     * 这种方式适合仅这一个地方需要使用这些配置信息
     * @return
     */
//    @Bean
//    @ConfigurationProperties(prefix = "jdbc")
//    public DataSource dataSource() {
//        return new DruidDataSource();
//    }
}
