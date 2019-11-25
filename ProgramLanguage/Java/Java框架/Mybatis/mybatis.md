# mybatis

## 概念

- 原为apache的开源项目：iBatis，后迁移到google code并改名为：MyBatis。2013年11月迁移到Github。
- mybatis是一个基于Java的持久层框架，包括SQL Maps和Data Access Objects。
  - 作为持久层框架，还有一个封装程度更高的框架：Hibernate，但目前该框架在国内不流行了。目前使用Spring Data来实现数据持久化是一种趋势。
- mybatis内部封装了jdbc，使开发者只需要关注sql语句本身，而不需要花费精力区处理加载驱动、创建连接、创建statement等繁杂的过程
  - 采用ORM思想来解决实体与数据库映射的问题
  - mybatis通过xml或注解的方式，将要执行的各种statement配置起来，并通过java对象和statement中的sql的动态参数进行映射，生成最终执行的sql语句。最后由mybatis框架执行sql并将结果映射为java对象返回

## 快速入门

### 在maven工程中使用mybatis

1. pom文件配置依赖项

   ```
   <packaging>jar</packaging>
   <dependencies>
       <dependency>
           <groupId>org.mybatis</groupId>
           <artifactId>mybatis</artifactId>
           <version>3.4.5</version>
       </dependency>
       <dependency>
           <groupId>mysql</groupId>
           <artifactId>mysql-connector-java</artifactId>
           <version>5.1.6</version>
       </dependency>
   </dependencies>
   ```

2. 在java包中创建domain与dao

   - 包路径为：domain.User、dao.UserDao

   - dao.UserDao

     ```
     List<User> listAll();
     ```

3. 在resources包中，**创建与UserDao同样的包路径**，不过文件类型为xml：resources.dao.UserDao.xml

   ```xml
   <?xml version="1.0" encoding="UTF-8"?>
   <!DOCTYPE mapper
           PUBLIC "-//mybatis.org//DTD Mapper 3.0//EN"
           "http://mybatis.org/dtd/mybatis-3-mapper.dtd">
   <mapper namespace="dao.UserDao">
       <select id="listAll" resultType="domain.User">
           SELECT * FROM USER
       </select>
   </mapper>
   ```

4. 在resources包下，配置数据库连接环境：resources.SqlMapperConfig.xml

   ```xml
   <?xml version="1.0" encoding="UTF-8"?>
   <!DOCTYPE configuration
           PUBLIC "-//mybatis.org//DTD Config 3.0//EN"
           "http://mybatis.org/dtd/mybatis-3-config.dtd">
   <!-- mybatis的主配置文件 -->
   <configuration>
       <!--配置环境，默认使用id=mysql的环境配置-->
       <environments default="mysql">
           <!--配置mysql环境-->
           <environment id="mysql">
               <!--配置事务类型-->
               <transactionManager type="JDBC"></transactionManager>
               <!--配置数据源-->
               <dataSource type="POOLED">
                   <property name="driver" value="com.mysql.jdbc.Driver" />
                   <property name="url" value="jdbc:mysql://localhost:3306/dbtest" />
                   <property name="username" value="root1" />
                   <property name="password" value="root" />
               </dataSource>
           </environment>
       </environments>
   
       <!--指定映射配置文件的位置，映射配置文件值得是每个dao文件的配置文件-->
       <mappers>
           <mapper resource="dao/UserDao.xml" />
       </mappers>
   </configuration>
   ```

### 使用注解进一步简化

- **必须删除**dao/UserDao.xml文件

- 在dao.UserDao中

  ```java
  public interface UserDao {
      @Select("select * from user ")
      List<User> listAll();
  }
  ```

  

- resources.SqlMapperConfig.xml中

  ```xml
  <mappers>
  	<mapper class="dao.UserDao"></mapper>
  </mappers>
  ```

### mybatis执行自己实现的dao实现类

```java
public class UserDaoImpl(){
	private SqlSessionFactory factory;
	public UserDaoImpl(SqlSessionFactory factory) {
		this.factory = factory;
	}
	public List<User> listAll(){
		SqlSession session = this.factory.openSession();
		List<User> users = session.selectList("dao.UserDao.listAll");
		session.close();
		return users;
	}
}
```

## 自定义mybatis

#### 查询数据集的执行流程分析

1. 根据配置文件（SqlMapperConfig.xml），创建Connection对象：conn

   - 注册驱动、获取连接

2. 根据映射文件（UserDao.xml），获取映射对象Mapper，其包含：

   - 执行的SQL语句
   - 封装结果的实体类完全限定名

3. 根据SQL语句（UserDao.xml），获取预处理对象：conn.preparedStatement(sql)

4. 执行查询：

   ```
   ResultSet resultSet = preparedStatement.executeQuery();
   ```

5. 遍历结果集用于封装：

   ```java
   List<E> list = new ArrayList();
   while(resultSet.next()) {
   	E element = (E)Class.forName(类的完全限定名).newInstance();
   	通过反射，将数据库列值存到类的属性中
   	list.add(element);
   }
   ```

6. 返回list

![](https://note.youdao.com/yws/public/resource/48d56fd49a97c59bb18680cdc52cd835/xmlnote/007F0DECA4B143CD9A5062E6B5A5DB6B/17510)

## POJO对象

- Plain Ordinary Java Objects，即普通的javabean对象
- 有时可作为Vo(Value object)或DTO(Data Transform Object)来使用
- 可以把POJO作为支持业务逻辑的协助类

### OGNL表达式

- Object Graphic Navigation Language，对象/图导航语言
- mybatis使用ognl表达式解析对象字段的值，#{}或${}括号中的值为pojo属性名称



## 数据库列名与JavaBean对象属性名不一致

1. 起别名

   ```sql
   select id as userId, name as username from user;
   ```

   - id为数据库列名，userId为属性名
   - **注意**：mysql在Windows不区分大小写，而在Linux严格区分大小写

2. 通过mybatis配置

   - 配置查询结果列名与实体类属性名的对应关系

     ```
     <resultMap id="userMap" type="domain.user">
     	<!-- 主键 -->
     	<id property="userId" column="id"></id>
     	<result property="userName" column="name"></result>
     </resultMap>
     
     <select id="..." resultMap="userMap">
     	...
     </select>
     ```

   - 注解实现

     ```
     @Select("select * from user ")
     @Results({
     	@Result(property = "userId", column = "id", id = true)
     })
     List<User> listAll();
     ```

## 分析查询数据集执行流程

### **SqlSession与注解的映射**

- SqlSession的实现类**DefaultSqlSession**提供<T> T **getMapper**(Class<T>)来产出dao实现类
- **DefaultSqlSession**的**getMapper**中调用**Configuration**对象的<T> T getMapper(Class<T> , SqlSession) 
- **Configuration**的getMapper调用**MapperRegistry**对象的<T> T getMapper(Class<T>, SqlSession)
- **MapperRegistry**对象创建**MapperProxyFactory**对象，根据传入的SqlSession，调用其T **newInstance**(SqlSession)

- **MapperProxyFactory**的**newInstance**方法创建**MapperProxy**代理对象，并最终调用Proxy.newProxyInstance创建最终代理，代理对象为**MapperProxy**
- 在**MapperProxy**代理中，实现了**InvocationHandler**接口
- 在**MapperProxy**的invoke方法中，根据传入的**Method**对象，从**Map<Method, MapperMethod> methodCache**中获取**MapperMethod**对象
  - 若**methodCache**不存在该**Method**对象，就从sqlSession.getConfiguration()加载并保存到**methodCache**
- 最终由**MapperMethod**执行Object execute(SqlSession, Object[]) 方法
- 在**MapperMethod**的execute中，根据**Method**所创建的**SqlCommand**对象，来getType()，然后根据结果来执行SqlSession的insert、update、select等方法

### **selectList执行流程**

- SqlSessionFactory.openSession()返回的是实现了**SqlSession**接口的**DefaultSqlSession**

- 查询数据集时，调用SqlSession的selectList：

  ```
  public <E> List<E> selectList(String statement)
  ```

- 在selectList中，调用实现了**Executor**接口的**CachingExecutor**的query方法

- 在query方法中，调用delegate.<E> query方法，其delegate是一个**BaseExecutor**对象，其实现了**Executor**接口

- 在**BaseExecutor**的query方法中，对任务进行了分发，继而调用了抽象方法**doQuery**

- **doQuery**被**BaseExecutor**的子类**SimpleExecutor**实现，并执行

- 在**SimpleExecutor**的doQuery方法中，继而调用**prepareStatement**方法，其最终调用**handler**对象的prepare、parameterize、query方法，而**handler**又是一个**RoutingStatementHandler**对象

- 重点研究**RoutingStatementHandler.query**方法，其内部调用**delegate.<E>query**，这里的delegate是一个**PreparedStatementHandler**对象

- **PreparedStatementHandler**对象的query方法中，准备**PreparedStatement**对象，并执行**execute**方法

## execute、executeUpdate、executeQuery区别

- execute可执行CRUD语句，其返回结果为boolean
  - 如果执行的是查询语句(R)，返回true则说明有结果集，用getResultSet获取结果集
  - 如果执行的是CUD语句，返回true则说明对数据有影响，用getUpdateCount获取影响行数
- executeUpdate仅可执行CUD语句，返回影响行数
- executeQuery仅可执行R语句，返回结果集

## properties标签

- 其用于描述数据库连接参数

  ```xml
  <properties></properties>
  ```

- resource属性

  - 以类路径的格式来描述配置文件位置

    ```xml
    <properties resource="jdbcConfig.properties"></properties>
    ```

- url属性

  - 以file协议的格式来描述配置文件位置

    ```xml
    <properties url="file:///C:/Users/123/Desktop/jdbcConfig.properties"></properties>
    ```

## typeAliases标签与package标签

- typeAliases

  - 用以配置别名，用于dao.xml中限定paramType

  - 内部可以嵌套typelAlias标签，也可以嵌套package标签

    ```
    <typelAlias type="实体类全限定名" alias="别名，不区分大小写"></typelAlias>
    ```

- package

  - 将其用于typeAliases中时，即用来指定要配置别名的包，当指定之后，该包下的实体类都会注册别名，并且类名就是别名，不再区分大小写

  ```
  <package name="com.dao"></package>
  ```

  - 将其用于mappers中时，即可用来指定dao接口所在的包，指定之后就不需要再写resource或class

# 连接池

## 概念

- 连接池就是用于存储连接的一个容器
  - 该容器就是一个集合对象，且必须线程安全
  - 该容器具有队列的特性
- 将连接对象放在一个池子里，要用的时候拿，用完之后放回
- 减少连接消耗时间

## mybatis连接池

## 配置

- SqlMapConfig.xml中的dataSource标签的type属性，其取值可以是：
  - POOLED：采用传统的javax.sql.dataSource规范中的连接池
  - UNPOOLED：采用传统的获取连接方式，虽然也实现了以上的dataSource接口，但没有池的思想
  - JNDI：采用服务器提供的JNDI技术实现，来获取DataSource对象，不同的服务器所能拿到的DataSource是不一样的。注意：非web或maven的war工程，不能使用

## POOLED

- 其内部准备了两个池：空闲池、活动池
- 请求连接
  - 空闲池有空闲连接，直接返回
  - 否则，查看活动池中连接数量是否已达最大数量，不是则新建连接返回
  - 否则，找出活动池中“最老”的连接，进行相关设置后返回

# mybatis事务

- 利用SqlSession的commit和rollback实现事务，最终还是调用的Connection的commit、rollback
- 自动提交：一次性的多条更新，最好只进行一次提交

# 动态SQL

- 标签if、where、foreach、sql

  ```xml
  <sql id="defaultUser">
  	SELECT * FROM USER
  </sql>
  ```

  ```xml
  <select id="listByIds" resultMap="userMap" parameterType="QueryVo">
      <include refid="defaultUser"></include>
      <where>
          <if test="ids != null and ids.size > 0">
              <foreach collection="ids" open=" and id in (" close=")" item="id" separator=",">
              	#{id}
              </foreach>
          </if> 
      </where>
  </select>
  ```

# 多表查询

## 一对一

- Account实体中有一个User实体

- AccountDao.xml

  ```xml
  <resultMap id="accountMap" type="account">
      <!-- 主键字段的对应 -->
      <id property="id" column="aid"></id>
      <!--非主键字段的对应-->
      <result property="uid" column="uid"></result>
      <result property="money" column="money"></result>
      <association property="user" column="uid" javaType="user">
          <id property="userId" column="id"></id>
          <result property="name" column="name"></result>
          <result property="password" column="password"></result>
      </association>
  </resultMap>
  <select id="listAll" resultMap="accountMap">
  	SELECT u.*,a.id AS aid,a.uid,a.money FROM USER u, account a WHERE u.id = a.uid
  </select>
  ```

## 一对多

- User实体中有一个List<Accout>列表

- UserDao.xml

  ```xml
  <resultMap id="userMap" type="user">
      <!-- 主键字段的对应 -->
      <id property="userId" column="id"></id>
      <!--非主键字段的对应-->
      <result property="name" column="name"></result>
      <result property="password" column="password"></result>
      <collection property="accounts" column="id" ofType="account">
          <id property="id" column="aid"></id>
          <result property="uid" column="uid"></result>
          <result property="money" column="money"></result>
      </collection>
  </resultMap>
      
  <select id="listAllWithAccount" resultMap="userMap">
  	SELECT u.*,a.id AS aid,a.uid,a.money FROM USER u, account a WHERE u.id = a.uid
  </select>
  ```

## 多对多

- User实体中有一个List<Account>，Account中也有一个List<User>

- UserDao.xml

  - resultMap与上面相仿

  ```xml
  <select id="listAllWithRoles" resultMap="userMap">
      SELECT u.*,r.ID AS rid,r.ROLE_NAME,r.ROLE_DESC FROM user u
          LEFT JOIN user_role ur ON u.ID = ur.UID
          LEFT JOIN role r ON ur.RID = r.id
  </select>
  ```

- AccountDao.xml

  ```xml
  <select id="listAllWithUsers" resultMap="roleMap">
      SELECT r.ID AS rid,r.ROLE_NAME,r.ROLE_DESC, u.* FROM role r
          LEFT JOIN user_role ur ON r.ID = ur.RID
          LEFT JOIN user u ON ur.UID = u.id
  </select>
  ```

# JNDI

## 概念

- Java Naming and Directory Interface，是SUN推出的一套规范，属于JavaEE技术之一
- 目的是模仿windows系统中的注册表在服务器中注册数据源

## 部署

http://note.youdao.com/yws/public/resource/48d56fd49a97c59bb18680cdc52cd835/xmlnote/1CB83AB7030A42E0A0C48DAF7A76297E/17553

# 延迟加载

## 概念

- 在真正使用数据时，才发起查询；也称为按需加载、懒加载
- 查询时机：用的第一时间进行查找并加载到内存
- 通常情况，多对一、一对一的情况下都采用**立即加载**，而一对多、多对多的情况都采用**延迟加载**
- 作用：在数据与对象进行mapping操作时，只有在真正使用到**该对象**（指的拥有可延迟加载属性的对象）时，才进行mapping操作，以**减少数据库查询开销**，提高系统性能
- 缺点：按需加载时会增加连接数据库的次数，同时会增加数据库的压力，所以要按需使用延迟加载

## 实现

### 开启延迟加载

- SqlMapConfig.xml

```xml
<configuration>
	<!--配置参数-->
    <settings>
        <!--开启Mybatis支持延迟加载-->
        <setting name="lazyLoadingEnabled" value="true"/>
        <setting name="aggressiveLazyLoading" value="false"></setting>
    </settings>
</configuration>
```

### *对一的延迟加载

- IAccountDao.xml
  - association中的column不能少，其是延迟加载查询的参数

```xml
<resultMap id="accountUserMap" type="account">
    <id property="id" column="id"></id>
    <result property="uid" column="uid"></result>
    <result property="money" column="money"></result>
    <!-- 一对一的关系映射：配置封装user的内容
    select属性指定的内容：查询用户的唯一标识：
    column属性指定的内容：用户根据id查询时，所需要的参数的值
    -->
    <association property="user" column="uid" javaType="user" select="dao.IUserDao.findById"></association>
</resultMap>
```

### *对多的延迟加载

- 与上面相似，不过配置的是collection属性

# 缓存

## 概念

- 存在于内存中的临时数据
- 减少与数据库的交互次数，提高执行效率
- 什么样的数据适用缓存：
  - 经常查询并且不经常改变的数据
  - 数据的正确与否对最终结果影响不大

## mybatis的一级缓存

- mybatis的一级缓存利用SqlSession来存储缓存，默认开启
- 一级缓存存放的是**对象**，即从缓存得到的对象其引用是相同的
- 当发生SqlSession.close()、update（并commit）时，SqlSession会更新缓存
- 不同SqlSession**不共享**缓存

## mybatis的二级缓存

- mybatis的二级缓存利用SqlSessionFactory来存储缓存，默认**不开启**

  - 配置开启：

    - SqlMapConfig.xml

      ```xml
      <settings>
      	<setting name="cacheEnabled" value="true"></setting><!-- 默认开始 -->
      </settings>
      ```

    - IUserDao.xml

      ```xml
      <cache/><!-- 配置namespace节点下 -->
      <select userCache="true"></select>
      
      ```

- 同一个SqlSessionFactory打开的不同SqlSession之间共享缓存

- 二级缓存存放的是**数据**，即从二级缓存得到的对象其地址是不同的 

# 注解开发

## 概念

- 针对CRUD的四种注解：@Select、@Delete、@Update、@Insert
- 注意：使用注解开发，不能在dao的同级目录下存在dao.xml配置文件

## 注解建立对应关系

```java
@Select("select * from user")
@Results(id="userMap", value = { 
    @Result(id=true, column="id", property="userId"),
    @Result(column="name", property="name"),
    @Result(column="address", property="address")
})
List<User> findAll();

@Select("select * from user where id=#{userId}")
@ResultMap(value={"userMap"})
User findById(int id);
```

## 一对一的查询配置---立即加载

```java
@Select("select * from account")
@Results(id="acountMap", value={
    @Result(id=true, column="id", property="id"),
    @Result(column="uid", property="uid"),
    @Result(column="money", property="money"),
    @Result(property="user", column="uid", one=@One(select="dao.UserDao.findById", fetchType=FetchType.EAGER)) /* FetchType.EAGER：立即加载 */
})
List<Account> findAll();

@Select("select * from aacount")
Account findById(int id);
```

## 一对多的查询配置---延时加载

```java
@Select("select * from user")
@Results(id="userMap", value = { 
    @Result(id=true, column="id", property="userId"),
    @Result(column="name", property="name"),
    @Result(column="address", property="address")
    @Result(property="accounts", colum="id", 
            many=@Many(select="dao.Account.findById", fetchType=FethcType.LAZY))
})
List<User> findAll();
```

## 注解使用缓存

- 一级缓存**默认开启**

- 二级缓存

  - SqlMapConfig开启二级缓存：默认开启

  - dao.java

    ```java
    @CacheNamespace(blocking = true)
    public interface UserDao{...}
    ```

    