package singleton;

/**
 * 静态内部类
 * @author EasonDongH
 * @date 2020/2/8 19:52
 */
public class Singleton4 {

    private Singleton4(){}

    private static class SingletonInner{
        private static final Singleton4 instance = new Singleton4();
    }

    public static Singleton4 getInstance(){
        return SingletonInner.instance;
    }
}
