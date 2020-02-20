package com.easondongh.mapper;

import com.baomidou.mybatisplus.core.mapper.BaseMapper;
import com.easondongh.domain.User;
import org.springframework.stereotype.Repository;

@Repository
public interface UserMapper extends BaseMapper<User> {
}