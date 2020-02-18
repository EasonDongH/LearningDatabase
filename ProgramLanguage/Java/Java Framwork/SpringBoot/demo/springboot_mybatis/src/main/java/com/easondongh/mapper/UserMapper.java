package com.easondongh.mapper;

import com.baomidou.mybatisplus.core.mapper.BaseMapper;
import com.easondongh.domain.User;
import org.apache.ibatis.annotations.Mapper;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface UserMapper extends BaseMapper<User> {
}
