package lock;

import java.util.concurrent.TimeUnit;
import java.util.concurrent.locks.ReentrantLock;

/**
 * @author EasonDongH
 * @date 2020/2/7 19:56
 */
public class ReentrantLockTest implements Runnable {

    public final ReentrantLock reentrantLock = new ReentrantLock();

    private static int counter = 0;

    @Override
    public void run() {
        test2();
    }

    public void test1(){
        reentrantLock.lock();
        try {
            for (int i = 0; i < 1000; i++) {
                counter += 1;
            }
        } finally {
            reentrantLock.unlock();
        }
    }

    public void test2(){
        try {
            if(reentrantLock.tryLock(3, TimeUnit.SECONDS)) {
                Thread.sleep(6000);
                for (int i = 0; i < 1000; i++) {
                    counter += 1;
                }
            } else {
                System.out.println("获取锁失败");
            }

        } catch (InterruptedException e) {
            e.printStackTrace();
        } finally {
            if(reentrantLock.isHeldByCurrentThread()) {
                reentrantLock.unlock();
            }
        }
    }

    public static void main(String[] args) throws InterruptedException {
        ReentrantLockTest test = new ReentrantLockTest();
        Thread t1 = new Thread(test);
        Thread t2 = new Thread(test);
        t1.start();t2.start();
        t1.join();t2.join();
        System.out.println(ReentrantLockTest.counter);
    }
}
