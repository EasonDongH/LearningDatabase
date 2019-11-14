package servlet;

import domain.PageBean;
import domain.User;
import service.UserService;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.*;

@WebServlet("/FindUserByPageServlet")
public class FindUserByPageServlet extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        request.setCharacterEncoding("utf-8");
        response.setContentType("text/html;charset=utf-8");

        String currentPage = request.getParameter("currentPage");
        String rows = request.getParameter("rows");

        System.out.println(currentPage + " " + rows);

        Map<String, String> queryParams = new HashMap<>();
        String name = request.getParameter("name");
        queryParams.put("name", name);
        request.setAttribute("condition_name", name);

        String address = request.getParameter("address");
        queryParams.put("address", address);
        request.setAttribute("condition_address", address);

        String email = request.getParameter("email");
        queryParams.put("email", email);
        request.setAttribute("condition_email", email);

        UserService service = new UserService();
        PageBean<User> pageBean = service.findUserByPage(currentPage, rows, queryParams);

        request.setAttribute("pageBean", pageBean);
        request.getRequestDispatcher("/list.jsp").forward(request,response);
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        this.doPost(request, response);
    }
}
