package com.easondongh.service.impl;

import com.baomidou.mybatisplus.core.mapper.BaseMapper;
import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.easondongh.entity.User;
import com.easondongh.service.UserService;
import org.springframework.stereotype.Service;

/**
 * @author EasonDongH
 * @date 2020/1/22 13:46
 */
@Service
public class UserServiceImpl extends ServiceImpl<BaseMapper<User>,User> implements UserService {
}
