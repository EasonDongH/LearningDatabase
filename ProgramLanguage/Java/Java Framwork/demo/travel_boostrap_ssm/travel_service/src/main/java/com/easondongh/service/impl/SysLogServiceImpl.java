package com.easondongh.service.impl;

import com.easondongh.dao.SysLogDao;
import com.easondongh.domain.SysLog;
import com.easondongh.service.SysLogService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Service("sysLogService")
@Transactional
public class SysLogServiceImpl implements SysLogService {

    @Autowired
    private SysLogDao sysLogDao;

    @Override
    public boolean save(SysLog log) {
        return this.sysLogDao.save(log) > 0;
    }

    @Override
    public List<SysLog> findAll() {
        return this.sysLogDao.findAll();
    }
}
