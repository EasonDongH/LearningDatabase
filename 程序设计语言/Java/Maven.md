# Maven

## 概念

- 发音[meven]，美国口语化的词语，代表专家、内行
- Maven是一个项目管理工具，项目对象模型（POM）
- Maven能解决的问题
  - 帮助构建工程
  - 管理jar包
  - 编译代码
  - 自动运行单元测试
  - 打包、生成报表
  - 部署项目，生成web站点
  - ...

## 核心功能

- 依赖管理
  - 传统项目将所有jar包含在项目中，而maven项目将所有jar包放在maven专属的jar包仓库中，项目只包含jar的坐标
- 一键构建

## 配置Maven

- 将Maven安装包放到无中文、无空格的路径中
- 到环境变量中新建MAVEN_HOME：C:\DevelopSpace\apache-maven-3.5.2-bin\apache-maven-3.5.2，并在Path中新增：%MAVEN_HOME%\bin
- **注意：**MAVEN依赖于JAVA_HOME
- 测试安装：> mvn -v

## Maven仓库

- 分类：本地仓库、远程仓库（私服）、中央仓库
- 启动Maven后，先在【本地仓库】找jar包，找不到再去【远程仓库】找，还找不到就去【中央仓库】下载jar包

- 本地仓库配置

  - 见\conf下的settings.xml文件

    ```xml
    <!-- localRepository
       | The path to the local repository maven will use to store artifacts.
       |
       | Default: ${user.home}/.m2/repository
      <localRepository>/path/to/local/repo</localRepository>
    -->
    <localRepository>C:\DevelopSpace\maven_repository</localRepository>
    ```

## Maven标准目录结构

- src/main/java：核心代码
- src/main/resources：配置文件
- src/test/java：测试代码
- src/test/resources：测试配置文件
- src/main/webapp：页面资源

## Maven常用命令

- mvn clean：删除target目录
- mvn compile：编译src/main/java下的核心代码，放入target目录下

- mvn test：编译src/test/java下的测试代码与src/main/java下的核心代码，放入target目录下

- mvn package
  - 完成mvn compile、mvn test工作
  - 打成war包，放到target目录下
    - 可在pom.xml中配置打什么类型的包：<packaging> war<packaging>
- mvn install
  - 完成mvn compile、mvn test、mvn package工作
  - 并将打好的包放置到maven的本地仓库
- mvn deploy：发布，配置后才可执行

## Maven生命周期

- 清理生命周期：mvn clean
- 默认生命周期：执行后面的命令的时候，都会把前面所有的命令再次执行一遍
  - 编译
  - 测试
  - 打包
  - 安装
  - 发布
- 站点生命周期

## Maven概念模型图

![](https://note.youdao.com/yws/public/resource/48d56fd49a97c59bb18680cdc52cd835/xmlnote/E74188228356450CB6E8D5A47FBF76D4/17497)

- pom.xml：工程信息、jar包坐标信息、运行环境信息
  - jar包坐标信息包括：
    - GroupId
    - ArtifactId：项目名称
    - Version

# IDEA集成maven

### 配置maven

![](https://note.youdao.com/yws/public/resource/48d56fd49a97c59bb18680cdc52cd835/xmlnote/843DADBABC0F47539990C6EB15918C98/17503)

![](https://note.youdao.com/yws/public/resource/48d56fd49a97c59bb18680cdc52cd835/xmlnote/CD7F5F1849054F74A09FD33A0837F87B/17501)
- 填写VM Options：-DarchetypeCatalog=internal，用于在不能联网的情况下，maven自己寻找已下载好的插件，而不会启动失败

- 因为Maven中央仓库的服务器在国外，可能被墙，可以配置用阿里云的Maven，速度杠杠的

  - 在settings.xml中添加

    ```
    
    ```

    

