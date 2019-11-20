# Redis

## 概念

- 高性能、NoSQL（Not Only SQL）、非关系型数据库
  - NoSQL：数据之间没有关联关系，且存储在内存中
- 一般在关系型数据库中**存储**数据，在非关系型数据库中**备份**数据

- **C语言、开源、键值对**

- 应用场景
  - 缓存：数据查询、短连接、新闻内容
  - 任务队列：秒杀、抢购

## 数据结构

- Redis存储的是键值对，其键为字符串，值有5种数据类型：
  1. 字符串类型
  2. 哈希类型
  3. 列表类型
  4. 集合类型
  5. 有序集合类型

## 操作

### 命令行操作

- 字符串
  - 存储：set key value 新值覆盖旧值
  - 获取：get key 不存在返回<nil>
  - 删除：del key
- 哈希类型
  - 存储：hset key field value 给key对应的map的某个字段设值
  - 获取：hget key field 获取key对应的map的某个字段的值
    - hgetall key 获取key对应的map的所有键值对内容
  - 删除：hdel key field

- 列表类型
  - 存储
    - lpush key value：从key对应列表最左边添加元素
    - rpush key value：从key对应列表最右边添加元素
  - 获取：lrange key start end 范围获取
  - 删除
    - lpop key：删除key对应列表最左边的元素，并将元素返回
    - rpopkey：删除key对应列表最右边的元素，并将元素返回
- 集合类型：不允许重复元素
  - 存储：sadd key value
  - 获取：smembers key 获取key对应的set集合种所有元素
  - 删除：srem key value 删除key对应的set中值为value的元素
- 有序集合类型：不允许重复元素，且保证有序
  - 存储：zadd key score value 根据double类型的score进行降序排序
  - 获取：zrange key start end [withscores]
    - 0 -1：获取所有元素
  - 删除：zrem key value
- 通用命令
  - keys *：查询所有键
  - type key：查询键对应的值类型
  - del key：删除指定的键值对

## 持久化

### 概念

- 因Redis是一个内存数据库，在redis服务重启或硬件重启时，数据会丢失
- 因此将redis持久化存储到硬盘中，以确保数据不会丢失
- 持久化机制：
  - RDB：默认方式
    - 定时检测key的变化情况，然后进行持久化数据
    - 对性能影响较低
  - AOF：日志记录方式
    - 记录每一条命令的操作，可以在每次命令操作后进行持久化操作
    - 对性能影响较大

### 配置

- RDB

  - 配置文件：redis.windows.conf

    - save 900 1：after 900 sec (15 min) if at least 1 key changed

    - save 300 10：after 300 sec (5 min) if at least 10 keys changed
    - save 60  10000：after 60 sec if at least 10000 keys changed

  - 启动服务：带配置文件启动

    ```shell
    > redis-server.exe redis.windows.conf
    ```

  - 持久化文件

    - 后缀名为：.rdb

- AOF

  - 配置文件：redis.windows.conf
    - 设置：appendonly yes，开启AOF
    - appendfsync always：每条命令都进行持久化
    - appendfsync everysec：每秒进行一次持久化
    - appendfsync no：不进行持久化

  - 启动服务：带配置文件启动，如上
  - 持久化文件
    - 后缀名为：.aof

  ## 服务设置为自启动

  - 将redis注册为windows服务

  ```
  > redis-server.exe --service-install redis.windows.conf
  ```

  - 到服务中，设置redis的启动属性

