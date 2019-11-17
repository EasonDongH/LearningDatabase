package service;

import domain.Category;

import java.util.List;

public interface CategoryService {

    /**
     * 获取所有分类信息，已排序（sql排序）
     * @return
     */
    List<Category> getAllCategories();
}
