package stack;

import org.junit.Assert;
import org.junit.Test;

import java.util.Stack;

/**
 * 栈的压入、弹出序列
 * 出自 剑指offer 题31
 * 给出两个整数序列，第一个为栈的压入序列，第二个为栈的弹出序列，判断弹出序列是否可能？
 * 例：压入序列{1,2,3,4,5}，{4,5,3,2,1}是一个可能的出栈序列，{4,3,5,1,2}不可能是出栈序列
 * @author EasonDongH
 * @date 2020/2/7 10:10
 */
public class StackPopOrder {

    public boolean isPopOrder(int[] sPush, int[] sPop) {
        if(sPush == null || sPop == null || sPush.length != sPop.length) {
            return false;
        }
        int iPush = 0, iPop = 0;
        Stack<Integer> stack = new Stack<>();
        while (iPush < sPush.length && iPop < sPop.length) {
            if(stack.empty()) {
                stack.push(sPush[iPush++]);
            }
            while (iPush < sPush.length && stack.peek() != sPop[iPop]) {
                stack.push(sPush[iPush++]);
            }
            while (!stack.empty() && iPop < sPop.length && stack.peek() == sPop[iPop]) {
                stack.pop();
                iPop += 1;
            }
        }
        return stack.empty() && iPush == sPush.length && iPop == sPop.length;
    }

    @Test
    public void testSuccess1(){
        int[] sPush = {1,2,3,4,5};
        int[] sPop = {4,5,3,2,1};
        boolean result = isPopOrder(sPush,sPop);
        Assert.assertTrue(result);
    }

    @Test
    public void testFail1(){
        int[] sPush = {1,2,3,4,5};
        int[] sPop = {4,3,5,1,2};
        boolean result = isPopOrder(sPush,sPop);
        Assert.assertFalse(result);
    }
}
