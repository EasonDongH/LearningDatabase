package service;

import dao.UserDao;
import dao.impl.UserDaoImpl;
import domain.PageBean;
import domain.User;

import java.util.List;
import java.util.Map;

public class UserService {
    private UserDao userDao = new UserDaoImpl();

    public User login(User user) {
        return this.userDao.findUserByUsernameAndPassword(user.getName(), user.getPassword());
    }

    public List<User> findAll() {
        return this.userDao.findAll();
    }

    public boolean addUser(User user) {
        return this.userDao.add(user);
    }

    public boolean deleteUserById(String id) {
        return this.userDao.delete(Integer.parseInt(id));
    }

    public User findUserById(String id) {
        return this.userDao.findById(Integer.parseInt(id));
    }

    public boolean updateUser(User user) {
        return this.userDao.update(user);
    }

    public boolean deleteUsers(String[] ids) {
        if (ids == null)
            return true;
        boolean flag = true;
        for (int i = 0; i < ids.length && flag; i++) {
            flag = deleteUserById(ids[i]);
        }
        return flag;
    }

    public PageBean<User> findUserByPage(String curPage, String rows, Map<String,String> condition) {
        if(curPage == null || "".equals(curPage))
            curPage = "1";
        if(rows == null || "".equals(rows))
            rows = "5";
        System.out.println(curPage + " " + rows);
        System.out.println(condition);

        PageBean<User> pageBean = new PageBean<>();
        int currentPage = Integer.parseInt(curPage);
        int rowCnt = Integer.parseInt(rows);
        int totalCount = this.userDao.findTotalCount(condition);
        int totalPage = totalCount / rowCnt;
        if(totalCount % rowCnt != 0)
            totalPage += 1;

        if(currentPage < 1)
            currentPage = 1;
        else if(currentPage > totalPage)
            currentPage = Math.max(1, totalPage);

        int start = (currentPage - 1) * rowCnt;
        List<User> list = this.userDao.findByPage(start, rowCnt, condition);

        pageBean.setCurrentPage(currentPage);
        pageBean.setPageRowCnt(rowCnt);
        pageBean.setTotalCount(totalCount);
        pageBean.setTotalPage(totalPage);
        pageBean.setList(list);

        return  pageBean;
    }
}
