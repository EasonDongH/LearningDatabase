package practice.src.atomic;

import java.sql.Statement;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.atomic.AtomicStampedReference;

/**
 * @author EasonDongH
 * @date 2020/2/10 14:08
 */
public class AtomicStampedReferenceTest {
    // 初始值与初始版本号
    static AtomicStampedReference<Integer> stampedReference = new AtomicStampedReference<>(100, 1);

    public static void main(String[] args) {
        ExecutorService executorService = Executors.newFixedThreadPool(10);
        // 两个线程拿到相同的初始版号号，但只能一个线程更新成功
        executorService.execute(()->{
            System.out.println("T1 " + stampedReference.getStamp());
            try {
                TimeUnit.SECONDS.sleep(1);
                System.out.println(stampedReference.compareAndSet(stampedReference.getReference(),200 , stampedReference.getStamp(),
                        stampedReference.getStamp()+1));
                System.out.println("T1 done.");
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        });

        executorService.execute(()->{
            int init = stampedReference.getStamp();
            System.out.println("T2 " + stampedReference.getStamp());
            try {
                TimeUnit.SECONDS.sleep(1);
                System.out.println(stampedReference.compareAndSet(stampedReference.getReference(),300 , stampedReference.getStamp(),
                        stampedReference.getStamp()+1));
                System.out.println("T2 done.");
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        });

        try {
            TimeUnit.SECONDS.sleep(5);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        executorService.shutdownNow();
        System.out.println(stampedReference.getStamp());
    }
}
