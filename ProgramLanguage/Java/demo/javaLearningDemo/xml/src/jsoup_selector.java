import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import java.io.File;
import java.io.IOException;

public class jsoup_selector {
    public static void main(String[] args) throws IOException {
        String path = jsoupDemo01.class.getClassLoader().getResource("student.xml").getPath();
        Document document = Jsoup.parse(new File(path), "utf-8");
        Elements elements = document.select("name");
        System.out.println(elements);

        Elements elements1 = document.select("#itcast");
        System.out.println(elements1);

    }
}
