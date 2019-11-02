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

#### 执行步骤

1. 浏览器向服务器发出请求，服务器解析URL路径，以获取访问servlet的资源路径，这里是/demo01
2. Tomcat会去/WEB-INF/web.xml下寻找<url-pattern>值为/demo01的<servlet-mapping>节点，并获取其节点中<servlet-name>的属性值，这里是demo01
3. Tomcat继续去寻找<servlet-name>的属性值为demo01的<servlet>节点，以获取<servlet-class>的属性值，得到响应资源的全类名
4. 然后Tomcat会去加载该类的字节码到内存，以反射的方式创建该类的实例
5. 再去调用该实例的service方法，以响应资源请求

#### Servlet的生命周期（即接口函数执行时机）

- 同一个资源（完整URL），都只有一个Servlet对象

  - 因此为了避免并发，所以**不要在Servlet接口的实现类中定义可修改的全局变量**（加锁会导致严重性能问题）

- init：仅Servlet接口实现类对象创建时被执行一次

  - 默认情况下，第一次访问该资源时，Servlet被创建

  - 可以配置为跟随服务器启动，在/WEB-INF/web.xml里的<servlet>节点中添加

    ```
    <!-- <0：第一次调用时创建（默认：-1）；>=0：服务器启动时创建 -->
    <load-on-startup>5</load-on-startup>
    ```

- service：每次资源请求时，都会被执行

- destroy：当Servlet被正常关闭时执行

  - 即服务器正常关闭时，先调用destroy方法，再销毁Servlet接口实现类对象

#### Servlet注解配置（不再需要配置web.xml）

- Servlet 3.0以上支持

- 注解写在Servlet实现类上

  ```
  @WebServlet("/demo02")
  // @WebServlet(urlPatterns = "/demo02", loadOnStartup = -1)
  ```

#### Servlet体系结构

- abstract GenericServlet implements Servlet

- - 对**除service方法**外的方法进行了**空实现**，以简化代码

- abstract HttpServlet extends GenericServlet

  - 简化基于Http协议的代码编写
  - 其实现的service方法，根据数据请求形式（七种请求形式），分别调用不同的数据处理方法
    - 如最常用的：doGet()、doPost()
    - 仅需重写所需要的数据处理方法即可