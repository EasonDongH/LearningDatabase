package web.servlet;

import domain.PageBean;
import domain.Route;
import service.RouteService;
import service.impl.RouteServiceImpl;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.List;

@WebServlet("/route/*")
public class RouteServlet extends BaseServlet {
    private RouteService routeService = new RouteServiceImpl();

    public void pageQuery(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String cidStr = request.getParameter("cid");
        String curentPageStr = request.getParameter("curentPage");
        String pageSizeStr = request.getParameter("pageSize");

        int cid = 0, currentPage = 1, pageSize = 5;
        try {
            if(cidStr!=null && cidStr.length() > 0) {
                cid = Integer.parseInt(cidStr);
            }
            if(curentPageStr!=null && curentPageStr.length() > 0) {
                currentPage = Integer.parseInt(curentPageStr);
            }
            if(pageSizeStr!=null && pageSizeStr.length() > 0) {
                pageSize = Integer.parseInt(pageSizeStr);
            }
        } catch (Exception e){
            e.printStackTrace();
        }

        int totalCount = this.routeService.getTotalRouteSizeByCid(cid);
        int totalPage = totalCount / pageSize;
        if(totalCount % pageSize != 0) {
            totalPage += 1;
        }
        List<Route> pageData = this.routeService.getPageData(cid, (currentPage - 1) * pageSize, pageSize);
        PageBean<Route> pageBean = new PageBean<>();
        pageBean.setTotalCount(totalCount);
        pageBean.setCurrentPage(currentPage);
        pageBean.setPageData(pageData);
        pageBean.setPageSize(pageSize);
        pageBean.setTotalPage(totalPage);

        super.writeValue(response,pageBean);
    }
}
