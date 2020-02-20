package blockingqueue;

import java.io.IOException;
import java.util.concurrent.SynchronousQueue;

/**
 * @author EasonDongH
 * @date 2020/2/14 11:01
 */
public class SynchronousQueueTest {

    public static void main(String[] args) throws IOException {
        SynchronousQueue<String> syncQueue = new SynchronousQueue<>();
        new Thread(()->{
            int cnt = 0;
            while (true) {
                try {
                    syncQueue.put("第" + (cnt++) + "任务");
                    Thread.sleep(100);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        }).start();
        new Thread(()->{
            while (true) {
                try {
                    String take = syncQueue.take();
                    Thread.sleep(2000);
                    System.out.println(take);
                    System.out.println("剩余任务数量：" + syncQueue.size());
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        }).start();
    }
}
