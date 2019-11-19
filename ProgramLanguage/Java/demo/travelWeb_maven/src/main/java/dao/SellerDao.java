package dao;

import domain.Seller;

public interface SellerDao {
    /**
     * 根据sid获取Seller
     * @param sid
     * @return
     */
    Seller getById(int sid);
}
