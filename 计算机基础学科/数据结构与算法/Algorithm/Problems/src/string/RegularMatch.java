package string;

import org.junit.Assert;
import org.junit.Test;

/**
 * 正则表达式匹配
 * 来自 剑指offer 题19
 * 实现一个函数来匹配'.'、'*'。'.'表示能匹配任意字符串，'*'表示前面的字符能出现任意次（包括0次）。
 * 本题中，匹配指的是字符串中所有字符都匹配整个模式。
 * 例：字符串"aaa"能与模式"a.a"、"ab*ac*a"匹配，不能与"aa.a"、"ab*a"匹配
 * @author EasonDongH
 * @date 2020/2/1 11:48
 */
public class RegularMatch {

    /**
     * 模拟有限状态机：
     *  下一字符不是'*'时
     *      模式串与匹配串当前字符相匹配时，进入下一状态；否则返回false
     *  下一字符是'*'时
     *      模式串与匹配串当前字符相匹配时
     *          匹配串+1，模式串+2：当前字符与下一字符(*)
     *          匹配串+1，模式串不变：相当于对当前字符进行多次匹配
     *          匹配串，模式串+2：忽略模式串的当前字符与下一字符(*)
     *      模式串与匹配串当前字符不匹配时
     *          匹配串，模式串+2：忽略模式串的当前字符与下一字符(*)
     * @param str
     * @param pattern
     * @return
     */
    boolean match(String str, String pattern){
        if(str == null || pattern == null) {
            return false;
        }
        return match(str, 0, pattern, 0);
    }

    boolean match(String str, int sIndex, String pattern, int pIndex){
        if(pIndex == pattern.length()) {// 当模式串已结束，则匹配串必须也结束才算匹配
            return sIndex == str.length();
        } else if(sIndex == str.length()) {// 如果模式串未结束而匹配串已结束，则说明不匹配
            return false;
        }
        // 下一字符是'*'时
        if((pIndex+1) < pattern.length() && pattern.charAt(pIndex+1) == '*') {
            // 当前字符与模式串相同时（包括模式串的'.'），进入下一状态
            if(pattern.charAt(pIndex) == str.charAt(sIndex) || (pattern.charAt(pIndex) == '.' && sIndex < str.length())) {
                return match(str, sIndex+1, pattern, pIndex+2)
                        || match(str, sIndex+1, pattern, pIndex)
                        || match(str, sIndex, pattern, pIndex+2);
            } else {// 否则模式串忽略当前字符与'*'
                return match(str, sIndex, pattern, pIndex+2);
            }
        }
        // 下一字符不是'*'时，当前匹配则模式串、匹配串都+1
        if(pattern.charAt(pIndex) == str.charAt(sIndex) || (pattern.charAt(pIndex) == '.' && sIndex < str.length())) {
            return match(str, sIndex+1, pattern, pIndex+1);
        }
        return false;
    }

    /**
     * 案例输入 '.'匹配
     */
    @Test
    public void test1(){
        String str = "aaa";
        String pattern = "a.a";
        boolean isMatch = match(str, pattern);
        Assert.assertTrue(isMatch);
    }

    /**
     * 案例输入 '*'匹配
     */
    @Test
    public void test2(){
        String str = "aaa";
        String pattern = "ab*ac*a";
        boolean isMatch = match(str, pattern);
        Assert.assertTrue(isMatch);
    }

    /**
     * 案例输入 '.'不匹配
     */
    @Test
    public void test3(){
        String str = "aaa";
        String pattern = "aa.a";
        boolean isMatch = match(str, pattern);
        Assert.assertFalse(isMatch);
    }

    /**
     * 案例输入 '*'不匹配
     */
    @Test
    public void test4(){
        String str = "aaa";
        String pattern = "ab*a";
        boolean isMatch = match(str, pattern);
        Assert.assertFalse(isMatch);
    }
}
