package pool.custom.concurrent.test;

import pool.custom.concurrent.ThreadPoolExecutor;

import java.util.concurrent.LinkedBlockingDeque;

/**
 * @author EasonDongH
 * @date 2020/2/8 22:35
 */
public class ThreadPoolTest {

    public static void main(String[] args) {
        ThreadPoolExecutor executor = new ThreadPoolExecutor(5, 10, new LinkedBlockingDeque<>());
        for (int i = 0; i < 15; i++) {
            final int index = i;
            executor.execute(()->{
                try {
                    Thread.sleep(1000 * index);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                System.out.println(Thread.currentThread().getId());
                System.out.println("Task " + index);
            });
        }
    }
}
