package com.easondongh.service;

import com.easondongh.domain.SysLog;

import java.util.List;

public interface SysLogService {

    /**
     * 保存系统日志
     * @param log
     * @return
     */
    boolean save(SysLog log);

    /**
     * 获取所有系统日志
     * @return
     */
    List<SysLog> findAll();
}
