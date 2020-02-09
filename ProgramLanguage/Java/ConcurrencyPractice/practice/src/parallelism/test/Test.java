package parallelism.test;

import parallelism.MergeSort;
import parallelism.MergeSortAction;
import utils.Utils;

import java.util.Arrays;
import java.util.concurrent.ForkJoinPool;

/**
 * @author EasonDongH
 * @date 2020/2/9 19:01
 */
public class Test {

    public static void main(String[] args) {
        int[] array = Utils.buildRandomIntArray(100000000);
        int[] arr1 = Arrays.copyOf(array,array.length);
        int[] arr2 = Arrays.copyOf(array,array.length);

        long point1 = System.currentTimeMillis();
        arr1 = MergeSort.sort(arr1,100);
        long point2 = System.currentTimeMillis();
        boolean sorted = Utils.isSorted(arr1, true);
        System.out.println("Single Thread: " + (point2 - point1) + "  sorted: " + sorted);

        int nofProcessors = Runtime.getRuntime().availableProcessors();
        MergeSortAction action = new MergeSortAction(arr2, 100);
        ForkJoinPool forkJoinPool = new ForkJoinPool(nofProcessors);
        long point3 = System.currentTimeMillis();
        forkJoinPool.invoke(action);
        long point4 = System.currentTimeMillis();
        sorted = Utils.isSorted(action.getSortedArray(), true);
        System.out.println("ForkJoinPool: " + (point4 - point3) + "  sorted: " + sorted);
    }
}
