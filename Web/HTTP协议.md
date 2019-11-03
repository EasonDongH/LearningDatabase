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

##### 响应信息

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

       ```
       request.getRequestDispatcher("服务器内的另一个Servlet").forward(request, response);
       ```

       - 特点：
         1. 浏览器地址栏URL不发生变化
         2. 只能转发到服务器内部资源
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

