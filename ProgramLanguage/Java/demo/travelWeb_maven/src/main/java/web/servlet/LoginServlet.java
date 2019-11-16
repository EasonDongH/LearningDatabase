package web.servlet;

import com.fasterxml.jackson.databind.ObjectMapper;
import domain.ResultInfo;
import domain.User;
import org.apache.commons.beanutils.BeanUtils;
import service.UserService;
import service.impl.UserServiceImpl;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.IOException;
import java.lang.reflect.InvocationTargetException;
import java.util.Map;

@WebServlet("/loginServlet")
public class LoginServlet extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
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
                UserService userService = new UserServiceImpl();
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

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        this.doPost(request, response);
    }
}
