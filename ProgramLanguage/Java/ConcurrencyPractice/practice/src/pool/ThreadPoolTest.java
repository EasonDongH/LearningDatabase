package pool;

import java.util.concurrent.*;

/**
 * @author EasonDongH
 * @date 2020/2/6 18:48
 */
public class ThreadPoolTest {

    static int j = 0;

    public static void main(String[] args) {
        System.out.println("main: " + Thread.currentThread().getId());
        ThreadPoolExecutor executor = new ThreadPoolExecutor(5, 10, 60,
                TimeUnit.SECONDS, new LinkedBlockingDeque<>());
        for(int i=0; i<10; i++) {
            executor.execute(()->{
                try {
                    Thread.sleep(100);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                System.out.println("executor: " + Thread.currentThread().getId());
                System.out.println("    execute task");
            });
        }
    }
}
