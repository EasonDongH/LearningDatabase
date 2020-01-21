package com.easondongh;

import com.sun.jersey.api.client.*;
import org.apache.commons.fileupload.FileItem;
import org.apache.commons.fileupload.disk.DiskFileItemFactory;
import org.apache.commons.fileupload.servlet.ServletFileUpload;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.multipart.MultipartFile;

import javax.servlet.http.HttpServletRequest;
import java.io.File;
import java.lang.reflect.Field;
import java.util.List;
import java.util.UUID;

@Controller
@RequestMapping("file")
public class FileUploadController {

    @RequestMapping("uploadFile")
    public String uploadFile(HttpServletRequest request) throws Exception {
        // 获取上传文件存放路径
        String path = request.getSession().getServletContext().getRealPath("/uploads/");
        File file = new File(path);
        if (!file.exists()) {
            file.mkdirs();
        }
        DiskFileItemFactory factory = new DiskFileItemFactory();
        ServletFileUpload upload = new ServletFileUpload(factory);
        List<FileItem> items = upload.parseRequest(request);
        for (FileItem item : items) {
            if (!item.isFormField()) {// 上传文件
                String name = UUID.randomUUID().toString().replace("-", "") + "_" + item.getName();
                item.write(new File(path, name));
                item.delete();
            }
        }

        request.getSession().setAttribute("msg", "传统方式：上传成功");
        return "success";
    }

    /**
     *
     * @param request
     * @param uploadFile 必须与前端type="file"的对象同名
     * @return
     * @throws Exception
     */
    @RequestMapping("uploadFile2")
    public String uploadFile2(HttpServletRequest request, MultipartFile uploadFile) throws Exception {
        // 获取上传文件存放路径
        String path = request.getSession().getServletContext().getRealPath("/uploads/");
        File file = new File(path);
        if (!file.exists()) {
            file.mkdirs();
        }

        String prefix = UUID.randomUUID().toString().replace("-", "");
        String name = prefix + "_" + uploadFile.getOriginalFilename();
        uploadFile.transferTo(new File(path, name));

        request.getSession().setAttribute("msg", "基于SpringMVC框架：上传成功");
        return "success";
    }

    @RequestMapping("uploadFile3")
    public String uploadFile3(HttpServletRequest request, MultipartFile uploadFile) throws Exception {
        // 获取上传文件存放路径
        String path = "http://localhost:9090/uploads/";

        String prefix = UUID.randomUUID().toString().replace("-", "");
        String name = prefix + "_" + uploadFile.getOriginalFilename();

        // 与文件服务器建立连接
        Client client = Client.create();
        WebResource webResource = client.resource(path + name);
        webResource.put(uploadFile.getBytes());

        request.getSession().setAttribute("msg", "跨服务器：上传成功");
        return "success";
    }
}
