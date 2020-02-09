package utils;

import java.util.Random;

/**
 * @author EasonDongH
 * @date 2020/2/9 18:56
 */
public class Utils {

    public static int[] buildRandomIntArray(final int size) {
        int[] arrayToCalculateSumOf = new int[size];
        Random generator = new Random();
        for (int i = 0; i < arrayToCalculateSumOf.length; i++) {
            arrayToCalculateSumOf[i] = generator.nextInt(Integer.MAX_VALUE);
        }
        return arrayToCalculateSumOf;
    }

    public static boolean isSorted(final int[] arr, boolean isAsc){
        if(arr == null) {
            return false;
        }
        for(int i=1; i<arr.length; i++) {
            if(isAsc) {
                if(arr[i] < arr[i-1]) {
                    return false;
                }
            } else {
                if(arr[i] > arr[i-1]) {
                    return false;
                }
            }
        }
        return true;
    }
}
