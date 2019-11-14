package service.impl;

import dao.UserDao;
import dao.impl.UserDaoImpl;
import domain.User;
import service.UserService;
import util.MailUtils;
import util.UuidUtil;

public class UserServiceImpl implements UserService {

    private UserDao userDao = new UserDaoImpl();
    @Override
    public User findUserByUserName(String userName) {
        return this.userDao.findUserByUserName(userName);
    }

    /**
     * 注册用户，进行用户名不能重复验证
     * 验证通过后，发送激活邮件
     * @param user
     * @return
     */
    @Override
    public boolean registUser(User user) {
        user.setCode(UuidUtil.getUuid());
        user.setStatus("N");
        boolean result = this.userDao.findUserByUserName(user.getUsername())==null && this.userDao.saveUser(user);
        if(result) {
            String msg = "您正在注册【旅游网】，非本人操作请忽略！点击<a href='http://localhost/travel/activeServlet?activeCode="+user.getCode()+"'>激活</a>";
            MailUtils.sendMail(user.getEmail(), msg, "旅游网注册信息");
        }
        return result;
    }
}
