import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;

import java.io.IOException;
import java.net.URL;

public class jsoupDemo01 {
    public static void main(String[] args) throws IOException {
//        // 1. 解析本地XML文件
//        String path = jsoupDemo01.class.getClassLoader().getResource("student.xml").getPath();
//        Document document = Jsoup.parse(new File(path), "utf-8");
//        org.jsoup.select.Elements elements = document.getElementsByTag("name");
//
//        System.out.println(elements.size());
//        Element element = elements.get(0);
//        String name = element.text();
//        System.out.println(name);
//
//        System.out.println("++++++++++++++++++++++++++++++++++++++++++");
//
//        // 2. 解析XML字符串
//        Document document2 = Jsoup.parse("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>\n" +
//                "\n" +
//                "<students>\n" +
//                "\t<student number=\"heima_0001\">\n" +
//                "\t\t<name id=\"itcast\">\n" +
//                "\t\t\t<xing>张</xing>\n" +
//                "\t\t\t<ming>三</ming>\n" +
//                "\t\t</name>\n" +
//                "\t\t<age>18</age>\n" +
//                "\t\t<sex>male</sex>\n" +
//                "\t</student>\n" +
//                "\t<student number=\"heima_0002\">\n" +
//                "\t\t<name>jack</name>\n" +
//                "\t\t<age>18</age>\n" +
//                "\t\t<sex>female</sex>\n" +
//                "\t</student>\n" +
//                "\n" +
//                "</students>");
//        System.out.println(document2);

        // 3. 解析网络XML或HTML资源
        URL url = new URL("https://www.baidu.com/");
        Document document3 = Jsoup.parse(url, 100000);
        System.out.println(document3);
    }
}
