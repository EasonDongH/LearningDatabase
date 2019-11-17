package web.filter;

import org.omg.CORBA.Request;

import javax.servlet.*;
import javax.servlet.annotation.WebFilter;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

//@WebFilter("/*")
public class LoginFilter implements Filter {
    public void destroy() {
    }

    public void doFilter(ServletRequest req, ServletResponse resp, FilterChain chain) throws ServletException, IOException {
        HttpServletRequest request = (HttpServletRequest) req;
        String url = request.getRequestURL().toString();
        Object user = request.getSession().getAttribute("currUser");
        if(url != null && (url.endsWith("login.html") || url.endsWith("index.html") || url.endsWith("/") || user != null)) {
            chain.doFilter(req, resp);
        } else {
            ((HttpServletResponse)resp).sendRedirect(request.getContextPath() + "/login.html");
        }
    }

    public void init(FilterConfig config) throws ServletException {

    }

}
