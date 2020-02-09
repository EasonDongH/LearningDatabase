package singleton;

/**
 * @author EasonDongH
 * @date 2020/2/8 20:07
 */
public class Singleton5 {

    private Singleton5(){}

    private enum SingletonEnum{
        /**
         * 枚举实例
         */
        SINGLETON_ENUM;
        private Singleton5 instance;
        /**
         * jvm保证这个方法绝对的调用一次
         * @return
         */
        SingletonEnum(){
            instance=new Singleton5();
        }
        public Singleton5 getSingleton(){
            return  instance;
        }
    }

    public static Singleton5 getInstance(){
        return SingletonEnum.SINGLETON_ENUM.getSingleton();
    }
}
