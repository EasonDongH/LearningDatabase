# Spring

## 概述

### 什么是Spring

- [官网](https://spring.io/)
- Spring是分层的Java SE/EE应用的full-stack轻量级开源框架
- 以IOC(Inverse Of Control，控制反转)和AOP(Aspect Oriented Programming，面向切面编程)为内核，提供了展现层Spring MVC和持久层Spring JDBC，一级业务层事务管理等众多的企业级应用技术
- Spring还能整合开源世界众多著名的第三方框架和类库，已成为使用最多的Java EE企业应用开源框架

### Spring优势

- 方便解耦，简化开发
  - 通过Spring提供的IoC容器，可以将对象间的依赖关系交由Spring进行控制，避免硬编码所造成的过度程序耦合。用户也不必再为单例模式类、属性文件解析等这些很底层的需求编写代码，可以更专注于上层的应用。
- AOP编程的支持
  - 通过Spring的AOP功能，方便进行面向切面的编程，许多不容易用传统OOP实现的功能可以通过AOP轻松应付。
- 声明式事务的支持
  - 可以将我们从单调烦闷的事务管理代码中解脱出来，通过声明式方式灵活的进行事务的管理，提高开发效率和质量。
- 方便程序的测试
  - 可以用非容器依赖的编程方式进行几乎所有的测试工作，测试不再是昂贵的操作，而是随手可做的事情。
- 方便集成各种优秀框架
  - Spring可以降低各种框架的使用难度，提供了对各种优秀框架（Struts、Hibernate、Hessian、Quartz等）的直接支持。
- 降低JavaEE API的使用难度
  - Spring对JavaEE API（如JDBC、JavaMail、远程调用等）进行了薄薄的封装层，使这些API的使用难度大为降低。
- Java源码时经典学习的范例
  - Spring的源代码设计精妙、结构清晰、匠心独用，处处体现着大师对Java设计模式灵活运用以及对Java技术的高深造诣。它的源代码无意是Java技术的最佳实践的范例。

## IOC-解耦

### 什么是耦合

- 耦合性（Coupling），也称耦合度，是对模块间关联程度的度量
- 耦合的强弱取决于模块间接口的复杂性、调用模块的方式一级通过界面传送数据的多少
- 模块间的耦合度是指模块之间的依赖关系，包括控制关系、调用关系、数据传递关系
- 模块间联系越多，其耦合性越强，表明其独立性越差
  - 降低耦合性，可提供其独立性
- 在软件工程中，耦合指的是对象之间的依赖性
  - 对象之间的耦合越高，维护成本越高，因此对象的设计应使类和构件之间的耦合最小
  - 软件设计中通常使用耦合度和内聚度作为衡量模块独立程序的标准
- 耦合分类
  - 内容耦合：一个模块之间修改或操作另一个模块的数据。这是最高程度的耦合，应尽量避免
  - 公共耦合：两个及以上模块共同引用一个全局数据项。这种情况难以确定哪个模块对全局变量进行了赋值或修改
  - 外部耦合：一组模块都访问同一全局变量而不是同一全局数据结构
  - 控制耦合：一个模块向另一个模块出阿迪控制信号
  - 标记耦合：若模块A通过接口向模块B、C传递一个公共参数，那么称B、C间存在标记耦合
  - 数据耦合：模块之间通过参数来传递数据
  - 非直接耦合：两个模块之间没有直接关系，它们之间的联系完全是通过主模块的控制和调用来实现的

### 工厂模式解耦

- 我们可以将实际开发中的三层对象使用配置文件配置起来：**键为对象名，值为完全路径名**
- 当启动服务器时，由**工厂类读取配置文件**，通过**反射产出实体对象**
- 三层的**任一层都不要直接new对象**，而是通过**传递对象名给工厂方法**，来获取对象

### Spring IOC解耦

#### 概念

- IOC(Inversion Of Control)，控制反转，把创建对象的权力交给框架，是面向对象编程中的一种设计原则，用来降低代码之间的耦合度
- 常见的方式有**依赖注入**（Dependency Injection, DI）和**依赖查找**（Dependncy Lookup）
- 通过控制反转，对象在被创建的时候，由一个调控系统内所有对象的外界实体，将其所依赖的对象的引用传递（注入）给它
- 默认**单例**、**立即加载**

#### 快速实现

- pom.xml

  ```xml
  <dependencies>
      <dependency>
          <groupId>org.springframework</groupId>
          <artifactId>spring-context</artifactId>
          <version>5.0.2.RELEASE</version>
      </dependency>
  </dependencies>
  ```

- 依次建立：dao.impl.AccountDaoImpl、service.impl.AccountServiceImpl

- 新建bean.xml

  ```xml
  <?xml version="1.0" encoding="UTF-8"?>
  <beans xmlns="http://www.springframework.org/schema/beans"
         xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
         xsi:schemaLocation="http://www.springframework.org/schema/beans http://www.springframework.org/schema/beans/spring-beans.xsd">
  
      <bean id="accountDao" class="dao.impl.AccountDaoImpl"></bean>
      <bean id="accountService" class="service.impl.AccountServiceImpl"></bean>
  </beans>
  ```

- 调用

  ```java
  ApplicationContext applicationContext = new ClassPathXmlApplicationContext("bean.xml");
  AccountDao accountDao = (AccountDao)applicationContext.getBean("accountDao");
  AccountService accountService = applicationContext.getBean("accountService", AccountService.class);
  accountDao.saveAccount(100.0);
  accountService.saveAccount(199.9);
  ```

#### 创建Bean的三种方式

1. 使用默认构造函数创建；如果类中没有默认构造函数，则对象无法创建

   ```xml
   <bean id="accountService" class="service.impl.AccountServiceImpl"></bean>
   
   ```

2.  使用某个类（实例工厂）中的方法创建对象，并存入Spring容器

   ```xml
   <bean id="instanceFactory" class="factory.InstanceFactory"></bean>
   <bean id="accountService" factory-bean="instanceFactory" factory-method="getAccountService"></bean>
   ```

3.  使用静态工厂的静态方法创建对象，并存入Spring容器

   ```xml
   <bean id="accountService" class="factory.StaticFactory" factory-method="getAccountService"></bean>
   
   ```

#### Bean对象的作用范围

- bean标签的scope属性，就是用于指定bean的作用范围
  - singleton：单例（默认）
  - prototype：多例
  - request：作用于web应用的请求范围
  - session：作用于web应用的会话范围
  - global-session：作用于集群环境的会话范围

#### Bean对象的生命周期

- 单例对象
  - 容器创建，对象创建；容器销毁（关闭），对象销毁
- 多例对象
  - 使用时创建；由GC决定销毁时机
- Bean标签中相关的两个属性：init-method、destroy-method

### Spring的依赖注入

- 如果Bean对象在创建时需要由外部传递数据，进行内部初始化时，就需要使用依赖注入（Dependency Injection，DI）
- 能注入的数据有三类：
  - 基本类型和String
  - 其他Bean类型（在配置文件或注解配置过的bean）
  - 复杂类型（集合类型）
- 注入方式有三种：
  - 构造函数注入
  - set方法注入
  - 注解注入

#### 1. 构造函数注入

- 当Bean对象无默认构造函数时，由注入传递构造函数参数

- 此时假设要注入的Bean对象的构造函数如下：

  ```java
  public AccountServiceImpl(String name,Integer age,Date birthday){...}
  ```

- **constructor-arg**标签属性

  - type：指定要注入的数据类型
  - index：指定注入数据所在索引，从0开始
  - name：指定注入数据所对应的参数名
  - value：提供**基本类型和String类型**的数据
  - ref：指定其他bean类型数据

- 配置文件中配置该bean对象，注意Date类型的注入方式

  ```xml
  <bean id="accountService" class="service.impl.AccountServiceImpl">
      <constructor-arg name="name" value="泰斯特"></constructor-arg>
      <constructor-arg name="age" value="18"></constructor-arg>
      <constructor-arg name="birthday" ref="now"></constructor-arg>
  </bean>
  <bean id="now" class="java.util.Date"></bean>
  ```

- 构造函数注入的优势

  - 强制必须注入数据

- 构造函数注入的弊端

  - 改变bean对象的实例化方式

#### 2. set方法注入

- 须由Bean对象提供相应的set方法

- 使用property标签，涉及属性

  - name：set方法名称
  - value：提供基本类型和String类型的数据
  - ref：指定其他bean类型数据

- 配置文件

  ```xml
  <bean id="accountService2" class="service.impl.AccountServiceImpl2">
      <property name="name" value="TEST" ></property>
      <property name="age" value="21"></property>
      <property name="birthday" ref="now"></property>
  </bean>
  ```


#### 复杂类型注入

```xml
<bean id="accountService3" class="service.impl.AccountServiceImpl3">
    <property name="myList"> 
        <set>
        	<value>AAA</value>
        </set>
    </property>
    <property name="myStrs">
        <array>
        	<value>AAA</value>
        </array>
    </property>
    <property name="myList">
        <list>
            <value>AAA</value>
        </list>
    </property>
    <property name="myMap">
        <props>
        	<prop key="testC">ccc</prop>
        </props>
    </property>
    <property name="myProps">
        <map>
            <entry key="testA" value="aaa"></entry>
            <entry key="testB">
            	<value>BBB</value>
            </entry>
        </map>
    </property>
</bean>
```

#### 3. 注解注入

##### 快速实现

- bean.xml

  ```xml
  <?xml version="1.0" encoding="UTF-8"?>
  <beans xmlns="http://www.springframework.org/schema/beans"
         xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
         xmlns:context="http://www.springframework.org/schema/context"
         xsi:schemaLocation="http://www.springframework.org/schema/beans
          http://www.springframework.org/schema/beans/spring-beans.xsd
          http://www.springframework.org/schema/context
          http://www.springframework.org/schema/context/spring-context.xsd">
  
      <!--告知spring在创建容器时要扫描的包，配置所需要的标签不是在beans的约束中，而是一个名称为
      context名称空间和约束中-->
      <context:component-scan base-package="com.easondongh"></context:component-scan>
  </beans>
  ```

- bean对象的类

  ```java
  @Component("accountService")/* 不写则默认为类名且首字母小写 */
  public class AccountServiceImpl implements IAccountService {...}
  ```

- 调用
  
  - 与xml配置相同，注意getBean时传递的类名与Component注解配置相同即可

##### 更多注解

- Spring专为三层框架提供的注解
  - @Controller：一般用在表现层
  - @Service：一般用在业务层
  - @Repository：一般用在持久层
- 用于注入数据的注解
  - @Autowired：自动按照类型注入。只要容器中有**唯一一个**bean对象类型和要注入的变量类型匹配，就可以进行自动注入
    - 可以写在变量上或方法上
    - 如果**没有任何匹配**，则运行时异常
    - 如果有多个匹配：@Autowired先按类型进行匹配，匹配多个时再以变量名（或方法参数名）与bean对象的注解id进行二次匹配（此时保证至多一个），如果匹配不到继续报异常
  - @Qualifier：在按照类型注入的基础上再按照名称注入。不能单独给类成员使用
    - 其value值即指定要注入的bean对象的id
  - @Resource：直接按照bean的id注入，注意其需使用name属性
  - **以上三种注解都不能注入基本类型和String类型**
  - @Value：用于注入基本类型和String类型；可以使用Spring中的EL表达式（SpEL）
- 用于改变作用范围的注解
  - @Scope：默认单例
- 与生命周期相关的注解
  - @PreConstruct：初始化方法
  - @PreDestory：销毁方法

#### 注解IOC导入第三方包

- @Configuration：标注该类为配置类；Spring扫描包时仅扫描配置类，以及创建ApplicationContext传入的类

- @ComponentScan(backPackages = {"类路径"})：通过该注解指定Spring再创建容器时要扫描的包；使用此注解就等同于xml配置

- @Bean：用于把当前方法的返回值当作bean对象存入IOC容器中

  - 属性name：指定bean的id，默认值是当前方法的名称
  - 如果注解标注的方法有形参，则Spring自动到容器中寻找匹配对象

- 改造前，需要有bean.xml

  ```xml
  <?xml version="1.0" encoding="UTF-8"?>
  <beans xmlns="http://www.springframework.org/schema/beans"
         xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
         xmlns:context="http://www.springframework.org/schema/context"
         xsi:schemaLocation="http://www.springframework.org/schema/beans
          http://www.springframework.org/schema/beans/spring-beans.xsd
          http://www.springframework.org/schema/context
          http://www.springframework.org/schema/context/spring-context.xsd">
  
      <context:component-scan base-package="com.easondongh"></context:component-scan>
      <bean id="dataSource" class="com.mchange.v2.c3p0.ComboPooledDataSource">
          <property name="driverClass" value="com.mysql.jdbc.Driver"></property>
          <property name="jdbcUrl" value="jdbc:mysql://localhost:3306/dbtest"></property>
          <property name="user" value="root1"></property>
          <property name="password" value="root"></property>
      </bean>
  
      <bean id="runner" class="org.apache.commons.dbutils.QueryRunner">
          <constructor-arg name="ds" ref="dataSource"></constructor-arg>
      </bean>
  </beans>
  ```

- 改造

  - 新建SpringConfiguration.java

    ```java
    package com.easondongh.config;
    
    import com.mchange.v2.c3p0.ComboPooledDataSource;
    import org.apache.commons.dbutils.QueryRunner;
    import org.springframework.context.annotation.Bean;
    import org.springframework.context.annotation.ComponentScan;
    import org.springframework.context.annotation.Configuration;
    import org.springframework.context.annotation.Scope;
    
    import javax.sql.DataSource;
    import java.beans.PropertyVetoException;
    
    @Configuration
    @ComponentScan(basePackages = "com.easondongh")
    public class SpringConfiguration {
    
        @Bean(name = "dataSource")
        public DataSource createDataSource() {
            ComboPooledDataSource dataSource = new ComboPooledDataSource();
            try {
                dataSource.setDriverClass("com.mysql.jdbc.Driver");
            } catch (PropertyVetoException e) {
                e.printStackTrace();
            }
            dataSource.setJdbcUrl("jdbc:mysql://localhost:3306/dbtest");
            dataSource.setUser("root1");
            dataSource.setPassword("root");
            return dataSource;
        }
    
        @Bean(name = "runner")
        @Scope("prototype")
        public QueryRunner createQueryRunner(DataSource dataSource) {
            return new QueryRunner(dataSource);
        }
    }
    ```

- 创建对象时，需要使用注解子类

  ```java
  ApplicationContext ac = new AnnotationConfigApplicationContext(SpringConfiguration.class);
  ```

- @Import：用于在主配置类导入其他配置类

- @Value：获取配置文件的值，如数据库连接参数

  - 需要@PropertySource("**classpath:**配置文件路径")支持，放在主配置类上
  - @Value(键名)放置在需要赋值的字段或属性上

## AOP-增强

### 概念

- Aspect Oriented Programming，即**面向切面编程**
- 通过**预编译方式**和**运行期动态代理**实现程序功能的统一维护
- AOP是**OOP的延续**，也是**函数式编**程的一种衍生范型

### 优点

- 利用AOP可以对业务逻辑的各个部分进行隔离，从而使得业务逻辑各部分之间的耦合度降低，提供程序的重用性，同时提高开发效率
- 简单地说，就是把重复代码抽取，**在需要执行的时候使用动态代理技术，在不修改源码的基础上，对已有方法进行增强**

### 相关术语

- Joinpoint（连接点）
  - 指那些被拦截到的点，连接的是原始对象与被代理对象。在spring中这些点指的是方法（spring只支持方法类型的连接点）
  - 举例：如果某个类被动态代理了，那么所有类中的方法就是连接点
- Pointcut（切入点）
  - 即要对哪些连接点进行增强
  - 所有切入点都是连接点；没有被增强的连接点不是切入点
- Advice（通知/增强）
  - 即拦截到Joinpoint之后要做的事
  - 通知又分为：前置通知（在原始方法执行前的操作）、后置通知（在原始方法正常执行后的操作）、异常通知（原始方法发生异常时的操作）、最终通知（无论原始方法有无异常都要的操作）、环绕通知（整个invoke方法）
- Introduction（引介）
  - 引介是一种特殊的通知
  - 在不修改类代码的前提下，在运行期给类动态地增加一些方法或Field
- Target（目标对象）
  - 代理的目标对象
- Weaving（织入）
  - 指把增强应用到目标对象来创建新的代理对象的过程
- Proxy（代理）
  - 一个类被AOP织入增强后，就产生一个结果代理类
- Aspect（切面）
  - 即切入点与通知（引介）的结合

### 快速实现

- 导入依赖

  ```xml
  <dependency>
      <groupId>org.springframework</groupId>
      <artifactId>spring-context</artifactId>
      <version>5.0.2.RELEASE</version>
  </dependency>
  <dependency>
      <groupId>org.aspectj</groupId>
      <artifactId>aspectjweaver</artifactId>
      <version>1.8.7</version>
  </dependency>
  ```

- 新建接口：AccountService，其包含方法：

  ```java
   void save();
   boolean transfer(String source,String target, double money);
  ```

- 实现接口：AccountServiceImpl，包路径为：com.eansondongh.service.impl.AccountServiceImpl

- 新建方法Logger，来给AccountService中的指定方法都进行增强，提供以下方法

  ```java
  public void printBeforeLog(){
  	System.out.println("printBeforeLog：执行");
  }
  public void printAfterReturningLog(){
  	System.out.println("printAfterReturningLog：执行");
  }
  public void printAfterThrowingLog(){
  	System.out.println("printAfterThrowingLog：执行");
  }
  public void printAfterLog(){
  	System.out.println("printAfterLog：执行");
  }
  ```

- 配置AOP的bean.xml

  ```xml
  <?xml version="1.0" encoding="UTF-8"?>
  <beans xmlns="http://www.springframework.org/schema/beans"
         xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
         xmlns:aop="http://www.springframework.org/schema/aop"
         xsi:schemaLocation="http://www.springframework.org/schema/beans
          http://www.springframework.org/schema/beans/spring-beans.xsd
          http://www.springframework.org/schema/aop
          http://www.springframework.org/schema/aop/spring-aop.xsd">
  
      <bean id="accountService" class="com.easondongh.service.impl.AccountServiceImpl"></bean>
  
      <bean id="log" class="com.easondongh.log.Logger"></bean>
  
      <aop:config>
          <aop:aspect id="logAdvice" ref="log">
              <aop:before method="printBeforeLog" pointcut="execution(* com.easondongh.service.impl.*.*(..))"></aop:before>
              <aop:after-returning method="printAfterReturningLog" pointcut="execution(* com.easondongh.service.impl.*.*(..))"></aop:after-returning>
              <aop:after-throwing method="printAfterThrowingLog" pointcut="execution(* com.easondongh.service.impl.*.*(..))"></aop:after-throwing>
              <aop:after method="printAfterLog" pointcut="execution(* com.easondongh.service.impl.*.*(..))"></aop:after>
          </aop:aspect>
      </aop:config>
  </beans>
  ```

  - 配置说明

    - 先将AccountServiceImpl、Logger配置到IOC容器

    - 再进行AOP配置：aop:config标签

      - 配置切面：aop:aspect标签

        - 前置通知：aop:before标签

      - 切入点表达式：

        - 完全写法为：修饰符 返回值 全限定包名.类名.方法名(参数列表【只需要写类型】)

        - 通配符写法：

          - 修饰符可省略
          - 返回值：*通配
          - 全限定包名：每级包都需要一个*，两级之间.分隔；多级包可用\*..来通配，即：\* \*..类名.方法名(..)
          - 类名与方法名都可以用*通配
          - 参数列表：也可以用*通配，但*表示必须有一个而不论什么类型；用..则表示可有可无，且不论类型

        - 切入点表达式优化：通过id的方式统一配置pointcut表达式

          ```xml
          <aop:pointcut id="pc1" expression="execution(* com.easondongh.service.impl.*.*(..))"></aop:pointcut>
          <aop:before method="printBeforeLog" pointcut-ref="pc1"></aop:before>
          ```

    - 环绕通知

      - Spring中的环绕通知就是通过代码的方式来配置其他的四种通知

        ```xml
        <aop:around method="printArroundLog" pointcut-ref="pc1"></aop:around>
        ```

      - Logger.printArroundLog

        ```java
        public Object printArroundLog(ProceedingJoinPoint pdjp){
            Object result = null;
            try {
                System.out.println("printArroundLog：前置");
                result = pdjp.proceed(pdjp.getArgs());
                System.out.println("printArroundLog：后置");
            } catch (Throwable t) {
            	System.out.println("printArroundLog：异常");
            }
            System.out.println("printArroundLog：最终");
            return result;
        }
        ```

### 注解实现AOP

- 改写bean.xml

  ```xml
  <?xml version="1.0" encoding="UTF-8"?>
  <beans xmlns="http://www.springframework.org/schema/beans"
         xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
         xmlns:aop="http://www.springframework.org/schema/aop"
         xmlns:context="http://www.springframework.org/schema/context"
         xsi:schemaLocation="http://www.springframework.org/schema/beans
          http://www.springframework.org/schema/beans/spring-beans.xsd
          http://www.springframework.org/schema/aop
          http://www.springframework.org/schema/aop/spring-aop.xsd
          http://www.springframework.org/schema/context
          http://www.springframework.org/schema/context/spring-context.xsd">
  
      <!-- 扫描包 -->
      <context:component-scan base-package="com.easondongh"></context:component-scan>
      <!-- 开启注解AOP -->
      <aop:aspectj-autoproxy></aop:aspectj-autoproxy>
  </beans>
  ```

  

- 改写AccountServiceImpl

  - 在类上添加：@Service("accountService")

- 改写Logger类

  ```java
  @Component("log")
  @Aspect
  public class Logger {
  
      @Pointcut("execution(* com.easondongh.service.impl.*.*(..))")
      private void pc1(){}
  
      @Before("pc1()")
      public void printBeforeLog(){
          System.out.println("printBeforeLog：执行");
      }
  
  //    @Around("pc1()")
  //    public Object printAroundLog(ProceedingJoinPoint pdjp){
  //        Object result = null;
  //        try {
  //            System.out.println("printAroundLog：前置");
  //            result = pdjp.proceed(pdjp.getArgs());
  //            System.out.println("printAroundLog：后置");
  //        } catch (Throwable t) {
  //            System.out.println("printAroundLog：异常");
  //        }
  //        System.out.println("printAroundLog：最终");
  //        return result;
  //    }
  }
  ```

  - **注意：注解配置的最终通知调用出现在后置或异常通知之前**

