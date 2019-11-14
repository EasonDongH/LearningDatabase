package filter;

import javax.servlet.*;
import javax.servlet.annotation.WebFilter;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebFilter("/*")
public class LoginFilter implements Filter {
    public void destroy() {
    }

    public void doFilter(ServletRequest req, ServletResponse resp, FilterChain chain) throws ServletException, IOException {
        HttpServletRequest httpServletRequest = (HttpServletRequest) req;
        String requestURI = httpServletRequest.getRequestURI();
        // 排除登录请求资源
        if(requestURI.contains("/login.jsp") || requestURI.contains("/LoginServlet") || requestURI.contains("/CheckCodeServlet") ||
                requestURI.contains("/css/") || requestURI.contains("/fonts/") || requestURI.contains("/js/")){
            chain.doFilter(req, resp);
        } else {
            Object user = httpServletRequest.getSession().getAttribute("user");
            if(user != null) {
                chain.doFilter(req,resp);
            } else {
                httpServletRequest.getSession().setAttribute("login_msg", "请先登录");
                ((HttpServletResponse)resp).sendRedirect(((HttpServletRequest) req).getContextPath() + "/login.jsp");
            }

        }

    }

    public void init(FilterConfig config) throws ServletException {

    }

}
