package interrupt;

import java.util.concurrent.*;

/**
 * @author EasonDongH
 * @date 2020/2/12 14:42
 */
public class CancelTaskByFuture {
    private static ExecutorService taskExec = Executors.newFixedThreadPool(5);

    /**
     * 任务已完成则不影响，任务未完成则将会被中断
     * @param runnable
     * @param timeout
     * @param timeUnit
     * @throws InterruptedException
     */
    public static void timeRun(Runnable runnable, long timeout, TimeUnit timeUnit) throws InterruptedException {
        Future<?> task = taskExec.submit(runnable);
        try {
            task.get(timeout,timeUnit);
        } catch (ExecutionException e) {
            e.printStackTrace();
        } catch (TimeoutException e) {
            // e.printStackTrace();
        } finally {
            System.out.println("finally");
            task.cancel(true);
        }
    }

    public static void main(String[] args) throws InterruptedException {
        CancelTaskByFuture.timeRun(()->{
            try {
                TimeUnit.SECONDS.sleep(3);
                System.out.println("done");
            } catch (InterruptedException e) {
                // e.printStackTrace();
            }
        }, 1, TimeUnit.SECONDS);
    }
}
