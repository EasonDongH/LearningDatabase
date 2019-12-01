# Spring MVC

##  概念

### 三层架构

- 表现层
  - 即常说的web层，负责接收客户端请求，向客户端响应结果
  - 表现层的设计一般使用MVC模型
- 业务层
  - 即常说的service层，负责业务逻辑处理
  - 框架有：Spring
- 持久层
  - 即常说的dao层。负责数据持久化
  - 框架有：mybatis

### MVC模型

- Model View Controller，模型-视图-控制器，是一种用于设计创建web应用程序表现层的模式
- Model：即数据模型（JavaBean），用于封装数据
- View：即jsp或html，用于展示数据
- Controller：是应用程序中处理用户交互的部分，用于处理程序逻辑

### Spring MVC

- Spring MVC是一种基于Java的、实现了MVC设计模型的、请求驱动类型的、轻量级的web框架

- 属于Spring FrameWork的后续产品，已经融合在Spring Web Flow中

- 在使用Spring进行web开发时，可选择MVC开发框架，如：Spring MVC、Structs2等

  - Spring MVC在Spring 3.0之后全面超越Structs2

- Spring MVC可以通过一套注解让一个简单的Java类成为处理请求的控制器，而无需实现任何接口

- Spring MVC还支持RESTful编程风格的请求

- Spring MVC在三层架构中的位置

  ![](https://note.youdao.com/yws/public/resource/48d56fd49a97c59bb18680cdc52cd835/xmlnote/821E8243F2F24EFA87BCDF6E3B879D77/17560)

#### 优势

- 角色划分明确
  - 前端控制器（DispatcherServlet）、请求到处理器映射（HandlerMapping）、处理器适配器（HandlerAdapter）、视图解析器（ViewResolver）、处理器或页面控制器（Controller）、验证器（Validator）、命令对象（Command，请求参数绑定到的对象）、表单对象（Form Object）
- 分工明确，易于扩展
- 命令对象就是一个POJO，可以使用命令对象作为业务对象
- 与Spring其它框架无缝集成

#### SpringMVC vs. Structs2

- 共同点
  - 都是表现层框架，都基于MVC模型
  - 底层都离不开原始的ServletAPI
  - 处理请求的机制都是一个核心控制器
- 区别
  - SpringMVC的入口（核心控制器）是一个Servlet，而Structs2是Filter
  - SpringMVC是基于方法设计的（单例），Structs2是基于类的（多例），每次执行都会创建一个动作类
  - SpringMVC使用更简洁，同时支持JSP303标准，处理ajax请求更方便
    - JSP303是一套JavaBean参数校验的标准，其定义了很多常用的校验注解

## 快速入门

### 需求

- 搭建Spring MVC框架的Web应用
- 可从index.jsp中的超链接跳转到另一个页面

### 实现

- 页面

  - index.jsp：注意配置页面支持中文；提供一个超链接href="hello"
  - success.jsp：显示“入门成功”

- pom依赖

  ```xml
   <properties>
      <spring.version>5.0.2.RELEASE</spring.version>
    </properties>
  
    <dependencies>
      <dependency>
        <groupId>org.springframework</groupId>
        <artifactId>spring-web</artifactId>
        <version>${spring.version}</version>
      </dependency>
  
      <dependency>
        <groupId>org.springframework</groupId>
        <artifactId>spring-webmvc</artifactId>
        <version>${spring.version}</version>
      </dependency>
  
      <dependency>
        <groupId>javax.servlet</groupId>
        <artifactId>servlet-api</artifactId>
        <version>2.5</version>
        <scope>provided</scope>
      </dependency>
  
      <dependency>
        <groupId>javax.servlet.jsp</groupId>
        <artifactId>jsp-api</artifactId>
        <version>2.0</version>
        <scope>provided</scope>
      </dependency>
    </dependencies>
  </project>
  ```

- 配置web.xml

  ```xml
  <!DOCTYPE web-app PUBLIC
   "-//Sun Microsystems, Inc.//DTD Web Application 2.3//EN"
   "http://java.sun.com/dtd/web-app_2_3.dtd" >
  
  <web-app>
    <display-name>Archetype Created Web Application</display-name>
  
    <servlet>
      <servlet-name>dispatcherServlet</servlet-name>
      <servlet-class>org.springframework.web.servlet.DispatcherServlet</servlet-class>
      <init-param>
        <param-name>contextConfigLocation</param-name>
        <!-- 让Servlet加载mvc配置文件 -->
        <param-value>classpath:springmvc.xml</param-value>
      </init-param>
      <!--服务器一启动就加载Servlet-->
      <load-on-startup>1</load-on-startup>
    </servlet>
  
    <servlet-mapping>
      <servlet-name>dispatcherServlet</servlet-name>
      <!-- 拦截所有请求 -->
      <url-pattern>/</url-pattern>
    </servlet-mapping>
  </web-app>
  ```

- 在resources包下新建springmvc.xml

  ```xml
  <?xml version="1.0" encoding="UTF-8"?>
  <beans xmlns="http://www.springframework.org/schema/beans"
         xmlns:mvc="http://www.springframework.org/schema/mvc"
         xmlns:context="http://www.springframework.org/schema/context"
         xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
         xsi:schemaLocation="
          http://www.springframework.org/schema/beans
          http://www.springframework.org/schema/beans/spring-beans.xsd
          http://www.springframework.org/schema/mvc
          http://www.springframework.org/schema/mvc/spring-mvc.xsd
          http://www.springframework.org/schema/context
          http://www.springframework.org/schema/context/spring-context.xsd">
  
      <!--配置注解扫描-->
      <context:component-scan base-package="com.easondongh"></context:component-scan>
  
      <!--配置MVC支持注解-->
      <mvc:annotation-driven></mvc:annotation-driven>
  
      <!-- 视图解析器对象 -->
      <bean id="internalResourceViewResolver" class="org.springframework.web.servlet.view.InternalResourceViewResolver">
          <property name="prefix" value="/WEB-INF/pages/"/>
          <property name="suffix" value=".jsp"/>
      </bean>
  </beans>
  ```

- 在java包下新建controller类

  ```java
  package com.easondongh.controller;
  
  import org.springframework.stereotype.Controller;
  import org.springframework.web.bind.annotation.RequestMapping;
  
  @Controller
  public class HelloController {
  
      @RequestMapping(path = "/hello")
      public String saveHello(){
          System.out.println("Hello SpringMVC");
          return "success";
      }
  }
  ```

- 整体执行流程

  ![](https://note.youdao.com/yws/public/resource/48d56fd49a97c59bb18680cdc52cd835/xmlnote/13386791AF4C49CF838366BB023F5B67/17565)

## SpringMVC组件

- 快速入门案例中的组件调用流程图

  ![](https://note.youdao.com/yws/public/resource/48d56fd49a97c59bb18680cdc52cd835/xmlnote/5492316DE8D0418B8C3612048EDBDC1C/17567)

- DispatcherServlet：前端控制器

  - MVC中的C，是整个流程控制的中心
  - 当用户请求到达前端控制器时，由其调用其它组件处理用户的请求

- HandlerMapping：处理器映射器

  - 负责根据用户的请求，查找处理器（Handler）
  - SpringMVC提供了不同的映射器实现不同的映射方式，如：配置文件、实现接口、注解等

- Handler：处理器

  - 即开发中的具体业务控制器
  - DispatcherServlet将用户请求转发到Handler，由Handler对请求进行具体的处理

- HandlerAdapter：处理器适配器

  - 适配器模式的应用
  - 通过扩展适配器可以处理更多类型的处理器

- ViewResolver：视图解析器

  - 负责将处理结果生成View视图
  - ViewResolver首先根据逻辑视图名解析成物理视图名（即具体的网页地址），再生成View视图对象，最后对View进行渲染，并将处理结果通过页面展示给用户

- View：视图

  - SpringMVC框架提供了很多的View视图类型，包括：jstlView、freemarkerView、pdfView等
  - 一般情况下，需要通过页面标签或页面模板技术奖模型数据通过页面展示给用户

## 请求参数绑定

- 讨论如何获取页面传递来的数据
- 数据封装异常会报400

### 绑定普通类型

- controller中的处理方法的参数列表与请求URL携带的参数名完全一致时，自动绑定

  - 若未携带参数列表指定的参数（或与参数列表形参名不一致），则形参为null

  - 成功绑定

    ```
    href="param/testBindingParam?username=hehe&password=123456"
    
    @RequestMapping("testBindingParam")
    public String testBindingParam(String username, String password)
    ```

  - 参数绑定异常

    ```
    href="param/testBindingParam?username=hehe" <!-- password=null -->
    href="param/testBindingParam?user=hehe" <!-- username=null, password=null -->
    ```

### 绑定JavaBean

- 表单中input框中的name与JavaBean的属性名一一对应，即可自动绑定
- 处理方法的参数列表直接接受一个JavaBean对象
- **复合属性**：如果该对象中有另一个JavaBean作为属性（比如在Account中有一个User user），则在input框的name命名为：user.属性名
- **集合属性**：对象中有集合，如List、Map，前端书写格式：list[0].name、map['key'].name

### 自定义类型转换

- 因为在Spring MVC中，请求参数的类型转换都由框架帮我们完成了，但是如果遇到框架不支持的输入格式怎么办？

  - 比如日期类型，SpringMVC框架不支持yyyy-MM-dd类型的输入，此时就需要自定义类型转换

- 在Spring MVC框架中，已经实现了非常多的**类型转换器**，所有的类型转换器都需要实现Converter<S,T>接口，我们自定义类型转换器也不例外

  ```java
  public class StringToDate implements Converter<String,Date> {
  
      @Override
      public Date convert(String source) {
          DateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
          Date date = null;
          try {
              date = dateFormat.parse(source);
          } catch (ParseException e) {
              e.printStackTrace();
          }
          return date;
      }
  }
  ```

- 完成自定义类型转换器实现类之后，我们需要将该转换器注册到SpringMVC框架中去

  ```xml
  <bean id="conversionService" class="org.springframework.context.support.ConversionServiceFactoryBean">
      <property name="converters">
          <set>
          	<bean class="com.easondongh.Util.StringToDate"></bean>
          </set>
      </property>
  </bean>
  
  <!-- conversion-service：注册自定义类型转换器 -->
  <mvc:annotation-driven conversion-service="conversionService"></mvc:annotation-driven>
  ```

## Controller获取原生Servlet API

- 只需要在方法参数中写想要获取的对象即可

  ```java
  @RequestMapping("testGetServletAPI")
  public String testGetServletAPI(HttpServletRequest request, HttpServletResponse response){...}
  ```



## RESTful

- REST(Representational State Transfer)
- REST相比于SOAP、XML-RPC更加简单明了，对URL处理或是对Payload编码，REST更倾向于用更加简单轻量的方法设计和实现
- REST没有明确的标准，而是一种设计风格

### 优点

- 结构清晰、符合标准、易于理解、方便扩展

### 特点

- HTTP协议中有四个表示操作方式的动词：GET、POST、PUT、DELETE，分别对应四种基本操作：
  - GET用户获取资源
  - POST用来新建资源
  - PUT用来更新资源
  - DELETE用来删除资源
- 在RESTful风格中，利用这四种操作方式来区分
  - /account/1  HTTP GET：获取id=1的account
  - /account/1  HTTP POST：新增id=1的account
  - /account/1  HTTP PUT：更新id=1的account
  - /account/1  HTTP DELETE：删除id=1的account



## 常用注解

### @RequestMapping

- @Target({ElementType.METHOD, ElementType.TYPE})
  - 可以修饰方法或类
  - 如果修饰类，则表明给该类的所有方法都加一级URL请求路径
- 属性
  - value、path：互相等价
  - method：不符合则405
    - GET, HEAD, POST, PUT, PATCH, DELETE, OPTIONS, TRACE
  - params：不符合则400
    - params={"username"}：请求的URL必须包含username属性
    - params={"username=haha"}：请求的URL必须包含username属性，且值为haha
    - params={"username!haha"}：请求的URL必须包含username属性，且值**不为**haha

### @RequestParam

- 用于修饰形参，将URL携带的参数名称与形参名称对应起来

  ```java
  public String testRequestParam(@RequestParam("username") String name){...}
  ```

  - 此时URL携带的参数**必须**命名为username才行

### @RequestBody

- 用于修饰形参，然后获取请求体（Get没有请求体，所以不适用）

  ```java
  public String testRequestBody(@RequestBody String body){...}
  ```

  - 返回示例：name=%E8%91%A3%E6%B5%A9&password=abc123456

### @PathVariable

- 用于实现RESTful的编码风格

  - RESTful中，参数以占位符的形式传入，而用@PathVariable来标识形参，从而使得传入的数据得以封装进形参

  - RESTful中根据URL辨识具体处理方法的逻辑：

    - 先根据RequestMapping的path属性
    - 再根据RequestMapping的method属性
    - 最后根据占位符匹配

  - 示例

    ```java
    @RequestMapping("testPathVariable/{uid}")
    public String testPathVariable(@PathVariable(name = "uid")String id){...}
    ```

    - 此时path中的占位符必须与@PathVariable的name属性命名相同，与形参无关

### @RequestHeader

- 用于获取请求头的值

  ```java
  public String testGetRequestHeader(@RequestHeader(value="Accept")String header){...}
  ```

  - @RequestHeader中的value指定要获取的请求头名

### @CookieValue

- 用于把指定cookie名称的值传入控制器方法的参数

  ```java
  public String testCookieValue(@CookieValue(value="JSESSIONID")String id){...}
  ```

### @ModelAttribute

- 修饰方法
  - 被@ModelAttribute修饰的方法会在其他普通控制器方法前执行
  - 该方法会获取到传入的值，此时可以在这里对传入值进行修改，再传给相应的控制器方法
  - 修改后的值有两个方式传入其他控制器方法：
    - 直接作为返回值
    - 在@ModelAttribute修饰的方法上加一个Map形参，将传入值修改完成后存入map中
- 修饰形参
  - 当被修改后的值存在map形参中时，通过@ModelAttribute("键值")来修饰控制器方法形参，以使其获取值

### @SessionAttribute

- 用于多次执行控制器方法见的参数共享

- 只能用于修饰类，并需要提供session域中值的key

  ```java
  @Controller
  @RequestMapping("/springmvc") 
  @SessionAttributes(value ={"username","password"},types={Integer.class})
  public class SessionAttributeController {
      /** 
       * 把数据存入SessionAttribute 
       * @param model 
       * @return 
       * Model是spring提供的一个接口，该接口有一个实现类ExtendedModelMap 
       * 该类继承了ModelMap，而ModelMap就是LinkedHashMap子类 
      */ 
      @RequestMapping("/testPut") 
      public String testPut(Model model){ 
          model.addAttribute("username", "泰斯特"); 
          model.addAttribute("password","123456"); 
          model.addAttribute("age", 31); //跳转之前将数据保存到username、password和age中，因为注解@SessionAttribute中有这几个参数 return "success"; 
      } 
  
      @RequestMapping("/testGet") 
      public String testGet(ModelMap model){
          String msg = model.get("username")+";"+model.get("password")+";"+model.get("age")
     	    System.out.println(msg); 			
          return "success"; 
      } 
  
      @RequestMapping("/testClean") 
      public String complete(SessionStatus sessionStatus){ 
      	sessionStatus.setComplete(); 
          return "success"; 
      } 
  }
  ```

## 响应类型

- 以上控制器方法都是返回的String类型，然后通过springmvc.xml中配置的视图解析器，来自动得到响应页面
- 除此之外，SpringMVC的响应类型还可以是void、ModelAndView

### 响应类型：String

- 见上面的案例

  - 同时，我们为了可以将数据存到session域或request域中，需要使用Model或ModelMap类型的形参

- 另一种方式是使用Spring框架中的转发、重定向方式对页面进行响应

  ```java
  return "forward:/WEB-INF/pages/success.jsp"; // 转发
  return "redirect:index.jsp"; // 框架自动补全项目路径
  ```

### 响应类型：void

- 当响应类型为void时，则表示对浏览器的响应页面需要我们手动处理，**视图解析器不再参与**

- 为了响应页面，我们可以使用Servlet的原生API

  ```java
  public String testGetServletAPI(HttpServletRequest request, HttpServletResponse response)
  ```

  - 当我们再次有了request、response对象后，一切就与之前写普通的Servlet一致了，可以对页面进行转发、重定向或直接响应（response.getWriter()）
  - 知识点：**重定向算两次请求，所以不能访问WEB-INF**

### 响应类型：ModelAndView

- ModelAndView是Spring特有的对象，可以用来封装域值、跳转视图名

  ```java
  @RequestMapping("testReturnModelAndView")
  public ModelAndView testReturnModelAndView(){
      ModelAndView modelAndView = new ModelAndView();
  
      // 模拟从数据库查数据
      User user = new User();
      user.setName("米ing吧");
      user.setPassword("abc12345");
  
      modelAndView.addObject("user", user);
      modelAndView.setViewName("success");
  
      return modelAndView;
  }
  ```

### 响应类型：JSON

- 知识点：需要在springmvc.xml中配置前端控制器（DispatcherServlet）不对静态资源进行过滤，静态资源比如：jquery、css、图片等资源

  ```xml
  <!--前端控制器，哪些静态资源不拦截-->
  <mvc:resources location="/css/" mapping="/css/**"/>
  <mvc:resources location="/images/" mapping="/images/**"/>
  <mvc:resources location="/js/" mapping="/js/**"/>
  ```

- 前端准备：发送ajax请求

  ```javascript
  <script>
      $(function () {
          $("#btn").click(function () {
              // alert("ajax");
              $.ajax({
                  url:"user/testReturnJSON",
                  data:'{"name":"张赛","password":"123456"}',
                  contentType:"application/json", // 发送给服务器的数据类型
                  dataType:"json", // 预期接受到的数据类型
                  type:"post",
                  success:function () {
  
                  }
              });
          });
      });
  </script>
  ```

- 后台准备

  - 导入jackson坐标，供Spring框架解析json格式数据

    ```
    <dependency>
        <groupId>com.fasterxml.jackson.core</groupId>
        <artifactId>jackson-databind</artifactId>
        <version>2.0.5</version>
    </dependency>
    <dependency>
        <groupId>com.fasterxml.jackson.core</groupId>
        <artifactId>jackson-core</artifactId>
        <version>2.0.5</version>
    </dependency>
    <dependency>
        <groupId>com.fasterxml.jackson.core</groupId>
        <artifactId>jackson-annotations</artifactId>
        <version>2.0.5</version>
    </dependency>
    ```

  - @ResponseBody注解的使用

    ```java
    @RequestMapping("testReturnJSON")
    public @ResponseBody User testReturnJSON(@RequestBody User user){
        user.setName("已修改的JSON对象");
        return user;
    }
    ```

## 案例：文件上传

- 实现文件上传

### 传统Web实现

- 前端准备

  - 设置form表单的enctype="multipart/form-data"
  - 提供一个文件域，注意设置name属性：<input type="file" name="uploadfile">

- 后端准备

  - 依赖使用第三方jar包来解析上传文件，依赖坐标

    ```xml
    <dependency>
        <groupId>commons-fileupload</groupId>
        <artifactId>commons-fileupload</artifactId>
        <version>1.3.1</version>
    </dependency>
    <dependency>
        <groupId>commons-io</groupId>
        <artifactId>commons-io</artifactId>
        <version>2.4</version>
    </dependency>
    ```

  - Controller方法

    ```java
    @Controller
    @RequestMapping("file")
    public class FileUploadController {
        @RequestMapping("uploadFile")
        public String uploadFile(HttpServletRequest request) throws Exception {
            // 获取上传文件存放路径
            // 注意获取的path，可能是目录下target的文件夹，也可能是在tomcat部署环境下
            String path = request.getSession().getServletContext().getRealPath("/uploads/");
            File file = new File(path);
            if (!file.exists()) {
                file.mkdirs();
            }
            // 解析request
            DiskFileItemFactory factory = new DiskFileItemFactory();
            ServletFileUpload upload = new ServletFileUpload(factory);
            List<FileItem> items = upload.parseRequest(request);
            for (FileItem item : items) {
                if (!item.isFormField()) {// 是上传文件
                    String prefix = UUID.randomUUID().toString().replace("-", "");
                    String name = prefix + "_" + item.getName();
                    item.write(new File(path, name));
                    item.delete();
                }
            }
    
            request.getSession().setAttribute("msg", "上传成功");
            return "success";
        }
    }
    ```

### 基于Spring MVC框架

- Spring MVC框架通过配置文件解析器的方式，简化了服务器端解析request文件对象的过程

- 需要注意的时候，文件解析器解析之后封装到MultipartFile对象中，该对象的参数名**必须**与前端的选择文件对象同名

- 原理分析

  ![](https://note.youdao.com/yws/public/resource/48d56fd49a97c59bb18680cdc52cd835/xmlnote/48A1EBE5E91F433F9BF78BD57BBC53D1/17569)

- 在springmvc.xml中配置文件解析器

  ```xml
  <!--配置文件解析器对象-->
  <bean id="multipartResolver" class="org.springframework.web.multipart.commons.CommonsMultipartResolver">
  	<property name="maxUploadSize" value="10485760" /> <!-- 10*1024*1024 -->
  </bean>
  ```

- Controller

  ```java
  // uploadFile必须与前端type="file"的对象同名
  @RequestMapping("uploadFile2")
  public String uploadFile2(HttpServletRequest request, MultipartFile uploadFile) throws Exception {
      // 获取上传文件存放路径
      String path = request.getSession().getServletContext().getRealPath("/uploads/");
      File file = new File(path);
      if (!file.exists()) {
      file.mkdirs();
      }
  
      String prefix = UUID.randomUUID().toString().replace("-", "");
      String name = prefix + "_" + uploadFile.getOriginalFilename();
      uploadFile.transferTo(new File(path, name));
  
      request.getSession().setAttribute("msg", "基于SpringMVC框架：上传成功");
      return "success";
  }
  ```

### 跨服务器文件上传

- 实际开发中，服务器分很多个：

  - 应用服务器：负责部署应用
  - 数据库服务器：运行数据库
  - 缓存和消息服务器：负责处理大并发访问的缓存和消息
  - 文件服务器：负责存储用户上传的资料

- 基于以上案例，实现跨服务器的文件上传

  - 开启两个tomcat来模拟两个服务器

  - 应用服务器：

    - 使用第三方jar包来支持跨服务器文件上传，依赖坐标：

      ```xml
      <dependency>
          <groupId>com.sun.jersey</groupId>
          <artifactId>jersey-core</artifactId>
          <version>1.18.1</version>
      </dependency>
      <dependency>
          <groupId>com.sun.jersey</groupId>
          <artifactId>jersey-client</artifactId>
          <version>1.18.1</version>
      </dependency>
      ```

    - Controller

      ```java
      @RequestMapping("uploadFile3")
      public String uploadFile3(HttpServletRequest request, MultipartFile uploadFile) throws Exception {
          // 获取上传文件存放路径
          String path = "http://localhost:9090/uploads/";
      
          String prefix = UUID.randomUUID().toString().replace("-", "");
          String name = prefix + "_" + uploadFile.getOriginalFilename();
      
          // 与文件服务器建立连接
          Client client = Client.create();
          WebResource webResource = client.resource(path + name);
          webResource.put(uploadFile.getBytes());
      
          request.getSession().setAttribute("msg", "基于SpringMVC框架：上传成功");
          return "success";
      }
      ```

    - 上面用的http://localhost:9090就是另一个服务器，这个服务器很普通，能基本运行，并且在运行路径下提供一个uploads文件夹即可

  - 403：

    - 实现该功能时在调用 webResource.put执行上传时出现403，是因为Tomcat默认禁止上传，解决方法为

      - 到Tomcat配置文件中：conf/web.xml，找到<servlet>节点

      - 添加或修改节点readonly为false即可

        ```xml
        <init-param>
            <param-name>readonly</param-name>
            <param-value>false</param-value>
        </init-param>
        ```

        

    





