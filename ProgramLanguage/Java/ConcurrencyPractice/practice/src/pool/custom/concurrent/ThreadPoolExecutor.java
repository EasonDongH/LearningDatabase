package pool.custom.concurrent;

import java.util.HashSet;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.RejectedExecutionException;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.atomic.AtomicInteger;
import java.util.concurrent.locks.ReentrantLock;

/**
 * @author EasonDongH
 * @date 2020/2/8 22:29
 */
public class ThreadPoolExecutor implements Executor {

    private volatile int corePoolSize = 0, maxPoolSize = 0;
    private volatile long keepAliveTime = 0;
    private volatile boolean allowCoreThreadTimeOut = false;
    /**
     * 任务队列
     */
    private BlockingQueue<Runnable> workQueue;
    /**
     * 记录当前活跃线程数量
     */
    private AtomicInteger ctl = new AtomicInteger(0);
    /**
     * 拒绝策略
     */
    private volatile RejectedExecutionHandler handler = new AbortPolicy();
    /**
     * 保存活跃线程
     */
    private final HashSet<Worker> workers = new HashSet<Worker>();
    /**
     * 线程池锁
     */
    private final ReentrantLock mainLock = new ReentrantLock();

    public ThreadPoolExecutor(int corePoolSize, int maxPoolSize, BlockingQueue<Runnable> workQueue) {
        this.corePoolSize = corePoolSize;
        this.maxPoolSize = maxPoolSize;
        this.workQueue = workQueue;
    }

    public ThreadPoolExecutor(int corePoolSize, int maxPoolSize, long keepAliveTime, BlockingQueue<Runnable> workQueue) {
        this.corePoolSize = corePoolSize;
        this.maxPoolSize = maxPoolSize;
        if(keepAliveTime <= 0) {
            throw new IllegalArgumentException();
        } else {
            this.keepAliveTime = keepAliveTime;
            this.allowCoreThreadTimeOut = true;
        }
        this.workQueue = workQueue;
    }

    @Override
    public void execute(Runnable command) {
        int c = ctl.get();
        if(c < this.corePoolSize) {
            // 活跃线程数量小于核心线程，直接新建线程
            if(addWorker(command, true)){
                return;
            }
            c = ctl.get();
        } else if(workQueue.offer(command)) {
            // 否则，将任务入队，有必要的话则新建一个firstTask为null的线程来获取线程
            int recheck = ctl.get();
            if(recheck == 0) {
                addWorker(null, false);
            }
        } else if(!addWorker(command,false)) {
            // 否则，以非核心线程运行任务；再次失败则拒绝
            reject(command);
        }
    }

    private boolean addWorker(Runnable firstTask, boolean core) {
        int wc = ctl.get();
        if(wc >= (core? corePoolSize : maxPoolSize)) {
            return false;
        }
        ctl.getAndIncrement();
        Worker w = new Worker(firstTask);
        if(w != null && w.thread != null) {
            w.thread.start();
        }
        return true;
    }

    private void runWorker(Worker w) {
        Runnable task = w.firstTask;
        // 等task置null后，firstTask即可回收
        w.firstTask = null;
        try {
            // 只要能获取非null的任务，就一直运行
            while (task != null || (task = getTask()) != null) {
                w.lock();
                try {
                    task.run();
                } finally {
                    // 这里要置空，否则task一直指向firstTask
                    task = null;
                    w.unlock();
                }
            }
        } finally {
            processWorkerExit(w);
        }
    }

    private void processWorkerExit(Worker w) {
        ctl.getAndDecrement();
    }

    private Runnable getTask() {
        int wc = ctl.get();
        // 若允许核心线程过期，或当前存在非核心线程
        boolean timed = allowCoreThreadTimeOut || wc > corePoolSize;
        Runnable r = null;
        try {
            // 销毁非核心线程一以及过期核心线程，就看这里
            r = timed ?
                    workQueue.poll(keepAliveTime, TimeUnit.MILLISECONDS) :
                    workQueue.take();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        return r;
    }

    final void reject(Runnable command) {
        handler.rejectedExecution(command, this);
    }

    private final class Worker extends ReentrantLock implements Runnable {
        private final Thread thread;
        private Runnable firstTask;

        public Worker(Runnable firstTask) {
            // 把任务交给线程
            this.thread = new Thread(this);
            this.firstTask = firstTask;
        }

        @Override
        public void run() {
            runWorker(this);
        }
    }

    public static class AbortPolicy implements RejectedExecutionHandler {
        /**
         * Creates an {@code AbortPolicy}.
         */
        public AbortPolicy() { }

        /**
         * Always throws RejectedExecutionException.
         *
         * @param r the runnable task requested to be executed
         * @param e the executor attempting to execute this task
         * @throws RejectedExecutionException always
         */
        @Override
        public void rejectedExecution(Runnable r, ThreadPoolExecutor e) {
            throw new RejectedExecutionException("Task " + r.toString() +
                    " rejected from " +
                    e.toString());
        }
    }
}
