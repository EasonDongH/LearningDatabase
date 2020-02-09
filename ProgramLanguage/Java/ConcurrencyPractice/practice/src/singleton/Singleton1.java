package singleton;

/**
 * 饿汉模式
 * @author EasonDongH
 * @date 2020/2/8 19:25
 */
public class Singleton1 {
    private static Singleton1 instance = new Singleton1();

    private Singleton1(){}

    public static Singleton1 getInstance(){
        return instance;
    }
}
