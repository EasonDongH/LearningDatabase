package pool.executor;

import javax.sound.midi.Soundbank;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.concurrent.*;

/**
 * 模拟HTML渲染
 * 来自 Java并发编程实战 第六章
 * 并行处理输入中的文字渲染与图像渲染，因为图像渲染较复杂，要求每渲染完一张
 * 图片就进行展示，以提高用户体验
 * @author EasonDongH
 * @date 2020/2/8 12:16
 */
public class Renderer {

    public final static String Text = "文本";
    public final static String Image = "图像";
    Random random = new Random();

    private final ExecutorService executorService;

    public Renderer(ExecutorService executorService) {
        this.executorService = executorService;
    }

    private void renderText(String text) {
        System.out.println(Text + "["+text+"]");
    }

    private void renderImage(String image) {
        System.out.println("---------------");
        System.out.println("|--------------|");
        System.out.println("|----"+image+"----|");
        System.out.println("|--------------|");
        System.out.println("---------------");
    }

    private String getAd() throws InterruptedException {
        int delay = random.nextInt(10000);
        System.out.println(delay);
        Thread.sleep(delay);
        return "广告";
    }

    public void renderPage(List<String> texts, List<String> images) throws InterruptedException, ExecutionException {
        ExecutorCompletionService<String> completionService = new ExecutorCompletionService<>(executorService);
        // 模拟下载图片

        for (String image : images) {
            completionService.submit(()->{
                Thread.sleep(random.nextInt(10000));
                return image;
            });
        }
        // 模拟渲染文本
        for (String text : texts) {
            renderText(text);
        }
        // 逐个获取下载好的图片，然后进行渲染
        for (int i = 0; i < images.size(); i++) {
            Future<String> future = completionService.take();
            String image = future.get();
            renderImage(image);
        }

        // 模拟加载广告：超时即显示默认广告
        String ad = "";
        Future<String> future = executorService.submit(()->{
            return getAd();
        });
        try {
            ad = future.get(100, TimeUnit.MILLISECONDS);
        } catch (TimeoutException e) {
            ad = "默认";
            future.cancel(true);
        }
        System.out.println(ad);
    }

    public static void main(String[] args) throws ExecutionException, InterruptedException {
        List<String> texts = new ArrayList<>();
        texts.add("网站");texts.add("用户名");
        List<String> images = new ArrayList<>();
        images.add("图片1");images.add("图片2");images.add("图片3");
        ExecutorService executorService = Executors.newFixedThreadPool(10);
        Renderer renderer = new Renderer(executorService);
        renderer.renderPage(texts, images);
    }
}
