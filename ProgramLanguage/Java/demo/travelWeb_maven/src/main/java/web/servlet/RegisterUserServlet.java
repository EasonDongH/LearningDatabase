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
import java.util.Map;

@WebServlet("/registerUserServlet")
public class RegisterUserServlet extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        request.setCharacterEncoding("utf-8");
        response.setContentType("application/json;charset=utf-8");

        ResultInfo resultInfo = new ResultInfo();
        try {
            String checkCode = request.getParameter("check");
            HttpSession session = request.getSession();
            String checkcode_server = session.getAttribute("CHECKCODE_SERVER").toString();
            if (checkcode_server == null || !checkcode_server.equalsIgnoreCase(checkCode)) {
                session.removeAttribute("CHECKCODE_SERVER");
                resultInfo.setFlag(false);
                resultInfo.setErrorMsg("验证码错误");
            } else {
                Map<String, String[]> parameterMap = request.getParameterMap();
                User user = new User();
                BeanUtils.populate(user, parameterMap);
                UserService userService = new UserServiceImpl();
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

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        this.doPost(request, response);
    }
}
