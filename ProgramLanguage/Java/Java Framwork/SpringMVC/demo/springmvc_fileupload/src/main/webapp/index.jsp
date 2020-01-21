<%@ page contentType="text/html;charset=UTF-8" language="java" isELIgnored="false" %>
<html>
<body>
<h2>Hello World!</h2>
</body>
    <h3>文件上传：传统方式</h3><br/>
    <form action="file/uploadFile" method="post" enctype="multipart/form-data">
        选择文件：<input type="file" name="uploadfile"><br/>
        <input type="submit" value="上传">
    </form>

    <h3>文件上传：基于SpringMVC框架</h3><br/>
    <form action="file/uploadFile2" method="post" enctype="multipart/form-data">
        选择文件：<input type="file" name="uploadFile"><br/>
        <input type="submit" value="上传">
    </form>

    <h3>文件上传：跨服务器</h3><br/>
    <form action="file/uploadFile3" method="post" enctype="multipart/form-data">
        选择文件：<input type="file" name="uploadFile"><br/>
        <input type="submit" value="上传">
    </form>
</html>
