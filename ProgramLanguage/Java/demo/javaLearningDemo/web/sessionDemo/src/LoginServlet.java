import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.IOException;
import java.util.Map;

@WebServlet("/LoginServlet")
public class LoginServlet extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        request.setCharacterEncoding("utf-8");
        response.setContentType("text/html;charset=utf-8");

        Map<String, String[]> parameterMap = request.getParameterMap();
        if(parameterMap.containsKey("checkcode")) {
            String[] checkcodes = parameterMap.get("checkcode");
            HttpSession session = request.getSession();
            Object obj = session.getAttribute("checkCode");
            if(obj != null){
                session.removeAttribute("checkCode");// 保证验证码的一次性
                String ck = obj.toString();
                if(checkcodes != null && checkcodes.length > 0 && checkcodes[0].equalsIgnoreCase(ck))
                    response.getWriter().write("验证码正确");
                else{
                    request.setAttribute("login_error", "验证码错误");
                    request.getRequestDispatcher("/login.jsp").forward(request,response);
                }
            } else {
                request.setAttribute("login_error", "验证码错误");
                request.getRequestDispatcher("/login.jsp").forward(request,response);
            }
        }
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        this.doPost(request, response);
    }
}
