package service;

import domain.Route;

import java.util.List;

public interface RouteService {
    /**
     * 获取当前cid对应的路线总数
     * @param cid
     * @return
     */
    int getTotalRouteSizeByCid(int cid);

    /**
     * 获取分页数据
     * @param cid
     * @param start
     * @param pageSize
     * @return
     */
    List<Route> getPageData(int cid, int start, int pageSize);
}
