package com.easondongh.mapper;

import com.easondongh.domain.User;
import org.apache.ibatis.annotations.Param;
import org.apache.ibatis.annotations.Select;

public interface UserMapper {

    @Select("select * from users where id = #{id}")
    User selectUser(String id);

    @Select("select * from users where id = #{id} and username = #{username}")
    User selectUserByIdAndName(@Param(value = "id") String id, @Param(value = "username") String username);
}
