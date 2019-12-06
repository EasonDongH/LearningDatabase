package com.easondongh.mvc;

import com.sun.corba.se.impl.protocol.giopmsgheaders.TargetAddress;
import org.springframework.context.ApplicationContext;
import org.springframework.util.Assert;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.util.HashMap;

/**
 *  管理MvcBean对象
 */
public class MvcBeanFactory {

    private ApplicationContext applicationContext;
    /**
     *  保存所有MvcBean对象
     */
    private HashMap<String,MvcBean> mvcBeans = new HashMap<>();

    public class MvcBean{
        String mvcBeanName;
        String targetName;// IOC Bean的名称
        Object target;
        Method targetMethod;
        ApplicationContext context;

        public String getMvcBeanName() {
            return mvcBeanName;
        }

        public String getTargetName() {
            return targetName;
        }

        public Object getTarget() {
            return target;
        }

        public Method getTargetMethod() {
            return targetMethod;
        }

        public ApplicationContext getContext() {
            return context;
        }

        /**
         * 执行Controller方法
         * @return
         */
        public Object handle(Object... args) throws InvocationTargetException, IllegalAccessException {
            // 懒加载
            if(this.target == null) {
                target = this.context.getBean(targetName);
            }
            return targetMethod.invoke(this.target,args);
        }
    }

    public MvcBeanFactory(ApplicationContext applicationContext) {
        Assert.notNull(applicationContext, "argument 'applicationContext' can not be null");
        this.applicationContext = applicationContext;
        loadMvcBeanFromSpringBeans();
    }

    /**
     *  从IOC容器中装载MvcBean
     */
    private void loadMvcBeanFromSpringBeans(){
        this.mvcBeans.clear();

        // 扫描容器中的所有Bean对象，获取被MvcMapping注解标记了的方法
        // 先拿到所有的Bean对象名称
        String[] names = applicationContext.getBeanDefinitionNames();
        Class<?> type;
        for (String name : names) {
            type = applicationContext.getType(name);
            for (Method method : type.getDeclaredMethods()) {
                MvcMapping mvcMapping = method.getAnnotation(MvcMapping.class);
                if(mvcMapping != null) {
                    MvcBean mvcBean = ConvertToMvcBean(mvcMapping, name, method);
                    this.mvcBeans.put(mvcBean.mvcBeanName, mvcBean);
                }
            }
        }
    }

    public MvcBean getMvcBean(String beanName){
        return this.mvcBeans.get(beanName);
    }

    /**
     * 将MvcMapping参数转换为MvcBean对象
     * @param mvcMapping
     * @param beanName
     * @param method
     * @return
     */
    private MvcBean ConvertToMvcBean(MvcMapping mvcMapping, String beanName, Method method) {
        MvcBean mvcBean = new MvcBean();
        mvcBean.mvcBeanName = mvcMapping.value();
        mvcBean.targetName = beanName;
        mvcBean.targetMethod = method;
        mvcBean.context = this.applicationContext;
        return mvcBean;
    }
}
