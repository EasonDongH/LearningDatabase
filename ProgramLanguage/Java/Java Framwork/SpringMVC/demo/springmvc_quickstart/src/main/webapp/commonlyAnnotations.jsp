<%--
  Created by IntelliJ IDEA.
  User: EasonDongH
  Date: 2019/12/1
  Time: 8:59
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>常用注解</title>
</head>
<body>
    <a href="commonlyAnnotations/testRequestParam?username=test">RequestParam</a><br/>

    <h5>RequestBody</h5>
    <form action="commonlyAnnotations/testRequestBody" method="post">
        姓名：<input type="text" name="name">
        密码：<input type="text" name="password">
        <input type="submit" value="提交">
    </form>

    <a href="commonlyAnnotations/testPathVariable/123">PathVariable</a><br/>
</body>
</html>
