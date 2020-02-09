package pool.custom.concurrent;

/**
 * @author EasonDongH
 * @date 2020/2/8 22:29
 */
public interface Executor {

    void execute(Runnable runnable);
}
