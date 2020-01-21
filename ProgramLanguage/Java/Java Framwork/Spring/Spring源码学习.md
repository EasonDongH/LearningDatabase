# Spring源码学习

## IOC

### 提出问题

1. Bean工程如何生成Bean对象？
   - 配置了xml或注解，如何变成bean对象
2. Bean的依赖关系谁来维护？
3. Bean工厂与应用上文（ApplicationContext）的区别？

### 关注问题

- 如何获取对象描述？xml解析解析为BeanDefinitionValueResolver对象
- 如何生成对象？DefaultSingletonBeanRegistry.getSingleton
- 如何保存对象？DefaultSingletonBeanRegistry.singletonObjects
- 如何管理Bean对象？AbstractAutowireCapableBeanFactory，创建、销毁、装配
- 如何解决循环依赖？earlySingletonObjects、singletonsCurrentlyInCreation

### 知识点

- BeanFactory与FactoryBean区别？
  - BeanFactory是IOC的顶层接口之一，主要用来管理Bean对象
    - BeanFactory是比较原始的Factory，可被子接口ApplicationContext完全代替
    - 方法有：getBean、containsBean、isTypeMatch等
    - 重要实现类有：AbstractAutowireCapableBeanFactory
  - FactoryBean用来创建Bean对象
    - 通过getObject方法返回对象实例，在这个方法我们可以控制对象的创建过程：是否单例、创建条件等
    - Spring从BeanFactory中获取的实际就是从FactoryBean.getObject得到的对象

### 分析图

![](https://note.youdao.com/yws/public/resource/48d56fd49a97c59bb18680cdc52cd835/xmlnote/CEB1C82D9F5547FDA6771D371B551E0A/17580)

![](https://note.youdao.com/yws/public/resource/48d56fd49a97c59bb18680cdc52cd835/xmlnote/DB7001CC68694DD0BDA76C8B85CDF108/17578)

![](https://note.youdao.com/yws/public/resource/48d56fd49a97c59bb18680cdc52cd835/xmlnote/8241E502A8CD4B4A808B87D1CE0C5BBB/17577)

## 事务

### ACID

- A：原子性（atomicity）
  - 事务中的各项操作，要么全部执行，要么全部不执行，任一项操作执行失败都会导致证功事务失败
- C：一致性（consistency）
  - 指数据的总量不变
  - 前提是数据之间要有一致性的特性，比如10万张火车票，由10台服务器出售，总售出的票数也必须不超过10万张
  - 与原子性的差别：原子性保证的是一个操作组合的正常性，比如转账环境中出现A=A+100,B=B+100，可以符合原子性但无法满足一致性（总金额数量发生了变化）
- I：隔离性（isolation）
  - 并发执行的事务彼此应该无法看到对方的中间状态
- D：持久性（durability）
  - 事务完成后的改动应持久化

### 术语

- 脏读：两个并行的事务，事务A更新数据但未提交（没有更新到数据库），这时事务B却能看到事务A做的更新
  - 事务A可选择不提交、提交、回滚事务，导致数据不一致
- 不可重复读：同一个事务，在不同的时间节点，执行相同的SQL语句，获取的结果却不一致
  - 带来的问题：
    - 网站在12:00:00启动事务A，统计访问量（1000），而并行的另一个事务B在12:00:01将访问量更新为2000，那么事务A在生成报表的过程中（比如12:00:03）获取到的是2000，这是不对的，因为我们想统计的是12:00:00的访问量，而不是12:00:02的
  - 有些业务场景也可能需要可重复读，即同一事务中读取的都是最新的值
- 幻读：同一个事务中，在T1时刻查询不存在记录A，即插入记录A，却出现两条记录A
  - 带来的问题：同一张票或同一个座位同时被多个人买到

|           隔离级别           |  脏读  | 不可重复读 |  幻读  |
| :--------------------------: | :----: | :--------: | :----: |
| 未提交读（Read Uncommitted） |  可能  |    可能    |  可能  |
|  已提交读（Read committed）  | 不可能 |    可能    |  可能  |
|  可重复读（Repeated read）   | 不可能 |   不可能   |  可能  |
|   可串行化（Serializable）   | 不可能 |   不可能   | 不可能 |



### Spring对事务的支持

