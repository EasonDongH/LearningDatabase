import javax.servlet.ServletContext;
import javax.servlet.ServletException;
import javax.servlet.ServletOutputStream;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

@WebServlet("/downloadServlet")
public class DownloadServlet extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String filename = request.getParameter("filename");
        if (filename != null && filename.trim().length() > 0) {
            ServletContext context = this.getServletContext();
            String realPath = context.getRealPath("/files/" + filename);
            FileInputStream fis = new FileInputStream(realPath);
            ServletOutputStream sos = response.getOutputStream();

            String mimeType = context.getMimeType(filename);
            response.setHeader("content-type", mimeType);
            response.setHeader("Content-disposition", "attachment;filename=" + filename);

            int len = 0;
            byte[] buff = new byte[1024*8];
            while((len=fis.read(buff)) != -1){
                sos.write(buff, 0, len);
            }
            fis.close();
        }
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        this.doPost(request, response);
    }
}
