package com.easondongh.log;

import org.aspectj.lang.ProceedingJoinPoint;
import org.aspectj.lang.annotation.*;
import org.springframework.stereotype.Component;

@Component("log")
@Aspect
public class Logger {

    @Pointcut("execution(* com.easondongh.service.impl.*.*(..))")
    private void pc1(){}

    @Before("pc1()")
    public void printBeforeLog(){
        System.out.println("printBeforeLog：执行");
    }

    @AfterReturning("pc1()")
    public void printAfterReturningLog(){
        System.out.println("printAfterReturningLog：执行");
    }

    @AfterThrowing("pc1()")
    public void printAfterThrowingLog(){
        System.out.println("printAfterThrowingLog：执行");
    }

    @After("pc1()")
    public void printAfterLog(){
        System.out.println("printAfterLog：执行");
    }

//    @Around("pc1()")
//    public Object printAroundLog(ProceedingJoinPoint pdjp){
//        Object result = null;
//        try {
//            System.out.println("printAroundLog：前置");
//            result = pdjp.proceed(pdjp.getArgs());
//            System.out.println("printAroundLog：后置");
//        } catch (Throwable t) {
//            System.out.println("printAroundLog：异常");
//        }
//        System.out.println("printAroundLog：最终");
//        return result;
//    }
}
