package web.servlet;

import com.fasterxml.jackson.databind.ObjectMapper;
import domain.Category;
import redis.clients.jedis.Jedis;
import service.CategoryService;
import service.impl.CategoryServiceImpl;
import util.JedisUtil;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.List;
import java.util.Set;

@WebServlet("/category/*")
public class CategoryServlet extends BaseServlet {
    private CategoryService categoryService = new CategoryServiceImpl();

    public void getAllCategories(HttpServletRequest req, HttpServletResponse resp){
        try {
            List<Category> allCategories = this.categoryService.getAllCategories();
            super.writeValue(resp, allCategories);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
