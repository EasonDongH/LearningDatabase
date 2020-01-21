<%@ page contentType="text/html;charset=UTF-8" language="java" isELIgnored="false" %>
<html>
<head>
    <title>SpringMVC响应类型</title>

    <script src="/js/jquery.min.js"></script>

    <script>
        $(function () {
           $("#btn").click(function () {
               // alert("ajax");
               $.ajax({
                   url:"user/testReturnJSON",
                   data:'{"name":"张赛","password":"123456"}',
                   contentType:"application/json;charset=UTF-8", // 发送给服务器的数据类型
                   dataType:"json", // 预期接受到的数据类型
                   type:"post",
                   success:function (data) {
                        alert(data);
                        alert(data.name);
                        alert(data.password);
                   }
               });
           });
        });
    </script>
</head>
<body>
<h3>Hello SpringMVC</h3>
    <a href="user/testReturnString">响应：String</a><br/>

    <a href="user/testReturnModelAndView">响应：ModelAndView</a><br/>

    <button id="btn">发送ajax请求</button>
</body>
</html>
