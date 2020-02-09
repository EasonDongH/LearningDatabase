package array;

import org.junit.Assert;
import org.junit.Test;

/**
 * 数组中的重复数字
 * 来自 剑指offer 题3
 * 有一个长度为n的数组，所有数字范围为[0,n-1]。
 * 数组中某些数字是重复的，但不知道哪些数字是重复的、重复了几次。
 * 请找出任意一个重复的数字。
 * 例：{2,3,1,0,2,5,3}，输出：2或3
 * @author EasonDongH
 * @date 2020/1/30 19:53
 */
public class RepeatNumber {

    /**
     * 需要修改输入
     * @param nums
     * @return
     * @throws Exception
     */
    public int getRepeat(int[] nums) throws Exception {
        if(nums == null || nums.length <= 0) {
            throw new Exception("Invalid Input");
        }
        for (int i = 0; i < nums.length; i++) {
            while (nums[i] != i) {
              int tmp = nums[i];
              if(nums[tmp] == tmp) {
                  return tmp;
              }
              nums[i] = nums[tmp];
              nums[tmp] = tmp;
            }
        }
        throw new Exception("Invalid Input: Without repeat number");
    }

    /**
     * 案例输入
     * @throws Exception
     */
    @Test
    public void test1() throws Exception {
        int[] nums = {2,3,1,0,2,5,3};
        int ans = getRepeat(nums);
        Assert.assertTrue(ans == 2 || ans == 3);
    }

    /**
     * 仅一个重复数字
     * @throws Exception
     */
    @Test
    public void test2() throws Exception {
        int[] nums = {4,3,1,0,2,5,3};
        int ans = getRepeat(nums);
        Assert.assertTrue(ans == 3);
    }

    /**
     * 无重复数字
     * @throws Exception
     */
    @Test
    public void test3() throws Exception {
        int[] nums = {4,3,1,0,2,5,6};
        int ans = getRepeat(nums);
    }
}
