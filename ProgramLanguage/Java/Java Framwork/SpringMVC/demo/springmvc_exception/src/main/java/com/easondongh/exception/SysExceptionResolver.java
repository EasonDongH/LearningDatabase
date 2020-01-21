package com.easondongh.exception;

import org.springframework.web.servlet.HandlerExceptionResolver;
import org.springframework.web.servlet.ModelAndView;

public class SysExceptionResolver implements HandlerExceptionResolver {
    @Override
    public ModelAndView resolveException(javax.servlet.http.HttpServletRequest httpServletRequest, javax.servlet.http.HttpServletResponse httpServletResponse, Object o, Exception e) {
        SysException exception = null;
        if(e instanceof SysException){
            exception = (SysException)e;
        } else {
            exception = new SysException(e.getMessage());
        }
        ModelAndView mv = new ModelAndView();
        mv.addObject("errorMsg", exception.getMessage());
        mv.setViewName("error");
        return mv;
    }
}
