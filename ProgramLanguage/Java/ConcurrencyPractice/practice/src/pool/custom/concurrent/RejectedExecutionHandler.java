package pool.custom.concurrent;

/**
 * @author EasonDongH
 * @date 2020/2/9 10:31
 */
public interface RejectedExecutionHandler {

    void rejectedExecution(Runnable r, ThreadPoolExecutor executor);
}
