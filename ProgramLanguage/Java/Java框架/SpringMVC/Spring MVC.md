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

## 相关注解

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

  

