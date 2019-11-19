package service.impl;

import dao.RouteDao;
import dao.RouteImgDao;
import dao.SellerDao;
import dao.impl.RouteDaoImpl;
import dao.impl.RouteImgDaoImpl;
import dao.impl.SellerDaoImpl;
import domain.Route;
import domain.Seller;
import service.RouteService;

import java.util.List;

public class RouteServiceImpl implements RouteService {
    private RouteDao routeDao = new RouteDaoImpl();
    private RouteImgDao routeImgDao = new RouteImgDaoImpl();
    private SellerDao sellerDao = new SellerDaoImpl();

    @Override
    public int getTotalRouteSizeByCid(int cid,String rname) {
        return this.routeDao.getTotalRouteSizeByCid(cid,rname);
    }

    @Override
    public List<Route> getPageData(int cid, int start, int pageSize,String rname) {
        start = Math.max(0, start);
        return this.routeDao.getPageData(cid, start, pageSize,rname);
    }

    @Override
    public Route getRouteDetailById(int rid) {
        Route route = this.routeDao.getRouteDetailById(rid);
        if(route != null) {
            route.setRouteImgList(this.routeImgDao.getByRid(rid));
            route.setSeller(this.sellerDao.getById(route.getSid()));
        }
        return route;
    }
}
