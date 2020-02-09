package thread;

/**
 * @author EasonDongH
 * @date 2020/2/6 16:21
 */
public class RunnableTest implements Runnable {

    private int i = 0;

    @Override
    public void run() {
        System.out.println("runnable: " + Thread.currentThread().getId());
        i = 10;
        System.out.println("Runnable is done");
    }

    public void runAsync(){
        new Thread(()->{
            i = 100;
        });
    }

    public static void main(String[] args) {
        System.out.println("main: " + Thread.currentThread().getId());
        new Thread(new RunnableTest()).start();
    }
}
