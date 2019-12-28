基于XML
1. 构造SqlSessionFactory
SqlSessionFactory sqlSessionFactory = new SqlSessionFactoryBuilder().build(inputStream);
	org.apache.ibatis.session.SqlSessionFactoryBuilder#build(java.io.InputStream, java.lang.String, java.util.Properties)
		org.apache.ibatis.builder.xml.XMLConfigBuilder#parse
			org.apache.ibatis.builder.xml.XMLConfigBuilder#parseConfiguration  解析mybatis-config.xml配置文件
				org.apache.ibatis.builder.xml.XMLConfigBuilder#typeAliasesElement	解析别名，存到HashMap中
				org.apache.ibatis.builder.xml.XMLConfigBuilder#environmentsElement	解析environment，包括datasource
				org.apache.ibatis.builder.xml.XMLConfigBuilder#mapperElement	获取xxxMapper.xml文件
				...
				return configuration;	此时的configuration已经保存了mybatis-config.xml中解析到的所有信息
			org.apache.ibatis.session.SqlSessionFactoryBuilder#build(org.apache.ibatis.session.Configuration)
				return new DefaultSqlSessionFactory(config);

2. 获取SqlSession
SqlSession sqlSession = sqlSessionFactory.openSession();
	org.apache.ibatis.session.Configuration#getDefaultExecutorType  默认ExecutorType.SIMPLE，有SIMPLE, REUSE, BATCH
	org.apache.ibatis.session.defaults.DefaultSqlSessionFactory#openSessionFromDataSource
		org.apache.ibatis.session.Configuration#newExecutor(org.apache.ibatis.transaction.Transaction, org.apache.ibatis.session.ExecutorType)
			org.apache.ibatis.executor.SimpleExecutor#SimpleExecutor	默认使用SimpleExecutor
			org.apache.ibatis.executor.CachingExecutor#CachingExecutor	默认开启一级缓存
			org.apache.ibatis.plugin.InterceptorChain#pluginAll	  配置拦截链
		return executor;
	return org.apache.ibatis.session.defaults.DefaultSqlSession#DefaultSqlSession(org.apache.ibatis.session.Configuration, org.apache.ibatis.executor.Executor, boolean);

3. 查询
User user = sqlSession.selectOne("com.easondongh.UserMapper.selectUser", 1);
	
	org.apache.ibatis.session.defaults.DefaultSqlSession#selectOne(java.lang.String, java.lang.Object)
		org.apache.ibatis.session.defaults.DefaultSqlSession#selectList(java.lang.String, java.lang.Object, org.apache.ibatis.session.RowBounds)
			org.apache.ibatis.session.Configuration#getMappedStatement(java.lang.String, boolean)	获取xxxMapper.xml中的SQL语句，缓存在HashMap中，键为：namespace+id
			org.apache.ibatis.executor.CachingExecutor#query(org.apache.ibatis.mapping.MappedStatement, java.lang.Object, org.apache.ibatis.session.RowBounds, org.apache.ibatis.session.ResultHandler)
				org.apache.ibatis.session.Configuration#getMappedStatement(java.lang.String, boolean)	获取Select节点，包括SQL语句及相应的配置信息：id、resultType、parameterType等
				org.apache.ibatis.mapping.MappedStatement#getBoundSql	获取原始SQL语句，以及入参
				org.apache.ibatis.executor.BaseExecutor#createCacheKey	创建（更新）缓存的KEY值：hashcode = multiplier * hashcode + baseHashCode
				org.apache.ibatis.executor.CachingExecutor#query(org.apache.ibatis.mapping.MappedStatement, java.lang.Object, org.apache.ibatis.session.RowBounds, org.apache.ibatis.session.ResultHandler, org.apache.ibatis.cache.CacheKey, org.apache.ibatis.mapping.BoundSql)
					list = resultHandler == null ? (List<E>) localCache.getObject(key) : null;
					有缓存：
						直接返回
					无缓存：
						org.apache.ibatis.executor.BaseExecutor#queryFromDatabase
							org.apache.ibatis.executor.SimpleExecutor#doQuery
								org.apache.ibatis.executor.SimpleExecutor#prepareStatement	预编译参数赋值
								org.apache.ibatis.executor.statement.PreparedStatementHandler#query
								org.apache.ibatis.executor.resultset.DefaultResultSetHandler#handleResultSets	进行数据封装
							localCache.putObject(key, list);	
		return list.get(0);

基于注解
1. 在解析mybatis-config.xml时创建xxxMapper代理对象
	
	org.apache.ibatis.builder.xml.XMLConfigBuilder#mapperElement
		org.apache.ibatis.binding.MapperRegistry#addMapper	创建代理对象工厂并存入HashMap，Key为mapper接口全限定名
			org.apache.ibatis.builder.annotation.MapperAnnotationBuilder#parse	
				org.apache.ibatis.builder.annotation.MapperAnnotationBuilder#parseStatement	
					org.apache.ibatis.builder.MapperBuilderAssistant#addMappedStatement	缓存MappedStatement至Configuration.mappedStatements

2. 获取xxxMapper实现类（代理类）
	UserMapper mapper = sqlSession.getMapper(UserMapper.class);
		org.apache.ibatis.binding.MapperRegistry#getMapper	
			org.apache.ibatis.binding.MapperProxyFactory#newInstance(org.apache.ibatis.binding.MapperProxy<T>)	根据代理对象工厂创建代理对象

3. 调用接口方法执行查询
	org.apache.ibatis.binding.MapperProxy#invoke
		org.apache.ibatis.binding.MapperProxy#cachedMapperMethod	方法缓存，ConcurrentHashMap
		org.apache.ibatis.binding.MapperMethod#execute
			switch (command.getType())	判断CRUD类型
				判断返回类型
					获取【接口全限定名+方法名】，以及参数，传给sqlSession.selectOne
						根据【接口全限定名+方法名】获取MappedStatement对象，其sqlSource字段存储了SQL语句
	