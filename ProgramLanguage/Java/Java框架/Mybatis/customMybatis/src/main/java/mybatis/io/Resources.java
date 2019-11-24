package mybatis.io;

import java.io.InputStream;

public class Resources {

    /**
     * 根据文件路径获取字节输入流
     * @param filePath
     * @return
     */
    public static InputStream getResourceAsStream(String filePath){
        return  Resources.class.getClassLoader().getResourceAsStream(filePath);
    }
}
