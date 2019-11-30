<%--
  Created by IntelliJ IDEA.
  User: EasonDongH
  Date: 2019/11/30
  Time: 20:44
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>参数绑定</title>
</head>
<body>
    <a href="param/testBindingParam?username=hehe&password=123456">简单参数绑定</a><br/>

    测试封装JavaBean<br/>
    <form action="param/bindingJavaBean" method="post">
        账户名：<input type="text" name="name"><br/>
        金额：<input type="text" name="money"><br/>
        用户名：<input type="text" name="user.name"><br/>
        年龄：<input type="text" name="user.age"><br/>
        封装List<br/>
        用户名：<input type="text" name="list[0].name"><br/>
        年龄：<input type="text" name="list[0].age"><br/>
        封装Map<br/>
        用户名：<input type="text" name="map['key'].name"><br/>
        年龄：<input type="text" name="map['key'].age"><br/>
        <input type="submit" value="提交">
    </form>

    测试自定义类型转换器<br/>
    <form action="param/saveUser" method="post">
        用户名：<input type="text" name="name"><br/>
        年龄：<input type="text" name="age"><br/>
        生日：<input type="text" name="birthday"><br/>
        <input type="submit" value="提交">
    </form>
</body>
</html>
