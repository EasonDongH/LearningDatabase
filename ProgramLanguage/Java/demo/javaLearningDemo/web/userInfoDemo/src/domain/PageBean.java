package domain;

import java.util.ArrayList;
import java.util.List;

public class PageBean<T> {
    private int totalCount = 0;
    private int totalPage = 0;
    private int currentPage = 0;
    private int pageRowCnt = 0;
    private List<T> list = new ArrayList<>();

    public int getTotalCount() {
        return totalCount;
    }

    public void setTotalCount(int totalCount) {
        this.totalCount = totalCount;
    }

    public int getTotalPage() {
        return totalPage;
    }

    public void setTotalPage(int totalPage) {
        this.totalPage = totalPage;
    }

    public int getCurrentPage() {
        return currentPage;
    }

    public void setCurrentPage(int currentPage) {
        this.currentPage = currentPage;
    }

    public int getPageRowCnt() {
        return pageRowCnt;
    }

    public void setPageRowCnt(int pageRowCnt) {
        this.pageRowCnt = pageRowCnt;
    }

    public List<T> getList() {
        return list;
    }

    public void setList(List<T> userList) {
        this.list = userList;
    }

    @Override
    public String toString() {
        return "PageBean{" +
                "totalCount=" + totalCount +
                ", totalPage=" + totalPage +
                ", currentPage=" + currentPage +
                ", pageRowCnt=" + pageRowCnt +
                ", list=" + list +
                '}';
    }
}
