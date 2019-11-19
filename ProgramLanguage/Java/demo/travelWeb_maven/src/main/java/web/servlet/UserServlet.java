package web.servlet;

import com.fasterxml.jackson.databind.ObjectMapper;
import domain.ResultInfo;
import domain.User;
import org.apache.commons.beanutils.BeanUtils;
import service.UserService;
import service.impl.UserServiceImpl;

import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.IOException;
import java.util.Map;

@WebServlet("/user/*")
public class UserServlet extends BaseServlet {
    private UserService userService = new UserServiceImpl();

    public void login(HttpServletRequest request, HttpServletResponse response) throws IOException {
        request.setCharacterEncoding("utf-8");
        response.setContentType("application/json;charset=utf-8");

        ResultInfo resultInfo = new ResultInfo();
        try {
            String checkCode = request.getParameter("check");
            HttpSession session = request.getSession();
            Object checkcode_server = session.getAttribute("CHECKCODE_SERVER");
            if (checkcode_server == null  || !checkcode_server.toString().equalsIgnoreCase(checkCode)) {
                session.removeAttribute("CHECKCODE_SERVER");
                resultInfo.setFlag(false);
                resultInfo.setErrorMsg("验证码错误");
            } else {
                Map<String, String[]> parameterMap = request.getParameterMap();
                User loginUser = new User();
                BeanUtils.populate(loginUser, parameterMap);
                loginUser = userService.login(loginUser);
                if (loginUser == null) {
                    resultInfo.setFlag(false);
                    resultInfo.setErrorMsg("用户名或密码错误！");
                } else {
                    if ("N".equalsIgnoreCase(loginUser.getStatus())) {
                        resultInfo.setFlag(false);
                        resultInfo.setErrorMsg("该用户尚未激活，不能登录！");
                    } else {
                        resultInfo.setFlag(true);
                        request.getSession().setAttribute("currUser", loginUser);
                    }
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            ObjectMapper mapper = new ObjectMapper();
            mapper.writeValue(response.getWriter(), resultInfo);
        }
    }

    public void exit(HttpServletRequest request, HttpServletResponse response) throws IOException{
        request.setCharacterEncoding("utf-8");
        response.setContentType("text/html;charset=utf-8");

        request.getSession().removeAttribute("currUser");
        response.sendRedirect(request.getContextPath() + "/login.html");
    }

    public void registerUser(HttpServletRequest request, HttpServletResponse response) throws IOException{
        request.setCharacterEncoding("utf-8");
        response.setContentType("application/json;charset=utf-8");

        ResultInfo resultInfo = new ResultInfo();
        try {
            String checkCode = request.getParameter("check");
            HttpSession session = request.getSession();
            Object checkcode_server = session.getAttribute("CHECKCODE_SERVER");
            if (checkcode_server == null || !checkcode_server.toString().equalsIgnoreCase(checkCode)) {
                session.removeAttribute("CHECKCODE_SERVER");
                resultInfo.setFlag(false);
                resultInfo.setErrorMsg("验证码错误");
            } else {
                Map<String, String[]> parameterMap = request.getParameterMap();
                User user = new User();
                BeanUtils.populate(user, parameterMap);
                boolean save_res = userService.registUser(user);
                resultInfo.setFlag(save_res);
                if (save_res == false) {
                    resultInfo.setErrorMsg("注册失败，用户名已存在！"); // 这里忽略了数据库导致的保存失败情况
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            ObjectMapper mapper = new ObjectMapper();
            mapper.writeValue(response.getWriter(), resultInfo);
        }
    }

    public void active(HttpServletRequest request, HttpServletResponse response) throws IOException{
        request.setCharacterEncoding("utf-8");
        response.setContentType("text/html;charset=utf-8");

        String activeCode = request.getParameter("activeCode");
        User user = userService.findUserByActiveCode(activeCode);
        if(user == null || userService.activeUser(activeCode) == false) {
            response.getWriter().write("激活失败，请联系管理员！");
        } else {
            response.getWriter().write("激活成功，点击<a href='http://localhost/travel/login.html'>登录</a>！");
        }
    }

    public void getLoginUser(HttpServletRequest request, HttpServletResponse response) throws IOException{
        request.setCharacterEncoding("utf-8");
        response.setContentType("application/json;charset=utf-8");
        User userInfo = null;
        Object currUser = request.getSession().getAttribute("currUser");
        if(currUser != null && currUser instanceof User) {
            User user = (User) currUser;
            userInfo = new User();
            userInfo.setName(user.getName());

        }
        super.writeValue(response, userInfo);
    }
}
