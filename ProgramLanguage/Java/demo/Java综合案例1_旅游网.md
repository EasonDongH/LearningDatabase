# Java综合案例1_旅游网

## 整体框架

### Web层

- Servlet：前端控制器
- html：视图
  - Bootstrap
  - jQuery
- Filter：过滤器
- BeanUtils：数据封装
- Jackson：json解析器

### Service层

- Javamail：邮件工具
- Redis：NoSQL数据库
  - Jedis：基于java的redis客户端

### Dao层

- MySQL
- Druid：数据库连接池
- JdbcTemplate：jdbc工具

## 功能

#### 注册

- 表单验证
  - 表单提交，校验所有内容
  - 某个输入失去焦点时，校验该输入
  - 校验项
    - 用户名：6-20位
    - 密码：6-20
    - email：正则
    - 姓名：非空
    - 手机号：正则
    - 出生日期：非空
    - 验证码：非空
- Ajax异步提交
  - 表单提交<=>servlet<=>service<=>dao<=>数据库
- 邮箱激活
  - 发送激活邮件，链接到激活Servlet，根据唯一激活码将用户状态激活，并返回激活信息

#### 登录

#### 退出