package dao;

import domain.User;
import java.util.List;
import java.util.Map;

/**
 * 用户操作的DAO
 */
public interface UserDao {

    List<User> findAll();

    User findUserByUsernameAndPassword(String username, String password);

    boolean add(User user);

    boolean delete(int id);

    User findById(int i);

    boolean update(User user);

    /**
     * 查询总记录数
     * @return
     * @param condition
     */
    int findTotalCount(Map<String, String> condition);

    /**
     * 分页查询每页记录
     * @param start
     * @param rows
     * @param condition
     * @return
     */
    List<User> findByPage(int start, int rows, Map<String, String> condition);
}
