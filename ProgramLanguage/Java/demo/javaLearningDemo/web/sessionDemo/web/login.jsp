<%--
  Created by IntelliJ IDEA.
  User: EasonDongH
  Date: 2019/11/5
  Time: 20:30
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>登录</title>

    <script>
        window.onload = function (ev) {
            var img = document.getElementById("refreshCkCode");
            img.onclick = function (ev2) {
                img.src = "/demo/checkCodeServlet?" + new Date().getTime();
            }
        }
    </script>

    <style>
        div{
            color: red;
        }
    </style>
</head>
<body>
<form action="/demo/LoginServlet" method="post">
    <table>
        <tr>
            <td>用户名</td>
            <td><input type="text" name="username"></td>
        </tr>
        <tr>
            <td>密码</td>
            <td><input type="text" name="pwd"></td>
        </tr>
        <tr>
            <td>验证码</td>
            <td><input type="text" name="checkcode"></td>
        </tr>
        <tr>
            <td colspan="2"><img id="refreshCkCode" src="/demo/checkCodeServlet" alt=""></td>
        </tr>
    </table>
    <input type="submit" value="登录">

    <div>
        <%=
        request.getAttribute("login_error") == null? "" : request.getAttribute("login_error")
        %>
    </div>
</form>
</body>
</html>
