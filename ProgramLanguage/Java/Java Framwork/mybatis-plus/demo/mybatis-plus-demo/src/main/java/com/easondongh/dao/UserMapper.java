package com.easondongh.dao;

import com.baomidou.mybatisplus.core.mapper.BaseMapper;
import com.easondongh.entity.User;
import org.apache.ibatis.annotations.Mapper;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Repository;

/**
 * 用户Mapper
 * @author EasonDongH
 * @date 2020/1/21 11:29
 */
//@Mapper
@Repository
public interface UserMapper extends BaseMapper<User> {

}
