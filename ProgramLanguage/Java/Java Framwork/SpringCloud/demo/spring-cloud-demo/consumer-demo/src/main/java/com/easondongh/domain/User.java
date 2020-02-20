package com.easondongh.domain;

import lombok.Data;

import java.io.Serializable;
import java.time.LocalDateTime;

/**
 * @author EasonDongH
 * @date 2020/2/19 11:25
 */
@Data
public class User implements Serializable {
    private Long id;
    // 姓名
    private String name;
    // 年龄
    private Integer age;
    // 邮箱
    private String email;
    // 直属上级id
    private Long managerId;
    // 创建时间
    private LocalDateTime createTime;
    // 更新时间
    private LocalDateTime updateTime;
    // 乐观锁版本
    private Integer version;
    // 逻辑删除标记
    private Integer deleted;
}
