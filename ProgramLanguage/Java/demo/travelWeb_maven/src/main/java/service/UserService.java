package service;

import domain.User;

public interface UserService {
    /**
     * 根据用户名查找用户
     *
     * @param userName
     * @return
     */
    User findUserByUserName(String userName);

    /**
     * 根据激活码（唯一）查找用户
     *
     * @param activeCode
     * @return
     */
    User findUserByActiveCode(String activeCode);

    /**
     * 激活用户（status='Y'）
     *
     * @param activeCode
     * @return
     */
    boolean activeUser(String activeCode);

    /**
     * 保存新用户
     *
     * @param user
     * @return
     */
    boolean registUser(User user);

    User login(User user);
}
