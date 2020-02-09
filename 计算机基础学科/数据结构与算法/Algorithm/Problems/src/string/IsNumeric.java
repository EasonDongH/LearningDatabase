package string;

import org.junit.Assert;
import org.junit.Test;

/**
 * 字符串是否表示数值
 * 来自 剑指offer 题20
 * 给定字符串，判断该字符串是否表示数值
 * 例："+100"、"5e2"、"-123"、"3.1416"、"-1E-16"、".123"、"123."返回true
 * "12e"、"e12"、"1a3.14"、"1.2.3"、"12e+5.4"返回false
 * @author EasonDongH
 * @date 2020/2/2 9:55
 */
public class IsNumeric {

    /**
     * 思路：
     * 即字符串匹配模式
     * A[.[B][e|E]C]或.B[e|EC]
     * A是整数部分、B是小数部分、C是指数部分
     * @param str
     * @return
     */
    public boolean isNumeric(String str) {
        if(str == null || str.length() <= 0) {
            return false;
        }
        int index = scanInteger(0, str);
        if(index < str.length() && str.charAt(index) == '.') {
            index = scanUnsignedInteger(index + 1, str);// 小数点后面不一定需要有数字
        }
        if(index < str.length() && (str.charAt(index) == 'e' || str.charAt(index) == 'E')) {
            int index1 = scanInteger(index + 1, str);
            if(index1 == index + 1) {// E后面必须有数字
                return false;
            }
            index = index1;
        }
        return index == str.length();
    }

    /**
     * 扫描整数，不允许有符号
     * @param index
     * @param str
     * @return
     */
    private int scanUnsignedInteger(int index, String str) {
        for( ;index<str.length() && Character.isDigit(str.charAt(index)); index++);
        return index;
    }

    /**
     * 扫描整数，允许有符号
     * @param index
     * @param str
     * @return
     */
    private int scanInteger(int index, String str) {
        if(index < str.length() && (str.charAt(index) == '+' || str.charAt(index) == '-')) {
            index += 1;
        }
        return scanUnsignedInteger(index, str);
    }

    /**
     * 边界输入：字符串为null
     */
    @Test
    public void test1(){
        String str = null;
        boolean actual = isNumeric(str);
        Assert.assertFalse(actual);
    }

    /**
     * 边界输入：字符串长度为0
     * "+100"、"5e2"、"-123"、"3.1416"、"-1E-16"、".123"、"123."
     */
    @Test
    public void test2(){
        String str = "";
        boolean actual = isNumeric(str);
        Assert.assertFalse(actual);
    }

    /**
     * 带+整数
     */
    @Test
    public void test3(){
        String str = "+100";
        boolean actual = isNumeric(str);
        Assert.assertTrue(actual);
    }

    /**
     * 带-整数
     */
    @Test
    public void test4(){
        String str = "-123";
        boolean actual = isNumeric(str);
        Assert.assertTrue(actual);
    }

    /**
     * 整数
     */
    @Test
    public void test5(){
        String str = "123";
        boolean actual = isNumeric(str);
        Assert.assertTrue(actual);
    }

    /**
     * 带+小数
     */
    @Test
    public void test6(){
        String str = "+3.1416";
        boolean actual = isNumeric(str);
        Assert.assertTrue(actual);
    }

    /**
     * 带-小数
     */
    @Test
    public void test7(){
        String str = "-3.1416";
        boolean actual = isNumeric(str);
        Assert.assertTrue(actual);
    }

    /**
     * 小数
     */
    @Test
    public void test8(){
        String str = "3.1416";
        boolean actual = isNumeric(str);
        Assert.assertTrue(actual);
    }

    /**
     * 无整数部分的小数
     */
    @Test
    public void test9(){
        String str = ".1416";
        boolean actual = isNumeric(str);
        Assert.assertTrue(actual);
    }

    /**
     * 无小数部分的整数
     */
    @Test
    public void test10(){
        String str = "3.";
        boolean actual = isNumeric(str);
        Assert.assertTrue(actual);
    }

    /**
     * 带+、E，数字、指数都是整数
     */
    @Test
    public void test11(){
        String str = "+3E10";
        boolean actual = isNumeric(str);
        Assert.assertTrue(actual);
    }

    /**
     * 带-、e，数字是小数、指数是无符号整数
     */
    @Test
    public void test12(){
        String str = "-3.1416e10";
        boolean actual = isNumeric(str);
        Assert.assertTrue(actual);
    }

    /**
     * 带+、e，数字是小数、指数是带-整数
     */
    @Test
    public void test13(){
        String str = "+3.1416e-10";
        boolean actual = isNumeric(str);
        Assert.assertTrue(actual);
    }

    /**
     * 带+、E，数字是整数、指数是带+整数
     */
    @Test
    public void test14(){
        String str = "+3.1416E+10";
        boolean actual = isNumeric(str);
        Assert.assertTrue(actual);
    }

    /**
     * e后无数字
     */
    @Test
    public void testFail1(){
        String str = "3.1416E";
        boolean actual = isNumeric(str);
        Assert.assertFalse(actual);
    }

    /**
     * 多个小数点
     */
    @Test
    public void testFail2(){
        String str = "3.14.16";
        boolean actual = isNumeric(str);
        Assert.assertFalse(actual);
    }

    /**
     * +-连在一起
     */
    @Test
    public void testFail3(){
        String str = "+-456";
        boolean actual = isNumeric(str);
        Assert.assertFalse(actual);
    }

    /**
     * 有其它字符
     */
    @Test
    public void testFail4(){
        String str = "12a456";
        boolean actual = isNumeric(str);
        Assert.assertFalse(actual);
    }

    /**
     * e后面是小数
     */
    @Test
    public void testFail5(){
        String str = "123e1.36";
        boolean actual = isNumeric(str);
        Assert.assertFalse(actual);
    }
}
