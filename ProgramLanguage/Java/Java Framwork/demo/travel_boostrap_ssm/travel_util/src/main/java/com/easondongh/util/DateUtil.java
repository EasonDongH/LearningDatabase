package com.easondongh.util;

import org.springframework.core.convert.converter.Converter;
import org.springframework.stereotype.Component;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class DateUtil implements Converter<String,Date> {

    /**
     * 将date以format格式转换为字符串
     * @param date
     * @param format
     * @return
     */
    public static String date2String(Date date,String format) {
        SimpleDateFormat formater = new SimpleDateFormat(format);
        return formater.format(date);
    }

    /**
     * 将具有format格式的时间字符串dateStr转换为date类型
     * @param dateStr
     * @param foramt
     * @return
     * @throws ParseException
     */
    public static Date string2Date(String dateStr, String foramt) throws ParseException {
        SimpleDateFormat formater = new SimpleDateFormat(foramt);
        return formater.parse(dateStr);
    }

    @Override
    public Date convert(String source) {
        if(source == null) {
            throw new RuntimeException("input cannot be null");
        }
        try {
            return string2Date(source, "yyyy-MM-dd HH:mm");// 注意这个pattern
        } catch (ParseException e) {
            e.printStackTrace();
        }
        return null;
    }
}
