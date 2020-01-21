package com.easondongh.service;

public interface AccountService {

    public void save();

    /**
     * source向target转账money金额
     * @param source
     * @param target
     * @param money
     */
    boolean transfer(String source,String target, double money);
}
