package com.easondongh.config;

import lombok.Data;
import org.springframework.boot.context.properties.ConfigurationProperties;

/**
 * 适合多个地方需要调用这些属性
 * @author EasonDongH
 * @date 2020/2/18 14:55
 */
@ConfigurationProperties(prefix = "jdbc")
@Data
public class JdbcProperties {
    private String driverClassName;
    private String url;
    private String username;
    private String password;
}
