package com.easondongh.componet;

import com.easondongh.domain.SysLog;
import com.easondongh.service.SysLogService;
import com.easondongh.util.UuidUtil;
import org.aspectj.lang.JoinPoint;
import org.aspectj.lang.annotation.After;
import org.aspectj.lang.annotation.Aspect;
import org.aspectj.lang.annotation.Before;
import org.aspectj.lang.annotation.Pointcut;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.context.SecurityContext;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.User;
import org.springframework.stereotype.Component;
import org.springframework.web.bind.annotation.RequestMapping;

import javax.servlet.http.HttpServletRequest;
import java.lang.reflect.Method;
import java.util.Date;

@Component
@Aspect
public class LogAop {

    @Autowired
    private HttpServletRequest request;
    @Autowired
    private SysLogService sysLogService;

    private Date visitTime;

    @Pointcut("execution(* com.easondongh.controller.*.save*(..))")
    public void savePointcut(){
    }

    @Pointcut("execution(* com.easondongh.controller.*.add*(..))")
    public void addPointcut(){
    }

    @Before("savePointcut() || addPointcut()")
    public void doBefore(JoinPoint joinPoint){
        this.visitTime = new Date();
    }

    @After("savePointcut() || addPointcut()")
    public void doAfter(JoinPoint joinPoint) throws NoSuchMethodException {
        String id = UuidUtil.getUuid();
        String ip = request.getRemoteAddr();
        String username = getUserName();
        long executionTime = new Date().getTime() - this.visitTime.getTime();
        Class executionClass = joinPoint.getTarget().getClass();
        Method executionMethod = null;
        if(executionClass != null) {
            String executionMethodName = joinPoint.getSignature().getName();
            Object[] args = joinPoint.getArgs();
            if(args == null || args.length == 0) {
                executionMethod = executionClass.getMethod(executionMethodName);
            } else {
                Class[] classArgs = new Class[args.length];
                for (int i=0; i<args.length;i++) {
                    classArgs[i] = args[i].getClass();
                }
                executionMethod = executionClass.getMethod(executionMethodName,classArgs);
            }
        }
        String url = getUrl(executionClass,executionMethod);
        String method = getMethodUri(executionClass,executionMethod);
        SysLog log = new SysLog();
        log.setId(id);
        log.setVisitTime(this.visitTime);
        log.setIp(ip);
        log.setUsername(username);
        log.setUrl(url);
        log.setMethod(method);
        log.setExecutionTime(executionTime);
        this.sysLogService.save(log);
    }

    private String getUserName(){
        SecurityContext securityContext = SecurityContextHolder.getContext();
        User user = (User) securityContext.getAuthentication().getPrincipal();
        if(user != null) {
            return user.getUsername();
        } else {
            return "";
        }
    }

    private String getMethodUri(Class executionClass, Method executionMethod){
        String uri = "";
        if(executionClass != null) {
            uri = "[类名]" + executionClass.getName();
        }
        if(executionMethod != null) {
            uri += "[方法名]" + executionMethod.getName();
        }
        return uri;
    }

    private String getUrl(Class executionClass, Method executionMethod){
        String url = "";
        if(executionClass != null) {
            RequestMapping classAnnotation = (RequestMapping) executionClass.getAnnotation(RequestMapping.class);
            if(classAnnotation != null) {
                url = classAnnotation.value()[0];
            }
        }
        if(executionMethod != null) {
            RequestMapping methodAnnotation = executionMethod.getAnnotation(RequestMapping.class);
            if(methodAnnotation != null) {
                url += methodAnnotation.value()[0];
            }
        }
        return url;
    }
}
