package dao;

import domain.Route;

import java.util.List;

public interface RouteDao {

    /**
     * 获取当前cid对应的路线总数
     * @param cid
     * @return
     */
    int getTotalRouteSizeByCid(int cid, String rname);

    /**
     * 获取分页数据
     * @param start
     * @param pageSize
     * @return
     */
    List<Route> getPageData(int cid, int start, int pageSize, String rname);
}
