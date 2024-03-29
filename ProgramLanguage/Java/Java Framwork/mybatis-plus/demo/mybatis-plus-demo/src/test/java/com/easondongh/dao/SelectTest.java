package com.easondongh.dao;

import com.baomidou.mybatisplus.core.conditions.Wrapper;
import com.baomidou.mybatisplus.core.conditions.query.LambdaQueryWrapper;
import com.baomidou.mybatisplus.core.conditions.query.QueryWrapper;
import com.baomidou.mybatisplus.core.metadata.IPage;
import com.baomidou.mybatisplus.core.toolkit.Wrappers;
import com.baomidou.mybatisplus.extension.plugins.pagination.Page;
import com.baomidou.mybatisplus.extension.service.additional.query.impl.LambdaQueryChainWrapper;
import com.easondongh.dao.UserMapper;
import com.easondongh.entity.User;
import com.mysql.jdbc.StringUtils;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import java.util.*;

/**
 * @author EasonDongH
 * @date 2020/1/21 12:17
 */
@RunWith(SpringRunner.class)
@SpringBootTest
public class SelectTest {

    @Autowired
    private UserMapper userMapper;

    @Test
    public void testSelect() {
        List<User> userList = this.userMapper.selectList(null);
        userList.forEach(System.out::println);
    }

    @Test
    public void testSelectById() {
        User user = this.userMapper.selectById(1087982257332887553L);
        System.out.println(user);
    }

    @Test
    public void testSelectByBatchIds() {
        List<Long> ids = Arrays.asList(1088248166370832385L, 1088250446457389058L, 1094590409767661570L);
        List<User> userList = this.userMapper.selectBatchIds(ids);
        userList.forEach(System.out::println);
    }

    /**
     * 根据数据库列名进行查询
     */
    @Test
    public void testSelectByMap() {
        HashMap<String, Object> map = new HashMap<>();
        map.put("manager_id", 1088248166370832385L);
        map.put("age", 28);
        List<User> userList = this.userMapper.selectByMap(map);
        userList.forEach(System.out::println);
    }

    /**
     * 名字中包含雨并且年龄小于40
     * name like '%雨%' and age<40
     */
    @Test
    public void testSelectByWrapper1() {
        QueryWrapper<User> queryWrapper = new QueryWrapper<>();
        queryWrapper.like("name", "雨").lt("age", 40);
        List<User> userList = this.userMapper.selectList(queryWrapper);
        userList.forEach(System.out::println);
    }

    /**
     * 名字中包含雨年并且龄大于等于20且小于等于40并且email不为空
     * name like '%雨%' and age between 20 and 40 and email is not null
     */
    @Test
    public void testSelectByWrapper2() {
        QueryWrapper<User> queryWrapper = new QueryWrapper<>();
        queryWrapper.like("name", "雨").between("age", 20, 40).isNotNull("email");
        List<User> userList = this.userMapper.selectList(queryWrapper);
        userList.forEach(System.out::println);
    }

    /**
     * 名字为王姓或者年龄大于等于25，按照年龄降序排列，年龄相同按照id升序排列
     * name like '王%' or age>=25 order by age desc,id asc
     */
    @Test
    public void testSelectByWrapper3() {
        QueryWrapper<User> queryWrapper = new QueryWrapper<>();
        queryWrapper.likeRight("name", "雨").or().gt("age", 25).orderByDesc("age").orderByAsc("id");
        List<User> userList = this.userMapper.selectList(queryWrapper);
        userList.forEach(System.out::println);
    }

    /**
     * 创建日期为2019年2月14日并且直属上级为名字为王姓
     * date_format(create_time,'%Y-%m-%d')='2019-02-14' and manager_id in (select id from user where name like '王%')
     */
    @Test
    public void testSelectByWrapper4() {
        QueryWrapper<User> queryWrapper = new QueryWrapper<>();
        queryWrapper.apply("date_format(create_time,'%Y-%m-%d')={0} ", "2019-02-14").
                inSql("manager_id", "select id from user where name like '王%'");
        List<User> userList = this.userMapper.selectList(queryWrapper);
        userList.forEach(System.out::println);
    }

    /**
     * 名字为王姓并且（年龄小于40或邮箱不为空）
     * name like '王%' and (age<40 or email is not null)
     */
    @Test
    public void testSelectByWrapper5() {
        QueryWrapper<User> queryWrapper = new QueryWrapper<>();
        queryWrapper.likeRight("name", "王").and(qw -> qw.lt("age", 40).or().isNotNull("email"));
        List<User> userList = this.userMapper.selectList(queryWrapper);
        userList.forEach(System.out::println);
    }

    /**
     * 名字为王姓或者（年龄小于40并且年龄大于20并且邮箱不为空）
     * name like '王%' or (age<40 and age>20 and email is not null)
     */
    @Test
    public void testSelectByWrapper6() {
        QueryWrapper<User> queryWrapper = new QueryWrapper<>();
        queryWrapper.likeRight("name", "王").or(qw -> qw.lt("age", 40).gt("age", 20).isNotNull("email"));
        List<User> userList = this.userMapper.selectList(queryWrapper);
        userList.forEach(System.out::println);
    }

    /**
     * （年龄小于40或邮箱不为空）并且名字为王姓
     * (age<40 or email is not null) and name like '王%'
     */
    @Test
    public void testSelectByWrapper7() {
        QueryWrapper<User> queryWrapper = new QueryWrapper<>();
        queryWrapper.nested(qw -> qw.lt("age", 40).or().isNotNull("email")).likeRight("name", "王%");
        List<User> userList = this.userMapper.selectList(queryWrapper);
        userList.forEach(System.out::println);
    }

    /**
     * 年龄为30、31、34、35
     * age in (30、31、34、35)
     */
    @Test
    public void testSelectByWrapper8() {
        QueryWrapper<User> queryWrapper = new QueryWrapper<>();
        queryWrapper.in("age", Arrays.asList(30, 31, 34, 35));
        List<User> userList = this.userMapper.selectList(queryWrapper);
        userList.forEach(System.out::println);
    }

    /**
     * 只返回满足条件的其中一条语句即可
     * limit 1
     */
    @Test
    public void testSelectByWrapper9() {
        QueryWrapper<User> queryWrapper = new QueryWrapper<>();
        queryWrapper.in("age", Arrays.asList(30, 31, 34, 35)).last("limit 1");// 有SQL注入风险
        List<User> userList = this.userMapper.selectList(queryWrapper);
        userList.forEach(System.out::println);
    }

    /**
     * 只查询少量字段
     */
    @Test
    public void testSelectByWrapper10() {
        QueryWrapper<User> queryWrapper = new QueryWrapper<>();
        queryWrapper.select("id", "name", "age").in("age", Arrays.asList(25, 28, 34, 35));
        List<User> userList = this.userMapper.selectList(queryWrapper);
        userList.forEach(System.out::println);
    }

    /**
     * 排除少量字段
     */
    @Test
    public void testSelectByWrapper11() {
        QueryWrapper<User> queryWrapper = new QueryWrapper<>();
        queryWrapper.select(User.class, info -> !info.getColumn().equals("manager_id") && !info.getColumn().equals("email"))
                .in("age", Arrays.asList(25, 28, 34, 35));
        List<User> userList = this.userMapper.selectList(queryWrapper);
        userList.forEach(System.out::println);
    }

    @Test
    public void testSelectByCondition() {
        QueryWrapper<User> queryWrapper = new QueryWrapper<>();
        String name = "王", email = "";
        queryWrapper.like(!StringUtils.isNullOrEmpty(name), "name", name)
                .like(!StringUtils.isNullOrEmpty(email), "email", email);
        List<User> userList = this.userMapper.selectList(queryWrapper);
        userList.forEach(System.out::println);
    }

    @Test
    public void testSelectByEntity() {
        User user = new User();
        user.setName("王");
        user.setAge(23);
        QueryWrapper<User> queryWrapper = new QueryWrapper<>(user);
        List<User> userList = this.userMapper.selectList(queryWrapper);
        userList.forEach(System.out::println);
    }

    @Test
    public void testSelectByAllEq(){
        QueryWrapper<User> queryWrapper = new QueryWrapper<>();
        Map<String,Object> params = new HashMap<>();
        params.put("name", "王");
        params.put("age", null);
        queryWrapper.allEq(params,false);
        List<User> userList = this.userMapper.selectList(queryWrapper);
        userList.forEach(System.out::println);
    }

    @Test
    public void testSelectReturnMap(){
        QueryWrapper<User> queryWrapper = new QueryWrapper<>();
        queryWrapper.select("id","name").gt("age" ,25 );
        List<Map<String,Object>> map =  this.userMapper.selectMaps(queryWrapper);
        map.forEach(System.out::println);
    }

    /**
     * 按照直属上级分组，查询每组的平均年龄、最大年龄、最小年龄。
         并且只取年龄总和小于500的组。
         select avg(age) avg_age,min(age) min_age,max(age) max_age
         from user
         group by manager_id
         having sum(age) <500
     */
    @Test
    public void testSelectReturnMap2(){
        QueryWrapper<User> queryWrapper = new QueryWrapper<>();
        queryWrapper.select("avg(age) avg_age","min(age) min_age", "max(age) max_age")
                .groupBy("manager_id").having("sum(age) < {0}", 500);
        List<Map<String,Object>> map =  this.userMapper.selectMaps(queryWrapper);
        map.forEach(System.out::println);
    }

    /**
     * 仅返回第一个字段
     */
    @Test
    public void testSelectReturnObjs(){
        QueryWrapper<User> queryWrapper = new QueryWrapper<>();
        queryWrapper.select("avg(age) avg_age","min(age) min_age", "max(age) max_age");
        List<Object> objects = this.userMapper.selectObjs(queryWrapper);
        objects.forEach(System.out::println);
    }

    /**
     * 多于一条记录时报异常：TooManyResultsException
     */
    @Test
    public void testSelectReturnOne(){
        QueryWrapper<User> queryWrapper = new QueryWrapper<>();
        queryWrapper.eq("id", 1087982257332887553L);
        User one = this.userMapper.selectOne(queryWrapper);
        System.out.println(one);
    }

    @Test
    public void testSelectByLambda(){
        // LambdaQueryWrapper<User> lambdaQueryWrapper = new QueryWrapper<>().lambda();
        // LambdaQueryWrapper<User>  lambdaQueryWrapper= new LambdaQueryWrapper<>();
        LambdaQueryWrapper<User> lambdaQueryWrapper = Wrappers.<User>lambdaQuery();
        lambdaQueryWrapper.like(User::getName, "王");
        List<User> userList = this.userMapper.selectList(lambdaQueryWrapper);
        userList.forEach(System.out::println);
    }

    @Test
    public void testSelectByLambdaChain(){
        List<User> userList = new LambdaQueryChainWrapper<User>(this.userMapper)
                                            .gt(User::getAge, 25).list();
        userList.forEach(System.out::println);
    }

    @Test
    public void testSelectByCustomSql(){
        QueryWrapper<User> queryWrapper = new QueryWrapper<>();
        queryWrapper.eq("id", 1087982257332887553L);
        List<User> userList = this.userMapper.selectAll(queryWrapper);
        userList.forEach(System.out::println);
    }

    @Test
    public void testSelectPage(){
        Page<User> page = new Page<>(1,2);
        IPage<User> iPage = this.userMapper.selectPage(page, null);
        System.out.println("总记录数：" + iPage.getTotal());
        System.out.println("总页数：" + iPage.getPages());
        iPage.getRecords().forEach(System.out::println);
        Page<User> page1 = new Page<>(2,2);
        page.setCurrent(2);
        iPage = this.userMapper.selectPage(page, null);
    }

    /**
     * 自定义分页，可实现多表联查的分页
     */
    @Test
    public void testSelectPageQuery(){
        QueryWrapper<User> queryWrapper = new QueryWrapper<>();
        Page<User> page = new Page<>(1,2);
        IPage<User> iPage = this.userMapper.pageQuery(page, queryWrapper);
        System.out.println("总记录数：" + iPage.getTotal());
        System.out.println("总页数：" + iPage.getPages());
        iPage.getRecords().forEach(System.out::println);
    }
}
