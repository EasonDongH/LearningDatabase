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

1. 验证验证码
2. 根据用户名、密码获取User对象
3. 检查User对象是否激活
4. 已激活=》将User对象保存至Session中

#### 退出

1. 清除Session中的User对象
2. 跳转登录界面

#### 提取公共Servlet

- 每个功能写一个Servlet，会导致Servlet数量爆炸

- 提取出一个公共的Servlet，然后再分发到具体Servlet的具体方法

  - 公共Servlet

    ```
    public class BaseServlet extends HttpServlet {
        @Override
        protected void service(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
            String uri = req.getRequestURI();
            String methodName = uri.substring(uri.lastIndexOf("/") + 1);
            try {
                Method method = this.getClass().getMethod(methodName, HttpServletRequest.class, HttpServletResponse.class);
                method.invoke(this, req, resp);
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }
    ```

  - UserServlet：提供与User相关的所有方法，如登录、退出等

    ```
    @WebServlet("/user/*")
    public class UserServlet extends BaseServlet {
    
        public void login(HttpServletRequest req, HttpServletResponse resp){
            System.out.println("UserServlet.login");
        }
    }
    ```

  - 前台：请求的URL要变化

    ```
    $.post("user/login", $("#loginForm").serialize(), function (data) {});
    ```

#### 分类类别

- 查询所有分类，添加到前端页面
- 考虑其分类数据不会经常变化，因此可以使用Redis进行缓存优化

#### 根据分类，查询线路信息

- 分页查询
  - 前端传递数据：类别id、当前页码
  - 后台进行分页查询
- 前台展示
  - 总记录数、总页数
  - 页码展示逻辑
    - 页码一次至多出现10个
    - 当前页码尽最大可能保证在中间（前5后4）
      - 考虑当前页码<=5的情况（不需要在中间）
      - 考虑剩余不足10页的情况