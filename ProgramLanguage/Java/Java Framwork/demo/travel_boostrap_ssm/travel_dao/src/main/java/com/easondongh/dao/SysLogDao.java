package com.easondongh.dao;

import com.easondongh.domain.SysLog;
import org.apache.ibatis.annotations.Insert;
import org.apache.ibatis.annotations.Select;

import java.util.List;

public interface SysLogDao {

    /**
     * 保存系统日志
     * @param log
     * @return
     */
    @Insert("insert into syslog(id,visitTime,username,ip,url,executionTime,method) " +
            "values(#{id},#{visitTime},#{username},#{ip},#{url},#{executionTime},#{method})")
    int save(SysLog log);

    /**
     * 查找所有系统日志
     * @return
     */
    @Select("select * from syslog")
    List<SysLog> findAll();
}
