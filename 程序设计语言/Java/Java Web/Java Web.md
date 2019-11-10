# Java Web

## HTTP协议

### 概念

- Hyper Text Transfer Protocol，超文本传输协议
  - 定义了客户端和服务器端通信时的数据格式
- 基于TCP/IP，默认端口号为80
- 基于【请求/响应】模型：一次请求对应一次响应
- 无状态：每次请求之间相互独立，不能及交互数据
- 历史版本：
  - 1.0：每次请求都会建立新的连接
  - 1.1：每次数据交互完之后，将等待一段时间，时间内再次发生数据交互，则**复用连接**

### 数据格式

#### 请求信息

1. 请求行
   - 请求方式 请求URL 请求协议/版本，如：GET /login.html HTTP/1.1
   - 请求方式：HTTP协议有7种请求方式，常用的有2种：
     - GET
       - 请求参数在请求行中（URL后）
       - 请求的URL长度有限
     - POST
       - 请求参数在请求体中
       - 请求的URL长度不限
2. 请求头
   - 客户端浏览器告诉服务器一些自己的信息
   - 请求头名称：请求头值
   - 常见的请求头
     1. User-Agent：用户系统、所用浏览器相应信息
        - 可以在服务器端获取盖头的信息，解决浏览器兼容性问题
     2. Referer：给服务器提供当前请求的URL信息
        - 防盗链
        - 统计
3. 请求空行
   - 空行，用于分隔POST的请求头与请求体
4. 请求体
   - 封装POST的请求参数

#### 响应信息：服务器端响应客户端

- 数据格式
  1. 响应行
     - 组成：协议/版本 响应状态码 状态码描述【HTTP/1.1 200 OK】
       - 状态码：服务器告诉浏览器，本次请求/响应的状态
         - 常见状态码
           - 1xx：服务器接收客户端消息，但服务器认为没有接收完成，等待一段时间后，发送1xx状态码询问是否还有数据
           - 2xx：成功，如：200（OK）
           - 3xx：302（重定向）、304（访问缓存）
           - 4xx：客户端错误，如404（请求资源的URL不存在）、405（服务器不存在所需的请求方式，如服务器没有提供GET方法）
           - 5xx：服务器错误，如：500（服务器内部出现异常）
  2. 响应头
     - 格式：响应头名称：值
     - 常见响应头
       - Content-Type：本次响应体的数据格式、编码格式【Content-Type: text/html;charset=UTF-8】
       - Content-disposition：以什么格式打开响应体数据
         - in-line：默认值，在当前页面内打开
         - attachment;filename=xxx：以附件形式打开
  3. 响应空行
  4. 响应体

#### Request

- **由Tomcat创建Request对象**，传递给service方法

- 功能

  1. 用于获取请求消息数据

     - 获取请求行
       - 获取请求方式：String getMethod()
       - 获取虚拟路径：String getContextPath()
       - 获取Servlet路径：String getServletPath()
       - 获取GET请求参数：String getQueryString()
       - 获取请求URI：String getRequestURI()
       - 获取协议及版本：String getProtocol()
       - 获取客户机IP地址：String getRemoteAddr()
     - 获取请求头
       - 通过请求头名称获取请求头值：String getHeader(String name)
       - 获取所有请求头：Enumeration<String> getAllHeaderNames() 
     - 获取请求体
       - POST请求参数已被封装为数据流
         - 获取字符流：BufferedReader getReader()
         - 获取字节流：ServleStream getInputStream()

  2. 其他功能

     - 获取请求参数的通用方式：不区分GET、POST

       - String getParameter(String name)：根据参数名称获取参数值

       - String[] getParameterValues(String name)：根据参数名称获取参数值的数组（同一个参数名有多个值）

       - Enumeration<String> getParameterNames()：获取所有参数名称

       - Map<String,String[]> getParameterMap()：获取所有参数的Map集合

       - **中文乱码问题**：GET不会乱码而POST会乱码（Tomcat 8自行解决了GET中文乱码问题），解决：

         ```
         // 设置流的字符集
         request.setCharacterEncoding("utf-8");
         ```

     - 请求转发：一种在服务器内部进行资源跳转（从AServlet跳转到BServlet中）的方式

       ```java
       request.getRequestDispatcher("服务器内的另一个Servlet").forward(request, response);
       ```

       - 特点：
         1. 浏览器地址栏URL不发生变化
         2. 只能转发到当前服务器内部资源
         3. **对于浏览器来说，只进行了一次请求**

     - 共享数据

       - 域对象：在一定范围内可以共享数据的对象
       - request域：代表**一次请求**的范围，一般用于**在请求转发的多个资源中共享数据**
       - 方法：
         - setAttribute(String name, Object obj)：存储数据
         - Object getAttribute(String name)
         - void removeAttribute(String name)

     - 获取ServletContext

       - ServletContext getServletContext()
       
     - 动态获取虚拟目录
     
       - String contextPath = request.getContextPath();

#### Response

- 功能：设置响应消息

  - 设置响应行

    - 设置状态码：setStatus(int sc)

  - 设置响应头

    - setHeader(String name, String value)

  - 设置响应体

    - 使用步骤：

      1. 获取输出流

         - 字符输出流：PrinterWriter getWriter()
         - 字节输出流：ServletOutputStream getOutputStream()

      2. 使用输出流，将数据输出到客户端浏览器

         - 中文乱码：编解码码表不一致（Tomcat默认ISO-8859-1）

           - 获取输出流对象之前，进行编码设置

           - 并告诉浏览器自己的编码码表

             ```java
             // response.setCharacterEncoding("utf-8"); // 可以忽略
             
             response.setHeader("content-type", "text/html;charset=utf-8");
             // 简单形式设置编码
             response.setContentType("text/html;charset=utf-8");
             
             ```

- 方法

  - 重定向

    ```java
    // 在ResponseDemo01中，重定向到ResponseDemo02
    // response.setStatus(302);
    // response.setHeader("location", "/ResponseDemo/ResponseDemo02");        response.sendRedirect("/ResponseDemo/ResponseDemo02");
    ```

    - 特点
      - 地址栏发生变化
      - 重定向可访问其他站点的资源
      - 重定向是两次请求（**意味着不能通过request域对象来共享数据**）


#### ServletContext对象

- 概念：**代表整个Web应用，可以和程序的容器（服务器）通信**

- 获取：

  - 通过request对象获取：request.getServletContext()
  - 通过HttpServlet获取：this.getServletContext()

- 功能：

  - 获取MIME类型

    - MIME类型：互联网通信过程中定义的一种文件数据类型
      - 格式：大类型/小类型，如：text/html、image/jpeg
    - 获取方式：String getMimeType(String file)

  - 域对象：共享数据

    - 范围：共享所有用户请求的数据；生命周期=整个软件运行生命周期（启动便创建）

  - 获取文件的真实路径（服务器项目所在路径）

    - 获取真实路径后，作为服务器路径下所有资源的路径**前缀**

    - String getReadlPath(String path)

      ```
      // 获取web目录下的资源
      String path1 = context.getRealPath("/a.txt");
      // 获取WEB-INF目录下的资源
      String path2 = context.getReadlPath("/WEB-INF/b.txt");
      // 获取src目录下的资源
      String path3 = context.getRealPaht("/WEB-INF/classes/c.txt");
      ```

    - 下载文件名中的中文乱码问题：问题在于浏览器的不同导致的编码不一致，解决方法就是根据“user-agent”请求头获取浏览器信息，从而根据浏览器对文件名进行不同的编码

### 会话

- 浏览器第一次给服务器发送请求，会话建立，直到有一方断开
- 一次会话中包含多次请求和响应
- 功能：在一次会话的多次请求/响应之间共享数据
- 分类：
  - 客户端会话技术：Cookie
  - 服务器端会话技术：Session

#### Cookie

- 概念：客户端会话技术，将数据保存至客户端

- 过程：

  - 浏览器发起第一次请求，服务器返回响应信息，响应头中携带Cookie信息

    ```
    Set-Cookie:键=值
    ```

  - 浏览器将Cookie信息保持在自身内存中，在下一次发送请求时附加在请求头上

    ```
    Cookie:键=值
    ```

- 方法：

  ```
  // 服务器在响应头添加Cookie信息
  response.addCookie(new Cookie("键", "值"));
  // 服务器获取请求头中的Cookie信息
  Cookie[] cookies = request.getCookies();
  for(Cookie ck : cookies) {
      if(ck.getName() == "我想要的键") {
          ck.getValue();
      }
  }
  ```

  ### 细节

  1. 一次可不可以发送多个Cookie？

     - 可以；在HTTP协议中，同一个响应头对应多个数据时，用”;“分隔

  2. Cookie在浏览器保存多久？

     - 默认情况：浏览器关闭时，销毁Cookie

     - 持久化存储：

       ```
       cookie.setMaxAge(int seconds)
       ```

       - 参数说明
         - 正数：将Cookie写到硬盘，并指明存活时间（到时自动删除）
         - 负数：默认值
         - 0：表示删除该Cookie信息

  3. Cookie能不能存中文？

     - 在Tomcat 8之前，Cookie不能直接存中文，否则报错
     - 一般采用URL编码中文进行存储
     - Tomcat 8之后，支持中文，但对一些特殊字符依旧不支持
  
  4. Cookie获取范围？
  
     - 同一个Tomcat中，不同Web项目间共享Cookie
       - 使用cookie.setPath(String path)，path设置为"/"即为共享
     - 不同Tomcat中，一级域名相同，则可以共享Cookie
       - setDomain(".baidu.com"); tieba.baidu.com、news.baidu.com中的Cookie可以共享
  
  ### 特点
  
  1. Cookie存储数据在客户端浏览器
  2. 【持久化存储时】浏览器对单个Cookie的大小有限制（4kb），以及对同一个域名下的Cookie总数也有限制（20个）
  3. Cookie一般用于存储少量的、不太敏感的数据
     - 比如，在不登录的情况下，完成服务器对客户端的身份识别


#### Session

- 概念：服务器端会话技术，在**一次会话**的**多次请求**之间共享数据，将数据保存在服务器对象中，如HttpSession

- 方法

  ```
  HttpSession session = request.getSession();
  session.setAttribute("msg", "hello");
  Object obj = session.getAttribute("msg");
  removeAttribute("msg");
  ```

- 原理

  - Session的实现是依赖于Cookie的
    - 在服务器端第一次获取Session时，会在服务器创建一个Session对象，该对象有一个JSESSIONID
    - 并且该JSESSIONID会作为响应头的一部分传给浏览器：set-cookie:JSESSIONID=xxxx
    - 接下来的浏览器请求将会携带这个JSESSIONID，作为请求头到服务器：cookie:JSESSIONID=xxxx
    - 服务器会自动获取该JSESSIONID，并且寻找是否存在该ID的Session对象，如果找到了则返回
    - 因此，**一次会话中的Session对象是唯一的**

- 细节

  1. 当客户端关闭后，服务器不关闭，两次获取的Session是同一个吗？
     - 默认情况下：不是
     - 可以通过在本地保存一个name为JSESSIONID的Cookie，其值为服务器的session.getID()，并且将其Cookie的MaxAge设置为一定大的值，即可
  2. 客户端不关闭，服务器关闭，两次获取的Session是同一个吗？
     - 不是同一个，但要确保数据不丢失
     - Session的钝化：在服务器正常关闭之前，将Session对象序列化至硬盘
     - Session的活化：在服务器启动后，将Session文件反序列化为对象（Session的地址值发生了变化，但SessionID不变）
     - 通过Tomcat去启动服务，能够自动进行钝化/活化；而使用IDEA，会进行钝化，但重启服务器时IDEA会先将work文件夹删除（存储Session.ser文件的文件夹），从而不会活化成功
  3. Session什么时候被销毁
     - 服务器关闭
     - session.invalidate()
     - session默认的实效时间：30分钟
       - 可以在web.xml中重新配置：session-timeout

- 特点

  - Session用于存储一次会话的多次请求的数据，存在服务器端（相对安全），也称为会话域
  - Session可以存储任意类型、任意大小的数据（Cookie值类型只能是String，且有大小、数量的限制）

## Tomcat

#### 简介

Apache基金组织，中小型JavaEE服务器，仅支持少量Java规范的servlet/jsp，开源免费。

#### 安装

- 免安装，解压、进行配置即可

- 建议安装路径不要有中文

- Tomcat目录结构

  |  目录   |         说明         |
  | :-----: | :------------------: |
  |   bin   |      可执行文件      |
  |  conf   |       配置文件       |
  |   lib   |      依赖jar包       |
  |  logs   |         日志         |
  |  temp   |       临时文件       |
  | webapps |     存放web项目      |
  |  work   |    存放运行时数据    |
  |  其他   | 版权信息、版本信息等 |

#### 使用

- 开启：bin/startup.bat
- 关闭：bin/shutdown.bat
- 在浏览器输入：http://127.0.0.1:***8080***，即可访问Tomcat默认项目
- 一般将端口号修改为HTTP协议默认端口号：80，即可在浏览器访问时不用再输入端口号

#### 常见问题

- 启动时cmd窗口一闪而过
  - 原因1：没有正确配置JAVA_HOME环境变量，或注意JDK版本是否符合要求
    - 在catalina.ini文件中需要读取JAVA_HOME
  - 原因2：注意端口号是否被占用？查看logs日志记录
    - 关闭占用端口的程序：cmd => netstat -ano => 找到port对应的PID => kill该进程
    - 修改端口号：conf/server.xml => 修改所有带有port属性的节点值

#### 项目部署

1. 方式1：直接将项目放到webapps文件夹中

   - 访问时：http://127.0.0.1:8080/hello/hello.html
     - \hello：项目的访问路径，也称虚拟路径
     - hello.html称为资源文

2. 方式2：将项目打成war包，然后放入webapps路径下，Tomcat将会自动进行解压缩

3. 方式3：不需要将项目复制到webapps路径下

   - 在**conf\server.xml**中进行配置（注意该配置方式需要关闭服务，修改后重启服务）

     1. 在<host>节点下添加：

        ```
        <Context docBase="项目路径" path="将要使用的虚拟路径">
        ```

     2. 访问方式：http://127.0.0.1:8080/将要使用的虚拟路径/hello.html

   - 在**\conf\Catalina\localhost**中添加配置文件（这种配置方式不要重启服务，最为推荐，称为**热部署**）

     1. 添加备注文件：xml配置文件.xml
     2. 在配置文件中添加内容：如上
     3. 访问方式：http://127.0.0.1:8080/xml配置文件/hello.html
     4. 如果要不使用该项目，修改配置文件名称即可

#### 静态项目与动态项目

- 目录结构

  - Java动态项目的目录结构

    -- 项目的根目录

    ​	-- WEB-INF目录

    ​		-- web.xml：web项目的核心配置文件

    ​		-- classes目录：放置字节码文件的目录

    ​		-- lib目录：放置依赖的jar包

#### 与IDEA结合

1. Run => Edit Configuration
2. 左侧栏选择 => Defaults => Tomcat Server => Local
   - Application server => 定位Tomcat路径
   - OK
3. 再次打开Edit Configuration
   - 在左侧出现Tomcat Server栏，选中
   - 在右侧选择Deployment页面
   - 在Application context定义项目虚拟路径
4. 新建Module => 选择Java Enterprise，右侧
   -  Java EE version：Java EE 7
   - Application Server：选择Tomcat版本
   - 在Additional Lib...中，勾选Web Application
   - OK
5. **【热部署配置】**再次Run => Edit Configuration，在右侧选择Tomcat Server
   - 将On Update action与OnFrame deactivation更改为：Update resources
   - 之后更新页面资源后，无需重启项目
6. 部署完成

#### IDEA项目路径与Tomcat部署路径

1. IDEA为每一个Tomcat部署的项目单独建立一份配置文件
   - Using CATALINA_BASE:   "..."
2. IDEA工作目录 vs. Tomcat部署的web项目
   - Tomcat访问的是【Tomcat部署的web项目】，在\out\artifacts文件夹下
   - 【Tomcat部署的web项目】对应【IDEA工作目录】下的web目录下的资源
   - WEB-INF目录下的资源不能被浏览器直接访问

## Servlet

### 概念

- Server applet，运行在服务器端的小程序
- Servlet就是一个接口，定义了Java类被浏览器访问到的规则

### 快速入门

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

### 执行步骤

1. 浏览器向服务器发出请求，服务器解析URL路径，以获取访问servlet的资源路径，这里是/demo01
2. Tomcat会去/WEB-INF/web.xml下寻找<url-pattern>值为/demo01的<servlet-mapping>节点，并获取其节点中<servlet-name>的属性值，这里是demo01
3. Tomcat继续去寻找<servlet-name>的属性值为demo01的<servlet>节点，以获取<servlet-class>的属性值，得到响应资源的全类名
4. 然后Tomcat会去加载该类的字节码到内存，以反射的方式创建该类的实例
5. 再去调用该实例的service方法，以响应资源请求

### Servlet的生命周期（即接口函数执行时机）

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

### Servlet注解配置（不再需要配置web.xml）

- Servlet 3.0以上支持

- 注解写在Servlet实现类上

  ```
  @WebServlet("/demo02")
  // @WebServlet(urlPatterns = "/demo02", loadOnStartup = -1)
  ```

### Servlet体系结构

- abstract GenericServlet implements Servlet

- - 对**除service方法**外的方法进行了**空实现**，以简化代码

- abstract HttpServlet extends GenericServlet

  - 简化基于Http协议的代码编写
  - 其实现的service方法，根据数据请求形式（七种请求形式），分别调用不同的数据处理方法
    - 如最常用的：doGet()、doPost()
    - 仅需重写所需要的数据处理方法即可

## JSP

### 概念

- Java Server Pages：Java服务器端页面，可以同时写HTML标签以及java代码

  ```
  <% java代码 %>
  ```

- 其用于简化书写与服务器交互的数据展示部分的代码

### 原理

- JSP本质就是一个Servlet（继承了HttpServlet），编译阶段会自动生成.java文件，并被编译为字节码文件
  
- JSP脚本
  1. <% 代码 %>
     - 其定义的内容，转换后到了Servlet接口中的service方法中
  2. <%! 代码 %>
     - 其定义的内容，转换后到了java类的成员位置
  3. <%= 代码 %>
     - 定义的java代码，会将执行结果输出到页面上

- JSP指令

  - 作用：用于配置JSP页面，导入资源文件

  - 格式

    ```
    <%@ 指令名称 属性名1=值1 属性名2=值2 ... %>
    ```

  - 指令分类

    1. page：配置JSP页面

       - contentType：等同于response.setContentType("...")
       - pageEncoding：设置当前页面编码
       - buff：缓冲器大小
       - import：给JSP里的java代码导入jar包
       - errorPage：当前页面发生异常后跳转的页面
       - isErrorPage：标识当前页面是否是错误页面，标识后可以使用内置对象：exception

    2. include：导入其他页面资源，作为当前页面的一部分

       ```
       <%@ include file="..." %>
       ```

    3. taglib：导入资源（标签库）

       ```
       <%@ taglib prefix="自定义" uri="..." %>
       ```

- JSP特有注释

  - <%-- --%>：可以注释java代码和HTML标签，并且被注释的内容不会发送到响应体

### JSP内置对象

- 在jsp页面中不需要获取或创建，即可使用的对象

- 一共有9个内置对象（其实都是变量名）：
  - pageContext（PageContext）：当前页面内共享数据，还可以获取其它8个对象

    ```
    pageContext.getXxxx()
    ```

  - request（HTTPServletRequest）：一次请求内共享数据（页面转发）

  - response（HTTPServletResponse）：响应对象

  - session（HttpSession）：一次会话，多次请求

  - application（ServletContext）：所有用户间共享数据

  - page（Object）：当前页面（Servlet，this）对象

  - out（JspWriter）：字符输出流对象
  
- 与response.getWriter()的区别：Tomcat服务器会先找response的输出，之后再进行out的输出

- config（ServletConfig）：Servlet的配置对象

- exception（Throwable）：异常对象

      - 需要在page指令里，配置isErrorPage=true

## Filter

### 概念

- web中的过滤器：当访问服务器资源时，过滤器可以将请求拦截下来，完成一些特殊的功能。
- 作用：一般用于完成通用的操作，比如：登录验证、统一编码处理、敏感字符过滤

### 快速入门

- implements Filter
- 使用注解@WebFilter，加上**拦截路径**
- 在doFilter中进行验证
- filterChain.doFilter会将请求放行

### 细节

#### web.xml配置

```
<filter>
	<filter-name>filterName</filter-name>
	<filter-class>过滤器接口实现类的绝对路径</filter-class>
</filter>
<filter-mapping>
	<filter-name>filterName</filter-name>
	<url-pattern>/*</url-pattern>
</filter-mapping>
```

#### 执行流程

1. 浏览器请求资源，先被过滤器，此时一般是对request对象进行消息增强

2. 如果放行，则执行chain.doFilter

3. 接着，该请求返回时，会执行chain.doFilter下面的代码，此时一般用于对response对象进行消息增强

   ![](https://note.youdao.com/yws/public/resource/48d56fd49a97c59bb18680cdc52cd835/xmlnote/BD7B6432D51B4ADE94803572ACB646F3/17494)

#### 生命周期

- init方法：在服务器成功启动后，执行该方法
  - 用于加载资源
- destroy方法：在服务器正常关闭前，执行该方法
  - 用于是否资源
- doFilter方法：每一次请求被该Filter拦截时，都会被执行

#### 配置详解

- 配置拦截路径：
  1. 指定资源拦截，如：/index.jsp
  2. 目录拦截，如：/user/*，拦截user目录（指的是虚拟路径）下的所有资源
  3. 后缀名拦截，如：*.jsp
  4. 拦截所有资源：/*
- 配置拦截方式：
  - 指的是访问资源的方式，比如：浏览器访问、转发访问等
  - 注解配置：设置dispatcherTypes属性
    1. REQUEST：默认值，浏览器请求
    2. FORWARD：转发访问
    3. INCLUDE：包含访问资源
    4. ERROR：错误跳转资源
    5. ASYNC：异步访问资源

#### 过滤器链

- 配置多个过滤器，对同一类资源进行过滤
- 过滤器顺序
  - 注解配置：按照类名字符串比较规则降序排序，依次执行
  - web.xml配置：按filter-mapping中书写的顺序排序，依次执行

# MVC

### 简介

##### 发展史

- 早期只有Servlet，只能使用response输出标签数据
- 后来有了jsp，但过度使用jsp会使得前端页面过于复杂、混乱，难于分析、维护
- 再后来，java引入MVC开发模式，来使得程序设计更加合理

##### MVC

- M：model，模型（JavaBean）

  - 完成具体的业务操作，如查询数据库、封装对象

- V：View，视图（JSP）

  - 展示数据

- C：Controller，控制器（Servlet）

  - 获取用户输入（请求参数）
  - 调用模型
  - 将数据交给视图

- 流程

  - 浏览器请求由Controller处理

  - Controller去请求Model，Model进行业务处理

  - Controller获取数据后，送给View，View做数据展示

    ![](https://note.youdao.com/yws/public/resource/48d56fd49a97c59bb18680cdc52cd835/xmlnote/E17B60EE98B949188FE2ECD02D0D063C/17490)

- 优点
  - 可维护性高
  - 耦合性低，便于分工
- 缺点
  
  - 使得项目变得复杂，不适用于小型项目

### EL表达式

##### 简介

- Expression Language，表达式语言
- 用于替换和简化jsp页面中java代码的编写
- 一般用于运算、获取值

##### 语法

- ${表达式}
- \\${表达式}：将忽略该条EL表达式

##### 作用

- 运算：
  1. 算数运算符：/(div) %(mod)
  2. 空运算符：empty，用于判断字符串、集合、数组的长度是否为null或为0
     - ${empty list}：仅当对象为null或list长度为0返回true；这个list是某个域中的键
     - ${not empty list}
- 获取值
  - el表达式只能从域对象中获取值
    - ${域名称.键名}：从指定域中获取键的值，域对象没有该键的情况下返回空字符串
      - 域名称（**域范围从小到大排列**）：
        - pageScope ---> pageContext
        - requestScope ---> request
        - sessionScope ---> session
        - applicationScope ---> application（ServletContext）
    - ${键名}：依次从最小的域开始寻找该键，直到找到为止
  - 如何获取对象、Map、List的值
    - ${requestScope .user.name}：将获取request域中找键为user的值，并使用user.getName()获取值
    - ${requestScope .map.键}或${request.map["键"]}
    - ${reqrequestScope est.list[索引]}：索引越界不会报错

##### 隐式对象

- 不用创建直接使用的对象，比如上面的四个域对象

- el有11个隐式对象

  - pageContext：

    - 获取JSP其他八个内置对象

      - 在jsp动态获取虚拟目录

        ```
        ${pageCOntext.request.contextPath}
        ```

##### 注意

- 在page属性中配置isELIngored=true将会忽略页面中所有EL表达式

### JSTL

##### 概念

- Java Server Page Tag Library，JSP标准标签库

  - 由Apache提供的开源jsp标签

- 用于简化和替换jsp页面上的java代码

- 使用java.sun.com/jsp/jstl/core，常用prefix=“c”

  ```
  <%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
  ```

##### 常用标签

- if

  ```
  <!-- 
  	test表达式为true，则显示标签内容 
  -->
  <c:if test="${not empty list}">
  	标签内容
  </c:if>
  ```

- choose：相当于switch语句

  ```
  <c:choose>
  	<c:when test="${num==1}">星期一</c:when>
  	<c:when test="${num==2}">星期二</c:when>
  	<c:when test="${num==3}">星期三</c:when>
  	...
  	<c:otherwise>输入有误</c:otherwise>
  </c:choose>
  ```

- foreach

  - varStatus：
    - s.count：遍历的次数
    - s.index：容器中元素的索引

  ```
  <c:forEach begain="1" end="10" var="i" step="1" >
  	${i}<br>
  </c:forEach>//1 2 3 4 ... 10 
  <!-- 遍历容器 -->
  <c:forEach items="${request.list}" var="str" varStatus="s">
  	${str} ${s.index} ${s.count} <br>
  </c:forEach>
  ```

  





# 知识点

## 前端

#### 获取所有选中的checkbox

- 表单默认提交选中的记录行，所以给所有checkbox套一个form即可
- 然后给按钮添加单击事件，获取到表单后执行form.submit()即可

## 后端

#### 转发与重定向

- 当两个Servlet或一个Servlet与一个页面有数据交互的时候，使用转发，比如Servlet A获取数据，由Servlet B处理数据或页面B展示数据
- 否则，使用重定向