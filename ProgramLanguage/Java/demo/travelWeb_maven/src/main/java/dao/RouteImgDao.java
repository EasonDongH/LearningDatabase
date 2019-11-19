package dao;

import domain.RouteImg;

import java.util.List;

public interface RouteImgDao {
    /**
     * 根据rid获取RouteImg对象
     * @param rid
     * @return
     */
    List<RouteImg> getByRid(int rid);
}
