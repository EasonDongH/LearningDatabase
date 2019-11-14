## Java高级

### BeanUtils

- 用于封装JavaBean
  - JavaBean：标准的Java类
    - 要求
      - 类必须使用public修饰
      - 必须提供空参的构造器
      - 成员变量必须使用private修饰，并且提供相应的getter/setter
    - 功能
      - 封装数据，类似C#中的实体类概念
  - 方法
    - setProperty(Object obj, String propertyName, String propertyValue)
    - String getProperty(Object obj, String propertyName)
    - populate(Object bean, Map properties)

