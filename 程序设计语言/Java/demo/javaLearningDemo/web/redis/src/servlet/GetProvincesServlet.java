package servlet;

import com.fasterxml.jackson.databind.ObjectMapper;
import domain.Province;
import service.ProvinceService;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.List;

@WebServlet("/getProvincesServlet")
public class GetProvincesServlet extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        request.setCharacterEncoding("utf-8");
        response.setContentType("application/json;charset=utf-8");

        ProvinceService service = new ProvinceService();
//        List<Province> list = service.getAllProvinces();
//
//        ObjectMapper mapper = new ObjectMapper();
//        String s = mapper.writeValueAsString(list);
//        System.out.println(s);

        response.getWriter().write(service.getAllProvincesByRedis());
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        this.doPost(request, response);
    }
}
