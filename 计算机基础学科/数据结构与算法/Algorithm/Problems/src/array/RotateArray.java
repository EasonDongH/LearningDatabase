package array;

import org.junit.Assert;
import org.junit.Test;

/**
 * 旋转数组的最小数字：
 * 出自 剑指offer 题11
 * 把一个数组最开始的若干元素搬到数组末尾，称为数组的旋转。
 * 输入一个递增数组的旋转数组，输出该数组中的最小元素。
 * 例：输入{3,4,5,1,2}，输出1
 * @author EasonDongH
 * @date 2020/1/29 18:09
 */
public class RotateArray {

    public int min(int[] nums) throws Exception {
        if(nums == null || nums.length <= 0)
            throw new Exception("Invalid input");
        int index1 = 0, index2 = nums.length - 1;
        int indexMid = index1;
        while (nums[index1] >= nums[index2]) {
            if(index2 - index1 == 1) {// 当index1、index2相邻，index2就是结果
                indexMid = index2;
                break;
            }
            indexMid = (index1 + index2) / 2;
            // 特殊情况：被分割的界点都相等，采用顺序查找
            if(nums[index1] == nums[index2] && nums[index1] == nums[indexMid]) {
                return minInOrder(nums, index1, index2);
            }
            if (nums[indexMid] >= nums[index1]) {// 落在前一半递增区域
                index1 = indexMid;
            } else if (nums[indexMid] <= nums[index2]) {// 落在后一半递增区域
                index2 = indexMid;
            }
        }
        return nums[indexMid];
    }

    /**
     * 顺序查找[index1,index2]中的最小值
     * @param nums
     * @param index1
     * @param index2
     * @return
     */
    private int minInOrder(int[] nums, int index1, int index2){
        int result = nums[index1];
        for (int i = index1+1; i <= index2; i++) {
            if(result > nums[i]) {
                result = nums[i];
            }
        }
        return result;
    }

    /**
     * 常规输入
     * @throws Exception
     */
    @Test
    public void test1() throws Exception {
        int[] nums = {3,4,5,1,2};
        int ans = min(nums);
        Assert.assertEquals(1, ans);
    }

    /**
     * 特殊输入1
     * @throws Exception
     */
    @Test
    public void test2() throws Exception {
        int[] nums = {1,0,1,1,1};
        int ans = min(nums);
        Assert.assertEquals(0, ans);
    }

    /**
     * 特殊输入2
     * @throws Exception
     */
    @Test
    public void test3() throws Exception {
        int[] nums = {3,0,1,3,3,3,3};
        int ans = min(nums);
        Assert.assertEquals(0, ans);
    }

    /**
     * 输入递增序列
     * @throws Exception
     */
    @Test
    public void test4() throws Exception {
        int[] nums = {1,2,3,4,5};
        int ans = min(nums);
        Assert.assertEquals(1, ans);
    }
}
