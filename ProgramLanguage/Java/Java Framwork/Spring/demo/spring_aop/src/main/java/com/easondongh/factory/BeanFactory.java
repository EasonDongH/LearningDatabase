package com.easondongh.factory;

import com.easondongh.service.AccountService;

import java.lang.reflect.InvocationHandler;
import java.lang.reflect.Method;
import java.lang.reflect.Proxy;

public class BeanFactory {

    private AccountService accountService;

    public void setAccountService(AccountService accountService) {
        this.accountService = accountService;
    }

    public AccountService getAccountService() {
        return (AccountService) Proxy.newProxyInstance(accountService.getClass().getClassLoader(), accountService.getClass().getInterfaces(),
                new InvocationHandler() {
                    public Object invoke(Object proxy, Method method, Object[] args) throws Throwable {
                        Object result = false;
                        try {
                            result = method.invoke(accountService, args);
                        } catch (Exception e) {
                            e.printStackTrace();
                            System.out.println("回滚：交易取消");
                        }
                        return result;
                    }
                });
    }
}
