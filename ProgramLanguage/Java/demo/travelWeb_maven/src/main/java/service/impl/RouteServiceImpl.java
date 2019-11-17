package service.impl;

import dao.RouteDao;
import dao.impl.RouteDaoImpl;
import domain.Route;
import service.RouteService;

import java.util.List;

public class RouteServiceImpl implements RouteService {
    private RouteDao routeDao = new RouteDaoImpl();

    @Override
    public int getTotalRouteSizeByCid(int cid) {
        return this.routeDao.getTotalRouteSizeByCid(cid);
    }

    @Override
    public List<Route> getPageData(int cid, int start, int pageSize) {
        start = Math.max(0, start);
        return this.routeDao.getPageData(cid, start, pageSize);
    }
}
