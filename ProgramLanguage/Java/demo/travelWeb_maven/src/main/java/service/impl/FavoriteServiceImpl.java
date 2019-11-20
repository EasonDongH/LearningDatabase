package service.impl;

import dao.FavoriteDao;
import dao.impl.FavoriteDaoImpl;
import service.FavoriteService;

public class FavoriteServiceImpl implements FavoriteService {
    private FavoriteDao favoriteDao = new FavoriteDaoImpl();

    @Override
    public boolean getFavoriteByRidAndUid(String ridStr, int uid) {
        int rid = 0;
        if (ridStr != null && ridStr.matches("^\\d+$")) {
            rid = Integer.parseInt(ridStr);
        }
        return this.favoriteDao.getFavoriteByRidAndUid(rid, uid) != null;
    }

    @Override
    public int countFavorite(int rid) {
        return this.favoriteDao.countFavorite(rid);
    }

    @Override
    public boolean saveFavorite(String ridStr, int uid) {
        int rid = -1;
        if (ridStr != null && ridStr.matches("^\\d+$")) {
            rid = Integer.parseInt(ridStr);
        }
        return this.favoriteDao.saveFavorite(rid, uid) > 0;
    }

    @Override
    public boolean removeFavorite(String ridStr, int uid) {
        int rid = -1;
        if (ridStr != null && ridStr.matches("^\\d+$")) {
            rid = Integer.parseInt(ridStr);
        }
        return this.favoriteDao.removeFavorite(rid, uid) > 0;
    }
}
