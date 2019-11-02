## Servlet

#### 概念

- Server applet，运行在服务器端的小程序
- Servlet就是一个接口，定义了Java类被浏览器访问到的规则

#### 快速入门

1. 在已创建好的Java EE项目中，新建实现Servlet接口的类，如

   ```
   public class servletDemo01 implements Servlet
   ```

2. 在/WEB-INF/web.xml中，在web-app节点中添加

   ```
   <servlet>
       <servlet-name>demo01</servlet-name>
       <!-- 全类名 -->
       <servlet-class>servlet.servletDemo01</servlet-class>
   </servlet>
   <servlet-mapping>
       <!-- 与上面的servlet-name对应，从而找到class -->
       <servlet-name>demo01</servlet-name>
       <!-- 定义资源请求路径 -->
       <url-pattern>/demo01</url-pattern>
   </servlet-mapping>
   ```

3. 请求资源时，URL如http://localhost:8080/servelt/demo01，即可访问Servlet接口中的service具体实现。

#### 原理分析

