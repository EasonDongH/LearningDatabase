package interrupt;

import java.io.PrintWriter;
import java.util.concurrent.BlockingQueue;

/**
 * 生产者-消费者日志服务模式：LoggerThread来消费写日志任务
 * 为添加reservations原子性操作来确保shutdown后也会将当前任务完成再终止
 * @author EasonDongH
 * @date 2020/2/13 9:20
 */
public class LogService {
    private final BlockingQueue<String> queue;
    private final LoggerThread loggerThread;
    private final PrintWriter writer;
    private boolean isShutdown;
    private int reservations;

    public LogService(BlockingQueue<String> queue, PrintWriter writer) {
        this.queue = queue;
        this.writer = writer;
        this.loggerThread = new LoggerThread();
    }

    public void start() {
        loggerThread.start();
    }

    public void stop() {
        synchronized (this) {
            isShutdown = true;
        }
        loggerThread.interrupt();
    }

    public void log (String msg) throws InterruptedException {
        synchronized (this) {
            if(isShutdown) {
                throw new IllegalStateException();
            }
            ++reservations;
        }
        queue.put(msg);
    }

    private class LoggerThread extends Thread {
        public void run() {
            try {
                while (true) {
                    try {
                        synchronized (LogService.this) {
                            if(isShutdown && reservations == 0) {
                                break;
                            }
                        }
                        String msg = queue.take();
                        synchronized (LogService.this) {
                            --reservations;
                        }
                    }catch (InterruptedException e) {
//                            e.printStackTrace();
                    }
                }
            } finally {
                writer.close();
            }
        }
    }
}
