<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BSDataPageDemo.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/CommonPage.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
    <div id="DemoTitle">使用《ASP.NET三层架构+jQuery+存储过程》实现无刷新分页</div>
        <div class="ItemDiv">
            <div class="ImgDiv">
                <img src="Images/100000.PNG" />
            </div>
            <div class="DescDiv">
                学号：100001</div>
            <div class="DescDiv">
                姓名：张宇航&nbsp;&nbsp;性别：男&nbsp;&nbsp;出生日期：1990-09-09</div>
            <div class="DescDiv">
                电话：13590878965</div>
            <div class="DescDiv">
                住址：天津市南开区白堤路风荷大夏100号1000001</div>
        </div>
        <div class="QueryDiv">
            记录总条数：<span id="RecordsCount">100</span>&nbsp;&nbsp;总计页数：<span id="PagesCount">10</span>&nbsp;&nbsp;当前页码：<span id="CurrentPage">5</span>
        </div>
        <div class="QueryDiv">
            每页显示：
            <select id="Select1">
                <option>5</option>
                <option selected="selected">10</option>
                <option>15</option>
            </select>条&nbsp;&nbsp;跳转到：<input id="txtGoTo" type="text" />页<input id="btnGoTo"
                type="button" value="go" />&nbsp;<input id="btnFirst" type="button" value="第一页" />&nbsp;<input
                    id="btnPre" type="button" value="上一页" />&nbsp;<input id="btnNext" type="button" value="下一页" />&nbsp;<input
                        id="btnLast" type="button" value="最后页" />
        </div>
        <div class="QueryDiv">
            出生日期大于：<input id="txtBirthday" onClick="WdatePicker()" type="text" /><input id="btnQuery" type="button" value="提交查询" />
        </div>
        <br style="clear: both;" />
    </div>
    </form>
</body>
</html>
