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

