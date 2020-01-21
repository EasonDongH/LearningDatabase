package com.easondongh.entity;

import com.baomidou.mybatisplus.annotation.SqlCondition;
import com.baomidou.mybatisplus.annotation.TableField;
import com.baomidou.mybatisplus.annotation.TableId;
import com.baomidou.mybatisplus.annotation.TableName;
import lombok.Data;

import java.io.Serializable;
import java.time.LocalDateTime;

/**
 * @author EasonDongH
 * @date 2020/1/21 11:01
 */
@Data
@TableName("user")
public class User implements Serializable {

    // 唯一id
    @TableId
    private Long id;
    // 姓名
    @TableField(condition = SqlCondition.LIKE)
    private String name;
    // 年龄
    @TableField(condition = "%s&gt;#{%s}")
    private Integer age;
    // 邮箱
    private String email;
    // 直属上级id
    private Long managerId;
    // 创建时间
    private LocalDateTime createTime;

    @TableField(exist = false)
    private  String remark;
}
