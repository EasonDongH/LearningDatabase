<%@ page import="java.util.List" %>
<%@ page import="java.util.ArrayList" %>
<%@ page import="java.util.Date" %>
<%@ page import="model.User" %><%--
  Created by IntelliJ IDEA.
  User: Administrator
  Date: 2019/11/6
  Time: 14:10
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<html>
<head>
    <title>jstl</title>
<body>
<%
    List list = new ArrayList();
    list.add(new User("张三", 23, new Date()));
    list.add(new User("李四", 23, new Date()));
    list.add(new User("王二", 23, new Date()));
    list.add(new User("梅超风", 23, new Date()));
    request.setAttribute("list", list);
%>

<table border="1px">
    <tr>
        <th>编号</th>
        <th>姓名</th>
        <th>年级</th>
        <th>出生日期</th>
    </tr>
    <c:forEach items="${requestScope .list}" var="user" varStatus="s">
        <c:if test="${s.index %2  == 0}">
            <tr bgcolor="#7fffd4">
                <td>${s.index+1}</td>
                <td>${user.name}</td>
                <td>${user.age}</td>
                <td>${user.birStr}</td>
            </tr>
        </c:if>
        <c:if test="${s.index %2  != 0}">
            <tr bgcolor="#ff8c00">
                <td>${s.index+1}</td>
                <td>${user.name}</td>
                <td>${user.age}</td>
                <td>${user.birStr}</td>
            </tr>
        </c:if>
    </c:forEach>
</table>
</body>
</html>
