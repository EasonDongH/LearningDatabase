package array;

import org.junit.Assert;
import org.junit.Test;

import java.util.concurrent.ConcurrentHashMap;

/**
 * 数组中的重复数字
 * 来自 剑指offer 题3-2
 * 有一个长度为n+1的数组，所有数字范围为[1,n]。
 * 所以数组中必然有一个数字是重复。
 * 要求在不修改输入数组的前提下找出这个重复的数字。
 * 例：{2,3,4,5,3,2,6,7}，输出：2或3
 * @author EasonDongH
 * @date 2020/1/30 20:16
 */
public class RepeatNumber2 {

    /**
     * 思路：
     * 将[1,n]一分为二：[1,m]、[m+1,n]
     * 若前半部分位于[1,m]的个数大于m，则说明前一半有重复数字，否则重复数字就在后一半
     *
     * 分析：
     * countRange会被调用O(logn)，每次O(n)，因此总时间复杂度为：O(nlogn)
     * @param nums
     * @return -1表示输入异常
     * @throws Exception
     */
    public int getRepeat(int[] nums) throws Exception {
        if(nums == null || nums.length <= 0) {
            return -1;
        }
        int start = 1, end = nums.length - 1;
        while (start <= end) {
            int mid = ((end - start) >> 1) + start;
            int count = countRange(nums,start,mid);
            if (start == end) {
                if(count > 1) return start;// 聚焦到某一具体数字后，若该数字的确重复，则返回该数字，否则返回-1
                else break;
            }
            if(count > (mid - start + 1)) {
                end = mid;
            } else {
                start = mid + 1;
            }
        }
        return -1;
    }

    /**
     * 统计nums中值在[start,end]的数字个数
     * @param nums
     * @param start
     * @param end
     * @return
     */
    private int countRange(int[] nums, int start, int end){
        int count = 0;
        for(int n : nums) {
            if(n >= start && n <= end) {
                count += 1;
            }
        }
        return count;
    }

    /**
     * 案例输入
     * @throws Exception
     */
    @Test
    public void test1() throws Exception {
        int[] nums = {2,3,4,5,3,2,6,7};
        int ans = getRepeat(nums);
        Assert.assertTrue(ans == 2 || ans == 3);
    }

    /**
     * 仅一个重复数字
     * @throws Exception
     */
    @Test
    public void test2() throws Exception {
        int[] nums = {4,3,1,6,2,5,3};
        int ans = getRepeat(nums);
        Assert.assertEquals(3, ans);
    }

    /**
     * 无重复数字
     * @throws Exception
     */
    @Test
    public void test3() throws Exception {
        int[] nums = {4,3,1,7,2,5,6};
        int ans = getRepeat(nums);
        Assert.assertEquals(-1, ans);
    }
}
