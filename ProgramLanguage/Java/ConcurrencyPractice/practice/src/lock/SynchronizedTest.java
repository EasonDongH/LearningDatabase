package lock;

import java.util.concurrent.CountDownLatch;

/**
 * @author EasonDongH
 * @date 2020/2/7 16:29
 */
public class SynchronizedTest implements Runnable {

    static int counter = 0;

    /**
     * 线程不安全
     */
    private void add(){
        for(int i=0; i<10000; i++) {
            counter += 1;
        }
    }

    /**
     * 对象锁：同一实例线程安全
     */
    private synchronized void add1(){
        add();
    }

    /**
     * 类锁：多实例线程安全
     */
    private void add2(){
        synchronized (SynchronizedTest.class) {
            add();
        }
    }

    @Override
    public void run() {
        add1();
    }

    public static void main(String[] args) throws InterruptedException {
        SynchronizedTest test = new SynchronizedTest();
        SynchronizedTest test1 = new SynchronizedTest();
        Thread t1 = new Thread(test);
        Thread t2 = new Thread(test1);
        t1.start();t2.start();
        t1.join();t2.join();
        System.out.println(SynchronizedTest.counter);


    }


}
