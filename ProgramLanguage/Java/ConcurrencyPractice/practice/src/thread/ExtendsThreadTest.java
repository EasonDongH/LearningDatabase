package thread;

/**
 * @author EasonDongH
 * @date 2020/2/6 16:23
 */
public class ExtendsThreadTest extends Thread {

    @Override
    public void run() {
        System.out.println("thread.ExtendsThreadTest: " + Thread.currentThread().getId());
        System.out.println("thread.ExtendsThreadTest is done");
    }

    public static void main(String[] args) {
        System.out.println("main: " + Thread.currentThread().getId());
        new ExtendsThreadTest().start();
    }
}
