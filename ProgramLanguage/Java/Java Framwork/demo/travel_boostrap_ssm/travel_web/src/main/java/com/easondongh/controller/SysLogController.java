package com.easondongh.controller;

import com.easondongh.domain.SysLog;
import com.easondongh.service.SysLogService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;

import java.util.List;

@Controller
@RequestMapping("/sysLog")
public class SysLogController {

    @Autowired
    private SysLogService sysLogService;

    @RequestMapping("/findAll.do")
    public ModelAndView findAll(){
        ModelAndView mv = new ModelAndView();
        List<SysLog> logList = this.sysLogService.findAll();
        mv.addObject("logList", logList);
        mv.setViewName("syslog-list");
        return mv;
    }
}
