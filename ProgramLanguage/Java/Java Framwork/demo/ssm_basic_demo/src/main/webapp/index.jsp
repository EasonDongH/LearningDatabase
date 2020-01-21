<%--
  Created by IntelliJ IDEA.
  User: Administrator
  Date: 2019/12/3
  Time: 11:58
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Title</title>
</head>
<body>
    <a href="user/listAll">测试Spring MVC</a>
    <h3>测试添加</h3>
    <form action="user/save" method="post">
        姓名：<input type="text" name="name"><br>
        密码：<input type="text" name="password"><br>
        <input type="submit" value="提交">
    </form>
</body>
</html>
