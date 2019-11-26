package dao;

import domain.User;

import java.util.List;

public interface UserDao {

    /**
     * 列出所有用户
     * @return
     */
    List<User> listAllUsers();

    /**
     * 根据主键id获取user
     * @param id
     * @return
     */
    User getUserById(Integer id);

    /**
     * 更新用户信息
     * @param user
     */
    void update(User user);

    /**
     * 新增用户
     * @param user
     */
    void saveUser(User user);

    /**
     * 移除用户
     * @param id
     */
    void removeUser(Integer id);
}
