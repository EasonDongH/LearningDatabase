package userLoginDemo;

import org.springframework.beans.BeanUtils;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.lang.reflect.InvocationTargetException;

@WebServlet("/login")
public class loginServlet extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        request.setCharacterEncoding("utf-8");
//        String name = request.getParameter("name");
//        String pwd = request.getParameter("password");
        User user = new User();
//        user.setName(name);
//        user.setPassword(pwd);

        try {
            org.apache.commons.beanutils.BeanUtils.populate(user, request.getParameterMap());
        } catch (IllegalAccessException e) {
            e.printStackTrace();
        } catch (InvocationTargetException e) {
            e.printStackTrace();
        }

        UserDao dao = new UserDao();
        user = dao.login(user);
        if(user == null){
            request.getRequestDispatcher("/faillogin").forward(request,response);
        } else {
            request.setAttribute("user", user);
            request.getRequestDispatcher("/successlogin").forward(request,response);
        }
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        this.doPost(request,response);
    }
}
