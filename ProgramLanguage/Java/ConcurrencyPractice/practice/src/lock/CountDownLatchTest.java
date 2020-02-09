package lock;

import java.util.concurrent.CountDownLatch;

/**
 * @author EasonDongH
 * @date 2020/2/7 20:07
 */
public class CountDownLatchTest {

    public static void main(String[] args) throws InterruptedException {
        final int nThreads = 10;
        CountDownLatch startGate = new CountDownLatch(1);
        CountDownLatch endGate = new CountDownLatch(nThreads);
        for (int i = 0; i < nThreads; i++) {
            Thread t = new Thread(()->{
                try {
                    startGate.await();
                } catch (InterruptedException e) {
                    e.printStackTrace();
                } finally {
                    endGate.countDown();
                }
            });
            t.start();
        }
        startGate.countDown();
        endGate.await();
        System.out.println("Done");
    }
}
