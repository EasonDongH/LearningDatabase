package dao;

import domain.Favorite;

public interface FavoriteDao {

    /**
     * 根据rid、uid查询收藏信息
     * @param rid
     * @param uid
     * @return
     */
    Favorite getFavoriteByRidAndUid(int rid,int uid);

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
    int saveFavorite(int rid, int uid);

}
