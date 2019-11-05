import javax.imageio.ImageIO;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.util.Random;

@WebServlet("/checkCodeServlet")
public class CheckCodeServlet extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        int width = 100, height = 50;
        BufferedImage img = new BufferedImage(width, height, BufferedImage.TYPE_INT_RGB);
        Graphics g = img.createGraphics();
        g.setColor(Color.LIGHT_GRAY);
        g.fillRect(0,0,width,height);

        String code = "ABCDEFGHIJKLMNOPQISTUVWXYZ0123456789abcefghijklmnopqistuvwxyz";
        Random ran = new Random();
        g.setColor(Color.BLUE);
        g.setFont(new Font("微软雅黑", 0, 20));
        String checkCode = "";
        for(int i=1; i<=4; i++) {
            int cur = ran.nextInt(code.length());
            checkCode += code.charAt(cur);
            g.drawString(code.charAt(cur) + "", width/5 * i, 30);
        }
        HttpSession session = request.getSession();
        session.setAttribute("checkCode", checkCode);

        for (int i = 0; i < 10; i++) {
            int x1 = ran.nextInt(width);
            int x2 = ran.nextInt(width);
            int y1 = ran.nextInt(height);
            int y2 = ran.nextInt(height);
            g.drawLine(x1,y1,x2,y2);
        }

        ImageIO.write(img, "jpg", response.getOutputStream());
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        this.doPost(request, response);
    }
}
