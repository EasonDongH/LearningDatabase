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
        String currentPageStr = request.getParameter("currentPage");
        String pageSizeStr = request.getParameter("pageSize");
        String rname = request.getParameter("rname");
        rname = new String(rname.getBytes("iso-8859-1"),"utf-8");

        int cid = 0, currentPage = 1, pageSize = 5;
        try {
            if(cidStr!=null && cidStr.length() > 0 && cidStr != "null") {
                cid = Integer.parseInt(cidStr);
            }
            if(currentPageStr!=null && currentPageStr.length() > 0) {
                currentPage = Integer.parseInt(currentPageStr);
            }
            if(pageSizeStr!=null && pageSizeStr.length() > 0) {
                pageSize = Integer.parseInt(pageSizeStr);
            }
        } catch (Exception e){
            e.printStackTrace();
        }

        int totalCount = this.routeService.getTotalRouteSizeByCid(cid,rname);
        int totalPage = totalCount / pageSize;
        if(totalCount % pageSize != 0) {
            totalPage += 1;
        }
        List<Route> pageData = this.routeService.getPageData(cid, (currentPage - 1) * pageSize, pageSize,rname);
        PageBean<Route> pageBean = new PageBean<>();
        pageBean.setTotalCount(totalCount);
        pageBean.setCurrentPage(currentPage);
        pageBean.setPageData(pageData);
        pageBean.setPageSize(pageSize);
        pageBean.setTotalPage(totalPage);

        super.writeValue(response,pageBean);
    }

    /**
     * 根据前台传入的rid获取线路详情
     * @param request
     * @param response
     * @throws ServletException
     * @throws IOException
     */
    public void getRouteDetailById(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String ridStr = request.getParameter("rid");
        int rid = 0;
        if(ridStr != null && ridStr.matches("^\\d+$")) {
            rid = Integer.parseInt(ridStr);
            Route routeDetail = this.routeService.getRouteDetailById(rid);
            super.writeValue(response,routeDetail);
        }
    }
}
