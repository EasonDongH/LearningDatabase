package com.easondongh.domain;

import com.baomidou.mybatisplus.annotation.*;
import lombok.Data;

import java.io.Serializable;
import java.time.LocalDateTime;

@Data
@TableName("user")
public class User implements Serializable {
    // 唯一id
    @TableId
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
    @Version
    private Integer version;
    // 逻辑删除标记
    @TableLogic
    @TableField(select = false)
    private Integer deleted;
}
