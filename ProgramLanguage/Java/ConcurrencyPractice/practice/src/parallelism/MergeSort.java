package parallelism;

import java.util.Arrays;

/**
 * @author EasonDongH
 * @date 2020/2/9 18:57
 */
public class MergeSort {

    public static int[] sort(final int[] arrayToSort, int threshold){
        if (arrayToSort.length < threshold) {
            Arrays.sort(arrayToSort);
            return arrayToSort;
        }
        int midpoint = arrayToSort.length / 2;
        int[] leftArray = Arrays.copyOfRange(arrayToSort, 0, midpoint);
        int[] rightArray = Arrays.copyOfRange(arrayToSort, midpoint, arrayToSort.length);
        leftArray = sort(leftArray, threshold);
        rightArray = sort(rightArray, threshold);
        return merge(leftArray, rightArray);
    }

    public static int[] merge(final int[] leftArray, final int[] rightArray) {
        int[] mergedArray = new int[leftArray.length + rightArray.length];
        int mergedArrayPos = 0;
        int leftArrayPos = 0;
        int rightArrayPos = 0;
        while (leftArrayPos < leftArray.length && rightArrayPos < rightArray.length) {
            if (leftArray[leftArrayPos] <= rightArray[rightArrayPos]) {
                mergedArray[mergedArrayPos] = leftArray[leftArrayPos];
                leftArrayPos++;
            } else {
                mergedArray[mergedArrayPos] = rightArray[rightArrayPos];
                rightArrayPos++;
            }
            mergedArrayPos++;
        }

        while (leftArrayPos < leftArray.length) {
            mergedArray[mergedArrayPos] = leftArray[leftArrayPos];
            leftArrayPos++;
            mergedArrayPos++;
        }

        while (rightArrayPos < rightArray.length) {
            mergedArray[mergedArrayPos] = rightArray[rightArrayPos];
            rightArrayPos++;
            mergedArrayPos++;
        }

        return mergedArray;
    }
}
