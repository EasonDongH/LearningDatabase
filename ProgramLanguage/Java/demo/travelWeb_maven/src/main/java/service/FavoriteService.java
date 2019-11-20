package service;

import domain.Favorite;

public interface FavoriteService {

    /**
     * 根据rid、uid查询收藏信息
     * @param rid
     * @param uid
     * @return
     */
    boolean getFavoriteByRidAndUid(String rid, int uid);

    /**
     * 获取该rid收藏次数
     * @param rid
     * @return
     */
    int countFavorite(int rid);

    /**
     * 新增路线收藏
     * @param rid
     * @param uid
     * @return
     */
    boolean saveFavorite(String rid, int uid);

    /**
     *  取消收藏路线
     * @param rid
     * @param uid
     * @return
     */
    boolean removeFavorite(String rid, int uid);
}
