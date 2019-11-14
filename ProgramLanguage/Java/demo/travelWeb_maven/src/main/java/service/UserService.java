package service;

import domain.User;

public interface UserService {
    /**
     * 根据用户名查找用户
     * @param userName
     * @return
     */
    User findUserByUserName(String userName);
    /**
     * 保存新用户
     * @param user
     * @return
     */
    boolean saveUser(User user);
}
