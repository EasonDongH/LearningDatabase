package com.easondongh.service.impl;

import com.easondongh.dao.UserDao;
import com.easondongh.domain.Role;
import com.easondongh.domain.UserInfo;
import com.easondongh.service.UserService;
import com.easondongh.util.UuidUtil;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.ArrayList;
import java.util.List;

@Service("userService")
@Transactional
public class UserServiceImpl implements UserService {

    @Autowired
    private UserDao userDao;

    @Autowired
    private BCryptPasswordEncoder bCryptPasswordEncoder;

    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        UserInfo userInfo = this.userDao.findByUsername(username);
        List<Role> roles = userInfo.getRoles();
        User user = new User(userInfo.getUsername(), userInfo.getPassword(), userInfo.getStatus()==1,true,true,true , getAuthorities(roles));
        return user;
    }

    /**
     * 根据Role封装Authority
     * @param roles
     * @return
     */
    private List<SimpleGrantedAuthority> getAuthorities(List<Role> roles){
        List<SimpleGrantedAuthority> authorities = new ArrayList<>();
        for (Role role : roles) {
            authorities.add(new SimpleGrantedAuthority(role.getRoleName()));
        }
        return authorities;
    }

    @Override
    public boolean saveUser(UserInfo userInfo) {
        userInfo.setId(UuidUtil.getUuid());
        userInfo.setPassword(bCryptPasswordEncoder.encode(userInfo.getPassword()));
        int result = this.userDao.saveUser(userInfo);
        return result > 0;
    }

    @Override
    public List<UserInfo> findAll() {
        return this.userDao.findAll();
    }

    @Override
    public UserInfo findById(String id) {
        return this.userDao.findById(id);
    }

    public static void main(String[] args) {
        BCryptPasswordEncoder bCryptPasswordEncoder = new BCryptPasswordEncoder();
        String encode = bCryptPasswordEncoder.encode("test");
        System.out.println(encode);
    }
}
