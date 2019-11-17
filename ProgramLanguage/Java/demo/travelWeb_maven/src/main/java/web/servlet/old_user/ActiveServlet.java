//package web.servlet;
//
//import domain.User;
//import service.UserService;
//import service.impl.UserServiceImpl;
//
//import javax.servlet.ServletException;
//import javax.servlet.annotation.WebServlet;
//import javax.servlet.http.HttpServlet;
//import javax.servlet.http.HttpServletRequest;
//import javax.servlet.http.HttpServletResponse;
//import java.io.IOException;
//
//@WebServlet("/activeServlet")
//public class ActiveServlet extends HttpServlet {
//    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
//        request.setCharacterEncoding("utf-8");
//        response.setContentType("text/html;charset=utf-8");
//
//        String activeCode = request.getParameter("activeCode");
//        UserService userService = new UserServiceImpl();
//        User user = userService.findUserByActiveCode(activeCode);
//        if(user == null || userService.activeUser(activeCode) == false) {
//            response.getWriter().write("激活失败，请联系管理员！");
//        } else {
//            response.getWriter().write("激活成功，点击<a href='http://localhost/travel/login.html'>登录</a>！");
//        }
//    }
//
//    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
//        this.doPost(request, response);
//    }
//}
