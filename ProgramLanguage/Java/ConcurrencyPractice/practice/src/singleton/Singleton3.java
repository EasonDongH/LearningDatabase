package singleton;

/**
 * 双重锁
 * @author EasonDongH
 * @date 2020/2/8 19:33
 */
public class Singleton3 {
    private volatile static Singleton3 instance;

    private Singleton3(){}

    public static Singleton3 getInstance(){
        if(instance == null) {
            synchronized (Singleton3.class) {
                if(instance == null) {
                    instance = new Singleton3();
                }
            }
        }
        return instance;
    }
}
