package web.servlet;

import domain.User;
import service.FavoriteService;
import service.impl.FavoriteServiceImpl;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet("/favorite/*")
public class FavoriteServlet extends BaseServlet {

    private FavoriteService favoriteService = new FavoriteServiceImpl();

    /**
     * 获取登录用户是否已收藏该线路
     * @param request
     * @param response
     * @throws ServletException
     * @throws IOException
     */
    public void isFavorite(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String rid = request.getParameter("rid");
        User currUser = (User) request.getSession().getAttribute("currUser");
        int uid = 0;
        if (currUser != null) {
            uid = currUser.getUid();
        } else {
            return;
        }

        boolean isFavorite = this.favoriteService.getFavoriteByRidAndUid(rid, uid);
        super.writeValue(response, isFavorite);
    }

    /**
     * 添加收藏路线
     * @param request
     * @param response
     * @throws ServletException
     * @throws IOException
     */
    public void saveFavorite(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String rid = request.getParameter("rid");
        User currUser = (User) request.getSession().getAttribute("currUser");
        int uid = 0;
        if (currUser != null) {
            uid = currUser.getUid();
        } else {
            return;
        }

        this.favoriteService.saveFavorite(rid, uid);
    }

    /**
     * 取消收藏路线
     * @param request
     * @param response
     * @throws ServletException
     * @throws IOException
     */
    public void removeFavorite(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String rid = request.getParameter("rid");
        User currUser = (User) request.getSession().getAttribute("currUser");
        int uid = 0;
        if (currUser != null) {
            uid = currUser.getUid();
        } else {
            return;
        }
        this.favoriteService.removeFavorite(rid, uid);
    }
}
