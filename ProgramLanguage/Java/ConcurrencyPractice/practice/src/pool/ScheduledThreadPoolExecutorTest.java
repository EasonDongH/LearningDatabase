package pool;

import org.junit.Test;

import java.time.LocalDateTime;
import java.util.Date;
import java.util.concurrent.ScheduledThreadPoolExecutor;
import java.util.concurrent.TimeUnit;

/**
 * @author EasonDongH
 * @date 2020/2/8 16:24
 */
public class ScheduledThreadPoolExecutorTest {

    ScheduledThreadPoolExecutor executor = new ScheduledThreadPoolExecutor(10);

    public void task(){
        System.out.println(LocalDateTime.now());
        try {
            Thread.sleep(2000);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        System.out.println("Task");
        System.out.println(LocalDateTime.now());
        System.out.println("==============================");
    }

    /**
     * 延迟执行：只执行一次
     */
    public void test1(){
        executor.schedule(()->{
            task();
        }, 3, TimeUnit.SECONDS);
    }

    /**
     * 周期执行：固定速率
     */
    public void test2(int period){
        executor.scheduleAtFixedRate(()->{
            task();
        }, 0, period,TimeUnit.SECONDS);
    }

    /**
     * 周期执行：非固定速率
     */
    public void test3(int period){
        executor.scheduleWithFixedDelay(()->{
            task();
        }, 0, period,TimeUnit.SECONDS);
    }

    public static void main(String[] args) {
        ScheduledThreadPoolExecutorTest test = new ScheduledThreadPoolExecutorTest();
//        test.test1();
//        test.test2(1);
        test.test3(1);
    }
}
