package singleton;

/**
 * 懒汉模式
 * @author EasonDongH
 * @date 2020/2/8 19:32
 */
public class Singleton2 {
    private static Singleton2 instance;

    static {
        instance = new Singleton2();
    }

    private Singleton2(){}

    public static Singleton2 getInstance(){
        return instance;
    }
}
