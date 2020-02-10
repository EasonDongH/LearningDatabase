package practice.src.lock;

import javax.swing.*;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Semaphore;
import java.util.concurrent.TimeUnit;

/**
 * @author EasonDongH
 * @date 2020/2/10 11:58
 */
public class SemaphoreTest implements Runnable {

    @Override
    public void run() {
        try {
            Thread.sleep(1000);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        System.out.println("CurrentThread: " + Thread.currentThread());
    }

    public static void main(String[] args) throws InterruptedException {
        final int nPermits = 5;
        final  Semaphore semaphore = new Semaphore(nPermits);
        ExecutorService executorService = Executors.newFixedThreadPool(2*nPermits);

        executorService.execute(()->{
            try {
                semaphore.acquire();
                Thread.sleep(1000);
                System.out.println("1: " + Thread.currentThread());
            } catch (InterruptedException e) {
                e.printStackTrace();
            } finally {
                semaphore.release();
            }
        });
        // 最后两个线程会阻塞一会儿等待许可证
        for (int i = 0; i < nPermits+1; i++) {
            final int j = i;
            executorService.execute(()->{
                try {
                    semaphore.acquire();
                    Thread.sleep(1000);
                    System.out.println(j + ": " + Thread.currentThread());
                } catch (InterruptedException e) {
                    e.printStackTrace();
                } finally {
                    semaphore.release();
                }
            });
        }

    }


}
