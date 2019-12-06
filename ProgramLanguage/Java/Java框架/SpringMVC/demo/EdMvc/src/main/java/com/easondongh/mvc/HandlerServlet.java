package com.easondongh.mvc;

import freemarker.template.Configuration;
import freemarker.template.Template;
import freemarker.template.TemplateException;
import freemarker.template.TemplateExceptionHandler;
import org.springframework.beans.factory.NoSuchBeanDefinitionException;
import org.springframework.core.LocalVariableTableParameterNameDiscoverer;
import org.springframework.core.ParameterNameDiscoverer;
import org.springframework.web.context.WebApplicationContext;
import org.springframework.web.context.support.WebApplicationContextUtils;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.File;
import java.io.IOException;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Arrays;
import java.util.Date;
import java.util.List;

public class HandlerServlet extends HttpServlet {

    final ParameterNameDiscoverer parameterUtil = new LocalVariableTableParameterNameDiscoverer();
    private WebApplicationContext webApplicationContext;
    private MvcBeanFactory mvcBeanFactory;
    private Configuration freemarkeConfig;

    /**
     * 执行HttpServlet的初始化方法，加载MvcBean对象以及Freemarker视图配置信息
     * @throws ServletException
     */
    @Override
    public void init() throws ServletException {
        this.webApplicationContext = WebApplicationContextUtils.getWebApplicationContext(getServletContext());
        this.mvcBeanFactory = new MvcBeanFactory(this.webApplicationContext);
        Configuration configuration = null;
        try {
            configuration = this.webApplicationContext.getBean(Configuration.class);
        } catch (NoSuchBeanDefinitionException e) {
            System.out.println(e);
        }
        if(configuration == null) {
            configuration = new Configuration(Configuration.VERSION_2_3_22);
            configuration.setDefaultEncoding("UTF-8");
            configuration.setTemplateExceptionHandler(TemplateExceptionHandler.RETHROW_HANDLER);
            try {
                configuration.setDirectoryForTemplateLoading(new File(getServletContext().getRealPath("/ftl/")));
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        }
        this.freemarkeConfig = configuration;
    }

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
//        super.doGet(req, resp);
        this.doHandler(req,resp );
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
//        super.doPost(req, resp);
        this.doHandler(req,resp);
    }

    /**
     * TODO 过滤静态资源
     * @param uri
     */
    public boolean isStaticResources(String uri){
        boolean result = false;
        if("/favicon.ico".equals(uri)) {
            result = true;
        }
        return result;
    }

    /**
     *  处理URL请求，并返回视图
     *  TODO 根据具体异常，做不同处理
     * @param req
     * @param resp
     */
    public void doHandler(HttpServletRequest req, HttpServletResponse resp){
        String uri = req.getServletPath();
        if(isStaticResources(uri)) {
            return;
        }
        // 根据URL获取对应的处理方法
        MvcBeanFactory.MvcBean mvcBean = mvcBeanFactory.getMvcBean(uri);
        if(mvcBean == null) {
            throw new IllegalArgumentException(String.format("not found %s mapping",uri));
        }
        Object[] args = buildParams(mvcBean, req, resp);
        try {
            Object handleResult = mvcBean.handle(args);
            processResult(handleResult, resp);
        } catch (InvocationTargetException e) {// 这里可以根据具体异常，做不同处理
            e.printStackTrace();
        } catch (IllegalAccessException e) {
            e.printStackTrace();
        } catch (TemplateException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    /**
     * 对控制器方法返回结果进行处理
     * TODO 支持更多的视图类型
     * @param handleResult
     * @param resp
     */
    private void processResult(Object handleResult, HttpServletResponse resp) throws IOException, TemplateException {
        if(handleResult instanceof FreemarkeView) {
            FreemarkeView fview = (FreemarkeView)handleResult;
            resp.setContentType("text/html;charset=utf-8");
            resp.setCharacterEncoding("utf-8");
            resp.setStatus(200);
            Template template = this.freemarkeConfig.getTemplate(fview.getFtlPath());
            template.process(fview.getModels(),resp.getWriter());
        }
    }

    /**
     *  根据MvcBean，封装实际Controller方法所需要的执行参数
     * @param mvcBean
     * @param req
     * @param resp
     * @return
     */
    public Object[] buildParams(MvcBeanFactory.MvcBean mvcBean,HttpServletRequest req, HttpServletResponse resp) {
        Method method = mvcBean.getTargetMethod();
        List<String> paramNames = Arrays.asList(parameterUtil.getParameterNames(method));
        Class<?>[] paramTypes = method.getParameterTypes();
        Object[] args = new Object[paramTypes.length];
        for (int i=0; i<paramNames.size(); i++) {
            if(paramTypes[i].isAssignableFrom(HttpServletRequest.class)) {
                args[i] = req;
            } else if(paramTypes[i].isAssignableFrom(HttpServletResponse.class)) {
                args[i] = resp;
            } else {
                args[i] = convert(req.getParameter(paramNames.get(i)), paramTypes[i]);
            }
        }
        return args;
    }

    /**
     * 类型转换
     * TODO 仅处理了基础类型
     * @param val
     * @param targetClass
     * @param <T>
     * @return
     */
    public <T> T convert(String val, Class<T> targetClass) {
        Object result = null;
        if(val == null) {
            return null;
        } else if(Integer.class.equals(targetClass)) {
            result = Integer.parseInt(val.toString());
        } else if(Long.class.equals(targetClass)) {
            result = Long.parseLong(val.toString());
        } else if(String.class.equals(targetClass)) {
            result = val;
        } else if(Date.class.equals(targetClass)) {
            try {
                result = new SimpleDateFormat("").parse(val);
            } catch (ParseException e) {
                throw new IllegalArgumentException("date format Illegal must be 'yyyy-MM-dd HH:mm:ss'");
            }
        }
        return (T)result;
    }
}
