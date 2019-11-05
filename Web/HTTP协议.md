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

##### 请求信息

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

##### 响应信息：服务器端响应客户端

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

##### Request

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
         requst.setCharacterEncoding("utf-8");
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
       - request域：代表一次请求的范围，一般用于**在请求转发的多个资源中共享数据**
       - 方法：
         - setAttribute(String name, Object obj)：存储数据
         - Object getAttribute(String name)
         - void removeAttribute(String name)

     - 获取ServletContext

       - ServletContext getServletContext()
       
     - 动态获取虚拟目录
     
       - String contextPath = request.getContextPath();

##### Response

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


##### ServletContext对象

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

## JSP

- 概念

  - Java Server Pages：Java服务器端页面，可以同时写HTML标签以及java代码

    ```
    <% java代码 %>
    ```

  - 其用于简化书写与服务器交互的数据展示部分的代码

- 原理
  - JSP本质就是一个Servlet（继承了HttpServlet），编译阶段会自动生成.java文件，并被编译为字节码文件
- JSP脚本
  1. <% 代码 %>
     - 其定义的内容，转换后到了Servlet接口中的service方法中
  2. <%! 代码 %>
     - 其定义的内容，转换后到了java类的成员位置
  3. <%= 代码 %>
     - 定义的java代码，会将执行结果输出到页面上

- JSP内置对象：在jsp页面中不需要获取或创建，即可使用的对象
  - 一共有9个内置对象：
    - request
    - response
    - out：字符输出流对象
      - 与response.getWriter()的区别：Tomcat服务器会先找response的输出，之后再进行out的输出