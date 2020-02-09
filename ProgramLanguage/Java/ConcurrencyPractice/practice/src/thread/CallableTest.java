package thread;

import java.util.concurrent.Callable;
import java.util.concurrent.FutureTask;

/**
 * @author EasonDongH
 * @date 2020/2/6 16:27
 */
public class CallableTest implements Callable<String> {

    @Override
    public String call() throws Exception {
        System.out.println("thread.CallableTest: " + Thread.currentThread().getId());
        Thread.sleep(3000);
        return "thread.CallableTest -> result";
    }

    public static void main(String[] args) throws Exception {
        System.out.println("main: " + Thread.currentThread().getId());
        FutureTask<String> futureTask = new FutureTask<>(new CallableTest());
        new Thread(futureTask).start();
        while (!futureTask.isDone()) {
            System.out.println("    futureTask is not done");
            Thread.sleep(500);
        }
        String s = futureTask.get();
        System.out.println(s);
    }
}
