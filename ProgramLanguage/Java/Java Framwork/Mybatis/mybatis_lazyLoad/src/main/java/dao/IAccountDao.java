package dao;

import domain.Account;

import java.util.List;

/**
 * @author 黑马程序员
 * @Company http://www.ithiema.com
 */
public interface IAccountDao {

    /**
     * 查询所有账户，同时还要获取到当前账户的所属用户信息
     * @return
     */
    List<Account> findAll();

    /**
     * 根据用户id查询账户信息
     * @param uid
     * @return
     */
    Account findAccountByUid(Integer uid);

}
