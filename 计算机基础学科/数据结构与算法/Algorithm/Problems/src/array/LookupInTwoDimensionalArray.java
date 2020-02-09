package array;

import org.junit.Assert;
import org.junit.Test;

/**
 * 二维数组中的查找
 * 出自 剑指offer 题4
 * 在一个二维数组中，每行都是从左到右递增，每列都是从上到下递增。
 * 先给一个数字，判断该数字是否在数组中
 * 例：
 * 1  2  8  9
 * 2  4  9  12
 * 4  7  10 13
 * 6  8  11 15
 * 查找数字7，返回true；查找数字5，返回false
 * @author EasonDongH
 * @date 2020/1/31 19:09
 */
public class LookupInTwoDimensionalArray {

    /**
     * 思路：
     * 从右上角或左下角出发，原因是如果当前值比目标值大或小时，可以剔除当前列或行
     * 比如从右上角出发，当前值比目标值大时，剔除当前列；当前值比目标值小时，剔除当前行
     *
     * 复杂度：
     * T(n) = O(row+col)
     * @param array
     * @param target
     * @return
     */
    public boolean lookup(int[][] array, int target) {
        if(array == null || array.length <= 0 || array[0].length <= 0) {
            return false;
        }
        int row = array.length, col = array[0].length;
        for(int r=0, c=col-1; r<row && c>=0; ) {// 初始定位在右上角
            if(array[r][c] == target) {
                return true;
            }
            if(array[r][c] > target) {// 此时只能向左移动
                c -= 1;
            } else if(array[r][c] < target) {// 此时只能向下移动
                r += 1;
            }
        }
        return false;
    }

    /**
     * 案例输入 数字存在
     */
    @Test
    public void test1(){
        int[][] array = {{1,2,8,9},{2,4,9,12},{4,7,10,13},{6,8,11,15}};
        boolean isExist = lookup(array, 7);
        Assert.assertTrue(isExist);
    }

    /**
     * 案例输入 数字不存在
     */
    @Test
    public void test2(){
        int[][] array = {{1,2,8,9},{2,4,9,12},{4,7,10,13},{6,8,11,15}};
        boolean isExist = lookup(array, 5);
        Assert.assertFalse(isExist);
    }

    /**
     * 案例输入 查找最小值
     */
    @Test
    public void test3(){
        int[][] array = {{1,2,8,9},{2,4,9,12},{4,7,10,13},{6,8,11,15}};
        boolean isExist = lookup(array, 1);
        Assert.assertTrue(isExist);
    }

    /**
     * 案例输入 查找最大值
     */
    @Test
    public void test4(){
        int[][] array = {{1,2,8,9},{2,4,9,12},{4,7,10,13},{6,8,11,15}};
        boolean isExist = lookup(array, 15);
        Assert.assertTrue(isExist);
    }

    /**
     * 案例输入 查找中间值
     */
    @Test
    public void test5(){
        int[][] array = {{1,2,8,9},{2,4,9,12},{4,7,10,13},{6,8,11,15}};
        boolean isExist = lookup(array, 15);
        Assert.assertTrue(isExist);
    }
}
