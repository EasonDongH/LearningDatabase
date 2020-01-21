package com.easondongh.util;

import java.util.UUID;

public class UuidUtil {

    /**
     * 获取新生成的UUID
     * @return
     */
    public static String getUuid(){
        return UUID.randomUUID().toString();
    }
}
