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

## CRUD

- 获取自增列id

  ```
  
  ```

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

     











