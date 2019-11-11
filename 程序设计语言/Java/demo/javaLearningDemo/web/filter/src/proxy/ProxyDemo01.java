package proxy;

import java.lang.reflect.InvocationHandler;
import java.lang.reflect.Method;
import java.lang.reflect.Proxy;

public class ProxyDemo01 {
    public static void main(String[] args) {
        Lenovo lenovo = new Lenovo();

        Object proxy_Lenove = Proxy.newProxyInstance(Lenovo.class.getClassLoader(), Lenovo.class.getInterfaces(), new InvocationHandler() {
            /**
             *
             * @param proxy 代理对象：这里就是proxy_Lenove
             * @param method 代理方法
             * @param args 代理方法的参数
             * @return
             * @throws Throwable
             */
            @Override
            public Object invoke(Object proxy, Method method, Object[] args) throws Throwable {
                // 找到代理对象中，需要代理的方法
                if (method.getName() == "sale") {
                    // 对参数进行增强
                    double money = Double.parseDouble(args[0].toString());
                    money -= 1000;// 代理商收取1000
                    args[0] = money;
                    // 对方法体进行增强
                    System.out.println("增强方法体……前");
                    Object invoke = method.invoke(lenovo, args);
                    System.out.println("增强方法体……后");
                    // 对返回值进行增强
                    return invoke.toString() + " 外增鼠标垫";
                } else {
                    Object invoke = method.invoke(lenovo, args);
                    return invoke;
                }
            }
        });

        System.out.println(((SaleComputer) proxy_Lenove).sale(8000));
        System.out.println(proxy_Lenove.toString());
    }
}
