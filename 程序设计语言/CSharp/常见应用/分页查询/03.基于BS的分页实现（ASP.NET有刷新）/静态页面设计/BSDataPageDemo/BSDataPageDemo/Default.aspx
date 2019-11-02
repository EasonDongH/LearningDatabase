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
        <div id="DemoTitle">
            使用《ASP.NET三层架构+存储过程》实现分页</div>
        <div id="stuList">
            <asp:DataList ID="dlStuList" runat="server">
                <ItemTemplate>
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
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="QueryDiv">
            记录总条数：<asp:Literal ID="RecordsCount" Text="0" runat="server"></asp:Literal>&nbsp;&nbsp;总计页数：<asp:Literal
                ID="PagesCount" Text="0" runat="server"></asp:Literal>&nbsp;&nbsp;当前页码：
            <asp:Literal ID="CurrentPage" Text="0" runat="server"></asp:Literal>
        </div>
        <div class="QueryDiv">
            每页显示：<asp:DropDownList ID="ddlPageSize" runat="server">
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem Selected="True">10</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
            </asp:DropDownList>
            &nbsp;条&nbsp;&nbsp;跳转到：<input id="txtGoTo" type="text" />页&nbsp;<asp:Button ID="btnGoTo"
                runat="server" Text="GO " />
            &nbsp;<asp:Button ID="btnFirst" runat="server" Text="第一页" />
            &nbsp;
            <asp:Button ID="btnPre" runat="server" Text="上一页" />
            &nbsp;<asp:Button ID="btnNext" runat="server" Text="下一页" />
            &nbsp;<asp:Button ID="btnLast" runat="server" Text="最后页" />
        </div>
        <div class="QueryDiv">
            出生日期大于：<asp:TextBox ID="txtBirthday" onclick="WdatePicker()" Text="1988-01-01" runat="server"></asp:TextBox>
            <asp:Button ID="btnQuery" runat="server" Text="提交查询" onclick="btnQuery_Click" />
        </div>
        <br style="clear: both;" />
    </div>
    </form>
</body>
</html>
