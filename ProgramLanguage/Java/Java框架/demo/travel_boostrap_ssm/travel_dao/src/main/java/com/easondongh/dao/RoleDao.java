package com.easondongh.dao;

import com.easondongh.domain.Role;
import org.apache.ibatis.annotations.Select;

import java.util.List;

public interface RoleDao {

    /**
     * 根据userId查找Role列表
     * @param userId
     * @return
     */
    @Select("select * from role where id in (select roleId from users_role where userId = #{userId})")
    List<Role> findByUserId(String userId);
}
